using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	private GameController gc;
	private float currentTimeToSpawn;


	[Header("Tempo maximo para instanciar")][Space(5)]
	public float timeToSpawn;
	[Header("Objetos a serem instanciados")][Space(5)]
	public GameObject[] prefabsObs;

	// Use this for initialization
	void Start () {
		gc = FindObjectOfType (typeof(GameController)) as GameController;
		currentTimeToSpawn = timeToSpawn;

	}
	
	// Update is called once per frame
	void Update () {
		if (gc.getStateMachine () == StatusMachine.INGAME) {
			currentTimeToSpawn += Time.deltaTime;
			if (currentTimeToSpawn >= timeToSpawn) {
				Spaw ();
				currentTimeToSpawn = 0;
			}
		}
	}

	private void Spaw(){
		int i = Random.Range (0, prefabsObs.Length);

		Instantiate (prefabsObs [i], transform.position, Quaternion.identity);
	}
}
