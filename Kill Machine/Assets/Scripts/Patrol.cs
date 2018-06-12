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
    public Bullet bullet;
	Vector2 bulletPos;
	public float fireRate = 0.5f;
	public static int damageAmmo = 2;
	float nextFire = 0.0f;
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


        if (Vector2.Distance(transform.position, player.position) > stopDistance) {
            transform.position = this.transform.position;
        }else if(Vector2.Distance(transform.position, player.position) < stopDistance && Vector2.Distance(transform.position, player.position) > nerDistance) {
            transform.position = Vector2.MoveTowards(transform.position, player.position, move);
		}else if (Vector2.Distance(transform.position, player.position) < nerDistance && Time.time > nextFire)
        {
			nextFire = Time.time + fireRate;
			bulletPos = transform.position;
            var go = Instantiate(bullet, transform.position, Quaternion.identity);
			go.GetComponent<Bullet>().velX *= flipValue * -1;
            go.tag = "EnemyBullet";
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