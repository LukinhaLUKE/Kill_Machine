using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public static bool isAlive;
	public float factorForce;
    public float factorJump;
    Rigidbody2D rb;
	//SpriteRenderer playerSR;
	bool flipX;
	int flipValue;
    public Bullet bullet;
    Vector2 bulletPos;
	public float fireRate = 0.5f;
	public static int damageAmmo = 2;
	float nextFire = 0.0f;
	public Jump jump;
	bool up;
	public Animator anime;
    public float maxXVelocity;
    public float maxYVelocity;

    //float mov;

    void Start () {
		isAlive = true;
		flipValue = 1;
		rb = this.GetComponent<Rigidbody2D> ();
		//playerSR = this.GetComponent<SpriteRenderer> ();
		//mov = Input.GetAxis ("horizontal");
	}
	
	// Update is called once per frame
	void Update () {
		andarAnime ();
	}

	 void FixedUpdate () {
		if (isAlive == true) {

			up = Input.GetKey (KeyCode.W);

			if (Input.GetKey (KeyCode.D)) {
				rb.AddForce (Vector2.right * factorForce);
				flip (1);
			} else if (Input.GetKey (KeyCode.A)) {
				rb.AddForce (Vector2.left * factorForce);
				flip (-1);
			}

			if (Input.GetKey (KeyCode.RightArrow) && Time.time > nextFire) {
				flip (1);
				nextFire = Time.time + fireRate;
				bulletPos = transform.position;
				bulletPos += new Vector2 (+1.5f, -1.3f);
                //var go = Instantiate (bulletToRight, bulletPos, Quaternion.identity);
                var go = Instantiate(bullet, bulletPos, Quaternion.identity);
                
			} else if (Input.GetKey (KeyCode.LeftArrow) && Time.time > nextFire) {
				flip (-1);
				nextFire = Time.time + fireRate;
				bulletPos = transform.position;
				bulletPos += new Vector2 (-1.5f, -1.3f);
                //Instantiate (bulletToLeft, bulletPos, Quaternion.identity);
                var go = Instantiate(bullet, bulletPos, Quaternion.identity);
                go.GetComponent<Bullet>().velX *= -1;
            }

			if (up == true && jump.ident == true) {
				rb.AddForce (Vector2.up * factorJump); 
			}

            
            rb.velocity = new Vector2( 
                Mathf.Clamp(rb.velocity.x, -maxXVelocity, maxXVelocity ), 
                Mathf.Clamp(rb.velocity.y, -maxYVelocity, maxYVelocity)
            );
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
        else if (x.gameObject.tag == "EnemyBullet")
        {
            GameController.rmvLifes(1);
			Destroy (x.gameObject);
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
			//playerSR.flipX = !playerSR.flipX;
			gameObject.transform.localScale = new Vector3(value * Mathf.Abs(gameObject.transform.localScale.x),gameObject.transform.localScale.y,gameObject.transform.localScale.z);
		}
	}

	void andarAnime (){
		if (Mathf.Abs(rb.velocity.x) > 0.001f) {
			anime.SetBool ("Andar", true);
		} else {
			anime.SetBool ("Andar", false);
		}
		//Debug.Log (rb.velocity.x);
	}
}