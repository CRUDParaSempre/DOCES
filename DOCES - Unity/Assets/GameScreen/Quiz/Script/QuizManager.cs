using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class QuizManager : MonoBehaviour {

	[SerializeField] private Text questionText=null;


	[SerializeField] private Quiz_CSV quizCSV = null;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	
	}


	public void showQuiz(string difficulty) {



		List<string> infos = quizCSV.getQuestions (difficulty, "01/01");

		questionText.text = infos [0];

	}

	public void OnEnable(){
		showQuiz (GameStateManager.Instance.newClientDifficulty);	
		GameStateManager.Instance.setGameState (GameStateManager.GameState.GameCards);
	}
}
