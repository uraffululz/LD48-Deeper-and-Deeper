using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour {

	//SceneManager sceneMan;

	public Text scoreText;

	[SerializeField] Text depthText;

	[SerializeField] GameObject LoseUI;
	[SerializeField] Text finalScoreText;
	[SerializeField] Text killedByText;

	[SerializeField] GameObject WinUI;
	[SerializeField] Text winFinalScoreText;

	
	void Start() {
        
    }


    void Update() {
        
    }


	public void UpdateScoreText(int score) {
		scoreText.text = "Score: " + score;
	}


	public void UpdateDepthText(float depth) {
		depthText.text = "Depth: " + (int)depth;
	}


	public void EnableGameOverUI(string enemyName, int finalScore) {
		LoseUI.SetActive(true);
		finalScoreText.text = "Score: " + finalScore;
		killedByText.text = "You were killed by a " + enemyName;

		//Time.timeScale = 0;
	}


	public void EnableWinUI(int finalScore) {
		WinUI.SetActive(true);
		winFinalScoreText.text = "Score: " + finalScore;

	}


	public void BackToMenu() {
		//Time.timeScale = 1;
		SceneManager.LoadScene(0);
	}


	public void QuitGame() {
		Application.Quit();
	}
}
