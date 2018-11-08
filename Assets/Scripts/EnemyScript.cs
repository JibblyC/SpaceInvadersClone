using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {


	public Sprite explosionSprite;

	public AudioSource explosionAudio;
	// Use this for initialization
	void Start () {	
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
		explosionAudio.Play();
		this.GetComponent<SpriteRenderer>().sprite = explosionSprite;
		this.GetComponent<SpriteRenderer> ().color = Color.white;
		yield return new WaitForSeconds (0.5f);
		Destroy (gameObject);
	}
}
