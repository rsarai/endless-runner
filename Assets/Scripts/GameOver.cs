using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public Text bestScore;
	public Text score;

	// Use this for initialization
	void Start () {
		bestScore.text = PlayerPrefs.GetInt ("bestScore").ToString();
		score.text = PlayerPrefs.GetInt ("score").ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeScene(string cena){
		SceneManager.LoadScene (cena);
	}
}
