using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public static bool isAlive;

	public float factorForce;
    public float factorJump;

    Rigidbody2D rb;
	SpriteRenderer playerSR;

	bool left;
	bool right;
	bool vertical;

	bool flipX;
	int flipValue;

	public GameObject bulletToRight, bulletToLeft;
	Vector2 bulletPos;
	public float fireRate = 0.5f;
	public static int damageAmmo = 2;
	float nextFire = 0.0f;

	public Jump jump;

	void Start () {
		isAlive = true;
		flipValue = 1;
		rb = this.GetComponent<Rigidbody2D> ();
		playerSR = this.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	 void FixedUpdate () {

		if (isAlive == true) {
			
			left = Input.GetKey (KeyCode.A);
			right = Input.GetKey (KeyCode.D);
			vertical = Input.GetKey (KeyCode.W);

			if (right == true) {
				rb.AddForce (Vector2.right * factorForce);
				flip (1);
			} else if (left == true) {
				rb.AddForce (Vector2.left * factorForce);
				flip (-1);
			}

			if (Input.GetKey (KeyCode.RightArrow) && Time.time > nextFire) {
				flip (1);
				nextFire = Time.time + fireRate;
				bulletPos = transform.position;
				bulletPos += new Vector2 (+1.5f, -0.1f);
				Instantiate (bulletToRight, bulletPos, Quaternion.identity);
			} else if (Input.GetKey (KeyCode.LeftArrow) && Time.time > nextFire) {
				flip (-1);
				nextFire = Time.time + fireRate;
				bulletPos = transform.position;
				bulletPos += new Vector2 (-1.5f, -0.1f);
				Instantiate (bulletToLeft, bulletPos, Quaternion.identity);
			}

			if (vertical == true && jump.ident == true) {
				rb.AddForce (Vector2.up * factorJump); 
			}
		}
	}

	void OnTriggerEnter2D(Collider2D x){
		if (x.gameObject.tag == "LightMachineGun") {
			Destroy (x.gameObject);
			fireRate = 0.3f;
			damageAmmo = 1;
		} else if (x.gameObject.tag == "HeavyMachineGun"){
			Destroy (x.gameObject);
			fireRate = 0.7f;
			damageAmmo = 4;
		}
	}

	void OnCollisionEnter2D(Collision2D x){
		if (x.gameObject.tag == "Enemy") {
			GameController.rmvLifes (1);
		}
	}

	public static void setIsAlive(bool value){
		isAlive = value;
	}

	public static int getDamageAmmo(){
		return damageAmmo;
	}

	void flip(int value){
		if (this.flipValue != value) {
			flipValue = value;
			playerSR.flipX = !playerSR.flipX;
		}
	}
}