using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlockMovement : MonoBehaviour {

	public float moveDistance;
	public float InitialMoveDelay;

	public bool movingRight;
	public float verticalMovement;
	bool currentlyMoving;

	public List<GameObject> enemyLineList;


	// Use this for initialization
	void Start () {
		movingRight = true;
		currentlyMoving = false;
	}

	// Update is called once per frame
	void Update () {
		if (!currentlyMoving) {
			StartCoroutine ("MoveEnemy");
		}


	}

	public IEnumerator MoveEnemy(){
		currentlyMoving = true;
		yield return new WaitForSeconds (InitialMoveDelay);
		if (movingRight) {
			transform.Translate (new Vector3(moveDistance,0,0),Space.World);
		} else {
			transform.Translate (new Vector3(-moveDistance,0,0),Space.World);
		}
		currentlyMoving = false;
	}
}
