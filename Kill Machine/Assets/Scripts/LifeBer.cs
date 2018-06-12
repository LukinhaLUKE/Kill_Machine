using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBer : MonoBehaviour {

	public static LifeBer instanciate;
	public Image bar;

	void Awake(){
		if (instanciate == null) {
			instanciate = this;
		} else {
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
