﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public int scoreValue;
	public Sprite explosionSprite;
	private LevelManager theLevelManager;

	public GameObject EnemyBulletPrefab;
	public Transform bulletSpawn;
	public float bulletMoveSpeed;
	// Use this for initialization
	void Start () {	
		theLevelManager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D collision){
		if (collision.tag == "Bullet") {
			StartCoroutine ("destroyEnemy");
		}
	}

	public IEnumerator destroyEnemy(){
		theLevelManager.updateScore(scoreValue);
		this.GetComponent<AudioSource>().Play();
		this.GetComponent<SpriteRenderer>().sprite = explosionSprite;
		this.GetComponent<SpriteRenderer> ().color = Color.white;
		yield return new WaitForSeconds (1f);
		Destroy (gameObject);
	}

	public void fireBullet(){
		var bullet = (GameObject)Instantiate(EnemyBulletPrefab, this.transform.position, bulletSpawn.rotation);
		bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(0f,bulletMoveSpeed);
		bullet.GetComponent<SpriteRenderer> ().color = this.GetComponent<SpriteRenderer> ().color;
	}
}
