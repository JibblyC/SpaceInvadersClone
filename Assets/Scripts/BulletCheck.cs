using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCheck : MonoBehaviour {

	// Use this for initialization

	PlayerController playerController;
	void Start () {
		playerController = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collision){
		if (collision.tag == "DestroyBullet" || collision.tag == "Enemy"){
			playerController.canFire = true;
			Destroy (gameObject);
		}
	}
}
