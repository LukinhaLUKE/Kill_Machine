using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Text txtScore;
	public Text txtLifes;

	// Use this for initialization

	 void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		txtScore.text = GameController.getScore ().ToString ();
		txtLifes.text = GameController.getLifes ().ToString ();
	}
}
