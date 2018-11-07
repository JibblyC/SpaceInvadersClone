using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	EnemyBlockMovement enemyBlockMovement;

	// Use this for initialization
	void Start () {	
		enemyBlockMovement = FindObjectOfType<EnemyBlockMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D collision){
		if (collision.tag == "Bullet") {
			Destroy (gameObject);
		}
		if (collision.tag == "EdgeOfScreenLeft") {
			enemyBlockMovement.movingRight = true;
			enemyBlockMovement.transform.Translate (new Vector3(0,-enemyBlockMovement.verticalMovement,0),Space.World);
			Debug.Log ("Hit Left",gameObject);
		} else if (collision.tag == "EdgeOfScreenRight") {
			enemyBlockMovement.movingRight = false;
			enemyBlockMovement.transform.Translate (new Vector3(0,-enemyBlockMovement.verticalMovement,0),Space.World);
			Debug.Log ("Hit Right",gameObject);
		}
			
	}
}
