using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	GameObject mainCam;

	[SerializeField] CanvasManager canMan;

	public float currentDepth;

	public int score;

	public bool gameOver = false;

	//public string KilledByEnemy;

		public bool cthulhuSpawned = false;

	
	void Start() {
        mainCam = Camera.main.gameObject;

		//currentDepth = 1200;
    }


    void Update() {
		IncreaseDepth();
    }


	public void IncreaseScore(int points) {
		score += points;

		canMan.UpdateScoreText(score);
	}


	void IncreaseDepth() {
		if (!gameOver) {
			currentDepth += 12f * Time.deltaTime;
			canMan.UpdateDepthText(currentDepth);
		}
	}


	public void GameOver(string KilledByEnemy) {
		print("Game over.");
		gameOver = true;
		canMan.EnableGameOverUI(KilledByEnemy, score);
	}


	public void Win() {
		gameOver = true;
		canMan.EnableWinUI(score);
	}
}
