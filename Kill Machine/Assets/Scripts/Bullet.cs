using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float velX = 5f;
	public float velY = 0f;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		rb.velocity = new Vector2 (velX, velY);
	}

	void OnTriggerEnter2D(Collider2D x){
		 if (x.gameObject.tag == "Plataform" || x.gameObject.tag == "Floor") {
			Destroy (gameObject);
		}
	}
}
