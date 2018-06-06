using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

	public Transform player;
	public float speedCamera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.position = Vector3.Lerp (this.transform.position, new Vector3 (player.position.x, this.transform.position.y, this.transform.position.z), speedCamera);
	}
}
