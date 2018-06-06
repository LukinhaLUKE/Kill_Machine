using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

	public int life;
	public float speedMovement;
	public Transform[] targets;
	private bool movLeft;
	private bool coll;

	SpriteRenderer sr;
	bool flipX;
	int flipValue;

	// Use this for initialization
	void Start () {
		movLeft = true;
		life = 4;
		sr = this.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float move = speedMovement * Time.deltaTime;

		if (movLeft == true) {
			transform.position = Vector2.MoveTowards (transform.position, targets[0].position, move);
			flip (1);
		}else if (movLeft == false) {
			transform.position = Vector2.MoveTowards (transform.position, targets[1].position, move);
			flip (-1);
		}

		if (coll == true && movLeft == true) {
			movLeft = false;
		}else if (coll == true && movLeft == false) {
			movLeft = true;
		}

		if (life == 0) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D x){
		if (x.gameObject.transform == targets [0]) {
			coll = true;
		} else if (x.gameObject.transform == targets [1]) {
			coll = true;
		}
	}
	void OnCollisionStay2D(Collision2D x){
		if (x.gameObject.transform == targets[0]) {
			coll = false;
		} else if (x.gameObject.transform == targets[1]) {
			coll = false;
		}
	}
	void OnTriggerEnter2D(Collider2D x){
		if (x.gameObject.tag == "Bullet") {
			Destroy (x.gameObject);
			GameController.addscore (100);
			life -= Player.getDamageAmmo ();
		}
	}

	void flip(int value){
		if (this.flipValue != value) {
			flipValue = value;
			sr.flipX = !sr.flipX;
		}
	}
}