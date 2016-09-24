using UnityEngine;
using System.Collections;


public class Obstaculos : MonoBehaviour {
	private GameController gc;
	private bool pass;
	private PlayerBehaviour player;
	private float countdown = 9.0f;





	[Header("Atributo velocidade dos obstaculos")]
	private float speed = 4.0f;
	// Use this for initialization
	void Start () {
		gc = FindObjectOfType (typeof(GameController)) as GameController;
		player = FindObjectOfType(typeof(PlayerBehaviour)) as PlayerBehaviour;
	}
	
	// Update is called once per frame
	void Update () {
		if (gc.getStateMachine () == StatusMachine.INGAME) {

			countdown -= Time.deltaTime;
			if (countdown <= 0.0f) {
				speed += 15;
				countdown = 9.0f;
			}
			transform.Translate (-speed * Time.deltaTime, 0, 0);
			CheckPosition ();
		}
	}

	private void CheckPosition(){
		if (player.gameObject.transform.position.x > transform.position.x && !pass) {
			player.audio.PlayOneShot (player.audioGold,3.9f);
			pass = true;
			gc.setScore (gc.getScore() + 1);
		}

		if (transform.position.x <= -15.3f) {
			Destroy (gameObject);
		}
	}
}

