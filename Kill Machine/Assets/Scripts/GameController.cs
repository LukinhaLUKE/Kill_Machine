using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	private static int score;
	private static int lifes;
	private static bool paused;

	public static void addscore(int value){
		score += value;
	}

	public static int getScore(){
		return score;
	}

	public static void addLifes(int value){
		lifes += value;
	}

	public static void rmvLifes(int value){
		lifes -= value;
	}

	public static int getLifes(){
		return lifes;
	}

	// Use this for initialization
	void Start () {
		score = 0;
		lifes = 6;
		paused = false;
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.P) && paused == false) {
			paused = true;
			Time.timeScale = 0;
		} else if (Input.GetKeyDown (KeyCode.P) && paused == true) {
			paused = false;
			Time.timeScale = 1;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (lifes <= 0) {
			Player.setIsAlive (false);
			loadScene ("GameOver");
		}
	}

	public static void loadScene(string name){
		SceneManager.LoadScene (name);
	}
}
