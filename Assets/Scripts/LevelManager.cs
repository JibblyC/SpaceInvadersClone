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
	void Start () {
		scoreDisplay.text = "Score: " + currentScore;
		hiddenScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (hiddenScore >= 100) {
			hiddenScore -= 100;
			Instantiate(highEnemyPrefab, highEnemySpawn.position, highEnemySpawn.rotation);
		}
		
	}

	public void updateScore(int scoreToAdd){
		currentScore += scoreToAdd;
		hiddenScore += scoreToAdd;
		scoreDisplay.text = "Score: " + currentScore;
	}
}
