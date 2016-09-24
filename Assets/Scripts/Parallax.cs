using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	public  float speed;
	public Material material;

	private float offset;
	private GameController gc;

	// Use this for initialization
	void Start () {
		material = GetComponent<Renderer> ().material;
		gc = FindObjectOfType (typeof( GameController)) as GameController;
		gc.setStateMachine (StatusMachine.ESPERANDO);
	}
	
	// Update is called once per frame
	void Update () {
		if (gc.getStateMachine () == StatusMachine.INGAME) {
			offset += speed * Time.deltaTime;
			material.SetTextureOffset ("_MainTex", new Vector2 (offset, 0));
		}
	}
}
