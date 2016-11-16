using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class QuizManager : MonoBehaviour {
	[SerializeField] private Text difficultyText=null;
	[SerializeField] private Image quotes=null;
	[SerializeField] private List<Color> difficultyColors=null;
	[SerializeField] private Text questionText=null;
	[SerializeField] private Quiz_CSV quizCSV = null;
	[SerializeField] private List<Text> pointsUI = null;
	[SerializeField] private List<int> pointsPerDifficulty = null;
	[SerializeField] private int golpinhosPerPoint = 100;
	[SerializeField] private float rotationSpeed = 10f;
	[SerializeField] private List<GameObject> buttons = null;
	[SerializeField] private List<Sprite> buttonFront = null; // 0= true button, 1= false button
	[SerializeField] private List<Sprite> buttonBack = null; // 0= right, 1= wrong
	[SerializeField] private List<bool> buttonChangedSprite = null;
	[SerializeField] private List<bool> buttonCanRotate = null;
	[SerializeField] private List<int> bonus = null;
	[SerializeField] private float timeAfterAnimation = 1f;

	private bool questionAnswer = false;
	private List<int> statusPool = new List<int>();
	private string questionId;
	private bool playerAnswered = false;
	private bool isPlayerRight = false;
	private RectTransform rt = null;
	private int finishedAnimation=0;
	private float lastAnimationFinishTime;



	// Use this for initialization
	void Start () {
		rt = GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (playerAnswered) {
			for (int i = 0; i < buttons.Count; i++) {
				if (buttonCanRotate [i]) {
					rotateButton (i);
				}
			}

			if (finishedAnimation == 2 && Time.time - lastAnimationFinishTime > timeAfterAnimation) {
				GameStateManager.Instance.playerAnswered (bonus,isPlayerRight);
			}
		}
	}

	private void rotateButton(int buttonId) {
		buttons [buttonId].GetComponent<RectTransform> ().Rotate (0f, rotationSpeed * Time.deltaTime, 0f);

		if (Mathf.Abs (buttons [buttonId].GetComponent<RectTransform> ().localRotation.eulerAngles.y - 90f) < 5f && !buttonChangedSprite [buttonId]) {
			buttonChangedSprite [buttonId] = true;

			if (questionAnswer == true) {
				if (buttonId == 0) {
					buttons [buttonId].GetComponent<Image> ().sprite = buttonBack [0];
				} else if (buttonId == 1) {
					buttons [buttonId].GetComponent<Image> ().sprite = buttonBack [1];
				}

			} else {
				if (buttonId == 0) {
					buttons [buttonId].GetComponent<Image> ().sprite = buttonBack [1];
				} else if (buttonId == 1) {
					buttons [buttonId].GetComponent<Image> ().sprite = buttonBack [0];
				}
			}

		} else if (Mathf.Abs (buttons [buttonId].GetComponent<RectTransform> ().localRotation.eulerAngles.y - 180f) < 5f) {
			buttonCanRotate [buttonId] = false;
			buttons [buttonId].GetComponent<RectTransform> ().localRotation = Quaternion.Euler (new Vector3 (0f, 180f, 0f));

			finishedAnimation++;
			lastAnimationFinishTime = Time.time;
		}
	}


	public void showQuiz(string difficulty) {
		List<string> infos = quizCSV.getQuestion (difficulty);

		//inicializa a qestao
		difficultyText.text = difficulty;
		questionId = infos [0];
		questionText.text = infos [1];
		questionAnswer = (infos [2].ToLower ().CompareTo ("falso") == 0) ? false : true;

		int pointsToDistribute = 0;

		//seta quantos pontos distribuir, o titulo e a cor do titulo
		switch(difficulty) {
		case "Fácil":
			pointsToDistribute = pointsPerDifficulty [0];
			quotes.color = difficultyColors [0];
			difficultyText.color = difficultyColors [0];
			break;
		case "Média":
			pointsToDistribute = pointsPerDifficulty [1];
			quotes.color = difficultyColors [1];
			difficultyText.color = difficultyColors [1];
			break;
		case "Difícil":
			pointsToDistribute = pointsPerDifficulty [2];
			quotes.color = difficultyColors [2];
			difficultyText.color = difficultyColors [2];
			break;
		default:
			pointsToDistribute = 0;
			Debug.LogError ("Dificuldade da pergunta não é válida!");
			break;
		}

		//inicializa os texts ui
		for (int i = 0 ; i < pointsUI.Count  ; i++) {
			statusPool.Add (i);
			pointsUI[i].text = "+0";
		}


		//sorteio dos valores dos bonus
		for (int i = 0; i < pointsUI.Count && pointsToDistribute > 0 ; i++) {
			int random = Random.Range (0, statusPool.Count);
			int currentStatus = statusPool [random];
			int pointsDistributed = 0;
			statusPool.RemoveAt (random);


			if (i + 1 < pointsUI.Count) {
				//status 3 = golpinhos
				if (currentStatus == 3) {
					pointsDistributed = Random.Range (0, pointsToDistribute);
					pointsUI [currentStatus].text = "+" + CardsManager.abreviateMoney ((pointsDistributed*golpinhosPerPoint).ToString());
					bonus [currentStatus] = pointsDistributed * golpinhosPerPoint;
					Debug.Log ("Setei bonus["+currentStatus+"]= " + pointsDistributed * golpinhosPerPoint + " (" + bonus[currentStatus] +")");
				} else {
					pointsDistributed = Random.Range (0, pointsToDistribute);
					pointsUI [currentStatus].text = "+" + pointsDistributed.ToString ();
					bonus [currentStatus] = pointsDistributed;
					Debug.Log ("Setei bonus["+currentStatus+"]= " + pointsDistributed * golpinhosPerPoint + " (" + bonus[currentStatus] +")");
				}
			
			} else {
				//status 3 = golpinhos
				if (currentStatus == 3) {
					pointsDistributed = pointsToDistribute;
					pointsUI [currentStatus].text = "+" + CardsManager.abreviateMoney ((pointsDistributed*golpinhosPerPoint).ToString()).ToString ();
					bonus [currentStatus] = pointsDistributed * golpinhosPerPoint;
					Debug.Log ("Setei bonus["+currentStatus+"]= " + pointsDistributed * golpinhosPerPoint + " (" + bonus[currentStatus] +")");
				} else {
					pointsDistributed = pointsToDistribute;
					pointsUI [currentStatus].text = "+" + pointsDistributed.ToString();
					bonus [currentStatus] = pointsDistributed;

				}
			}

			pointsToDistribute -= pointsDistributed;
		}
	}

	public void newQuestion(){
		this.gameObject.SetActive (true);
		resetQuiz ();

		showQuiz (GameStateManager.Instance.newQuestionDifficulty );	
		GameStateManager.Instance.setGameState (GameStateManager.GameState.GameQuiz);
	}

	private void resetQuiz() {
		isPlayerRight = false;
		playerAnswered = false;
		finishedAnimation = 0;

		for (int i = 0; i < buttonCanRotate.Count; i++) {
			buttonCanRotate [i] = false;
			buttons [i].GetComponent<Collider2D> ().enabled = true;
			buttons [i].GetComponent<RectTransform> ().localRotation = Quaternion.Euler(new Vector3(0f,0f,0f));
			buttons [i].GetComponent<Image> ().sprite = buttonFront [i];
			buttonChangedSprite [i] = false;
		}
	}

	public void playerAnswer(bool answer) {
		if (answer == questionAnswer) {
			isPlayerRight = true;

		} else {
			isPlayerRight = false;

		}

		for (int i = 0; i < buttonCanRotate.Count; i++) {
			buttonCanRotate [i] = true;
			buttons [i].GetComponent<Collider2D> ().enabled = false;
		}

		playerAnswered = true;
	}
}
