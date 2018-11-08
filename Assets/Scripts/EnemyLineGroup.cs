using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLineGroup : MonoBehaviour {


	EnemyBlockMovement enemyBlockMovement;
	// Use this for initialization
	void Start () {
		enemyBlockMovement = FindObjectOfType<EnemyBlockMovement> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.childCount == 0) {
			Destroy (gameObject);
		}
		
	}

	void OnTriggerEnter2D(Collider2D collision){
		if (collision.tag == "EdgeOfScreenLeft") {
			enemyBlockMovement.movingRight = true;
			moveVertical ();
			Debug.Log ("Hit Left",gameObject);
		} else if (collision.tag == "EdgeOfScreenRight") {
			enemyBlockMovement.movingRight = false;
			moveVertical ();
			Debug.Log ("Hit Right",gameObject);
		}

	}

	private void moveVertical(){
		enemyBlockMovement.transform.Translate (new Vector3(0,-enemyBlockMovement.verticalMovement,0),Space.World);
		if (enemyBlockMovement.InitialMoveDelay > 0.1f) {
			enemyBlockMovement.InitialMoveDelay -= 0.05f;
		}

	}
}
