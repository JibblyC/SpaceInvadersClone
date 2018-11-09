using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopHighestEnemyScript : MonoBehaviour {

	public int scoreValue;
	public Sprite explosionSprite;
	private LevelManager theLevelManager;
	public float moveSpeed;

	public GameObject splooshSound;
	public Transform splooshSoundTransform;
	// Use this for initialization
	void Start () {	
		theLevelManager = FindObjectOfType<LevelManager>();
		transform.position = new Vector3 (-13f, 4, 0);
	}
		
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3(moveSpeed,0,0),Space.World);	
	}

	void OnTriggerEnter2D(Collider2D collision){
		if (collision.tag == "Bullet") {
			StartCoroutine ("destroyEnemy");
		}

		if (collision.tag == "DestroyHighEnemy") {
			Destroy (gameObject);
		}


	}

	public IEnumerator destroyEnemy(){
		theLevelManager.updateScore(scoreValue);
		Instantiate(splooshSound, gameObject.transform.position, splooshSoundTransform.rotation);
		this.GetComponent<SpriteRenderer>().sprite = explosionSprite;
		this.GetComponent<SpriteRenderer> ().color = Color.white;
		yield return new WaitForSeconds (0.5f);
		Destroy (gameObject);

	}
}
