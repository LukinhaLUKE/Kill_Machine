using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

	public bool ident;

	// Use this for initialization
	void Start () {
		ident = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D x){
		if (x.gameObject.tag == "Floor" || x.gameObject.tag == "Plataform") {
			ident = true;
		}
	}

	void OnTriggerExit2D(Collider2D x){
		if (x.gameObject.tag == "Floor" || x.gameObject.tag == "Plataform") {
			ident = false;
		}
	}
}
