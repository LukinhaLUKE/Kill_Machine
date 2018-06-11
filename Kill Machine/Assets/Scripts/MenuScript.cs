using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public void loadScene(string name){
		SceneManager.LoadScene (name);
	}

	public void quitGame(){
		Application.Quit ();
	}

}
