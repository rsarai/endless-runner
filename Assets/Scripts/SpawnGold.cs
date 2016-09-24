using UnityEngine;
using System.Collections;

public class SpawnGold : MonoBehaviour {

	public GameObject prefabGold;
	public Transform point;
	public float forceX;
	public float timeToSpawn;

	private GameController gc;
	private float currentTime;
	// Use this for initialization
	void Start () {
		gc = FindObjectOfType (typeof(GameController)) as GameController;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (gc.getStateMachine () == StatusMachine.INGAME) {
			currentTime += Time.deltaTime;
			if (currentTime >= timeToSpawn) {
				SpawGold ();
				currentTime = 0;
			}
		}
	}

	public void SpawGold(){
		GameObject tempPrefab = Instantiate (prefabGold) as GameObject;
		tempPrefab.transform.position = point.transform.position;
		tempPrefab.GetComponent<Rigidbody2D> ().AddForce (new Vector2(forceX, 0));
	}
}
