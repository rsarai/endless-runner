using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum StatusMachine{
	ESPERANDO,
	START,
	INGAME,
	PAUSE,
	GAMEOVER
}

public class GameController : MonoBehaviour {

	private StatusMachine currentStateMachine;
	private int score;



	public Text textScore ;

	public int goldCont{
		get;
		set;
	}
		


	// Use this for initialization
	void Start () {
		currentStateMachine = StatusMachine.ESPERANDO;
	}
	
	// Update is called once per frame
	void Update () {
		StateGame ();
	}

	private void StateGame(){
		switch (currentStateMachine) {
		case StatusMachine.ESPERANDO:
			{
				break;
			}

		case StatusMachine.START:
			{
				StartGame ();
				break;
			}

		case StatusMachine.PAUSE:
			{
				break;
			}


		case StatusMachine.GAMEOVER:
			{
				GameOver ();
				break;
			}

		case StatusMachine.INGAME:
			{
				InGame ();
				break;
			}
			
		}
	}

	public StatusMachine getStateMachine(){
		return currentStateMachine;
	}

	public void setStateMachine(StatusMachine other){
		currentStateMachine = other;
	}

	public int getScore(){
		return score;
	}

	public void setScore(int other){
		this.score = other;
	}

	private void InGame(){
		textScore.text = score.ToString ();
	}

	private void StartGame(){
		score = 0;
		currentStateMachine = StatusMachine.INGAME;
	}

	private void GameOver(){
		PlayerPrefs.SetInt ("score", score);
		if (score > PlayerPrefs.GetInt ("bestScore")) {
			PlayerPrefs.SetInt("bestScore", score);
		}

		SceneManager.LoadScene ("GameOver");
	}

	public void MoreScore(){
		if (goldCont >= 5) {
			goldCont = 0;
			score += 5;
		}
	}
}
