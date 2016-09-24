using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Gold : MonoBehaviour {

	private GameController gc;


	public void AddGoldCont(){
		gc.goldCont += 1;
	}

	// Use this for initialization
	void Start () {
		gc = FindObjectOfType (typeof(GameController)) as GameController;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
