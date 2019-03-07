using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {


	public int currentScore;
	private int hiddenScore;

	public Text scoreDisplay;

	public GameObject highEnemyPrefab;
	public Transform highEnemySpawn;
	// Use this for initialization

	private EnemyBlockMovement enemyBlockMovement;
	private List<GameObject> enemyLineList;
	private PlayerController playerController;
	bool currentlyFiring = false;
	//TEsting variables
	public int testingRow;
	public int testingEnemy;

	//

	void Start () {
		scoreDisplay.text = "Score: " + currentScore;
		hiddenScore = 0;
		enemyBlockMovement = FindObjectOfType<EnemyBlockMovement> ();
		playerController = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (hiddenScore >= 100) {
			hiddenScore -= 100;
			Instantiate(highEnemyPrefab, highEnemySpawn.position, highEnemySpawn.rotation);
		}

		if (!currentlyFiring) {
			StartCoroutine ("fireEnemyBullet");
		}
	}

	public void Respawn(){
		StartCoroutine ("RespawnCo");
	}

	public IEnumerator RespawnCo(){
		playerController.gameObject.SetActive (false);
		yield return new WaitForSeconds (2f);
		playerController.transform.position = playerController.respawnPosition;
		playerController.gameObject.SetActive (true);
	}


	public void updateScore(int scoreToAdd){
		currentScore += scoreToAdd;
		hiddenScore += scoreToAdd;
		scoreDisplay.text = "Score: " + currentScore;
	}

	public IEnumerator fireEnemyBullet(){
		currentlyFiring = true;
		try
		{
			System.Random rnd = new System.Random();
			int randomRow = rnd.Next (0, enemyBlockMovement.transform.childCount - 1);
			GameObject ChildGameObject1 = enemyBlockMovement.transform.GetChild (randomRow).gameObject;
			int randomEnemy = rnd.Next (0, ChildGameObject1.transform.childCount - 1);
			EnemyScript ChildGameObject2 = ChildGameObject1.transform.GetChild (randomEnemy).gameObject.GetComponent<EnemyScript>();
			ChildGameObject2.fireBullet();
		}
		catch (System.Exception e){
			print (e.ToString ());
		}

		yield return new WaitForSeconds (3f);
		currentlyFiring = false;
	}
}
