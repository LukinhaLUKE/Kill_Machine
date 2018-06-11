using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

	private int life;
	public float speedMovement;
	SpriteRenderer sr;
	bool flipX;
	int flipValue;
	public float stopDistance;
	public float nerDistance;
	public float startShots;
	public float timeShots;
	public GameObject shot;
	private Transform player;

	// Use this for initialization
	void Start () {
		life = 4;
		sr = this.GetComponent<SpriteRenderer>();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float move = speedMovement * Time.deltaTime;

		if (life == 0) {
			GameController.addscore (100);
			Destroy (gameObject);
		}

		if (player.transform.position.x > this.transform.position.x) {
			flip (-1);
		} 
		if (player.transform.position.x < this.transform.position.x) {
			flip (1);
		}

		if (Vector2.Distance (transform.position, player.position) < nerDistance) {
			transform.position = Vector2.MoveTowards (transform.position, player.position, move);
		} else if (Vector2.Distance (transform.position, player.position) > stopDistance) {
			transform.position = Vector2.MoveTowards(transform.position, player.position, move);
		} else if (Vector2.Distance (transform.position, player.position) < stopDistance && Vector2.Distance (transform.position, player.position) > nerDistance){
			transform.position = this.transform.position;
		}
	}

	void OnTriggerEnter2D(Collider2D x){
		if (x.gameObject.tag == "Bullet") {
			Destroy (x.gameObject);
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