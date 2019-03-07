using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Rigidbody2D rigidBody;
	public float moveSpeed;
	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	public float bulletMoveSpeed;

	public bool canFire;

	public Vector3 respawnPosition;

	private LevelManager theLevelManager;

	public GameObject deathSound;
	public Transform deathSoundTransform;


	// Use this for initialization
	void Start () {
		canFire = true;
		respawnPosition = transform.position;
		theLevelManager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxisRaw ("Horizontal") > 0f) {
			rigidBody.velocity = new Vector3 (moveSpeed, rigidBody.velocity.y, 0f);
		} else if (Input.GetAxisRaw ("Horizontal") < 0f) {
			rigidBody.velocity = new Vector3 (-moveSpeed, rigidBody.velocity.y, 0f);
		} else {
			rigidBody.velocity = new Vector3 (0f, rigidBody.velocity.y, 0f);
		}
			
		if (Input.GetKeyDown (KeyCode.Space) && canFire) {
			fireGun ();
		}


			
	}

	void OnTriggerEnter2D(Collider2D collision){
		if (collision.tag == "EnemyBullet") {
			Instantiate(deathSound, gameObject.transform.position, deathSoundTransform.rotation);
			theLevelManager.Respawn ();
		}
	}

	public void fireGun(){
		
		canFire = false;
		var bullet = (GameObject)Instantiate(bulletPrefab, rigidBody.position, bulletSpawn.rotation);
		bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(0f,bulletMoveSpeed);
		
	}
}
