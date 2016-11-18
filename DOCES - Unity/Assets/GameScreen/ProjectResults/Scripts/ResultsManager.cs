//Created by Marcelo Gomes  | Revised by: Mariana Silva
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ResultsManager : MonoBehaviour {
	[SerializeField] private Text clientNameUI=null;
	[SerializeField] private Text paymentUI=null;
	[SerializeField] private Text credibilityUI=null;
	[SerializeField] private List<Image> projectAreasFillBars=null;
	[SerializeField] private List<Image> projectAreasGoalAchieved=null;
	[SerializeField] private List<Sprite> resultIcons;
	[SerializeField] private List<Color> resultIconColors;
	[SerializeField] private List<RectTransform> projectAreasGoalMarker=null;

	[SerializeField]private int minGoalMarkerX=21;
	[SerializeField]private int maxGoalMarkerX=390;

	[SerializeField] private AudioSource computingSound=null;
	[SerializeField] private AudioSource correctSound=null;
	[SerializeField] private AudioSource wrongSound=null;
	[SerializeField] private float timeBetweenAudios=.5f;
	private float realTimeBetweenAudios=0f;
	private float lastAudioTime=0f;

	[SerializeField] private float timeBetweenAnimation = 0f;
	[SerializeField] private float timeOfAnimation = 0f;
	private float lastAnimationTime=0f;
	private float firstAnimationTime=0f;


	private float distance = 0f;
	private float animVelocity = 1f;

	private int currentProjectArea = 0;
	private bool animationFinished = false;
	private bool resultsFinished = false;
	private int count = 0;
	private int payment;
	private int credibility;
	private List<int> finalScores = new List<int>();
	public GameObject readyButton;

	//distancia/tempo 	|\
	//  				| \
	//  				|  \
	//  				|   \
	//  				|    \
	//  				|     \
	//  				|______\
	//  				0      5

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!animationFinished) {
			projectAreasFillBars [currentProjectArea].fillAmount += animVelocity * Time.deltaTime;
			changeProjectArea ();
			recalculateAnimVelocity ();
		}

		if ((Time.time - firstAnimationTime) > 0 && !computingSound.isPlaying && currentProjectArea < GameStateManager.Instance.projectGoals.Count) {
			computingSound.Play ();
			animationFinished = false;
			firstAnimationTime = Time.time;
			calculateDistance ();
		}
			
	}

	private void changeProjectArea() {
		if (projectAreasFillBars [currentProjectArea].fillAmount >= distance ) {
			animationFinished = true;
			computingSound.Stop();

			//consegui passar a meta
			if (distance * GameStateManager.Instance.projectMaxGoals [currentProjectArea] > GameStateManager.Instance.projectGoals [currentProjectArea]) {
				projectAreasGoalAchieved [currentProjectArea].sprite = resultIcons [0];
				projectAreasGoalAchieved [currentProjectArea].color = resultIconColors[0];
				count++;
				correctSound.Play();

			} else {
				projectAreasGoalAchieved [currentProjectArea].sprite = resultIcons [1];
				projectAreasGoalAchieved [currentProjectArea].color = resultIconColors[1];
				wrongSound.Play();
			}


			if (++currentProjectArea == GameStateManager.Instance.projectGoals.Count) {
				calculateCredibility ();
				readyButton.SetActive (true);

			}
	
			firstAnimationTime = Time.time + 1f;
		}
	}

	private void calculateCredibility() {
		int bonus = (int)Mathf.Round( Mathf.Lerp (-10,10, (float)count / (float)GameStateManager.Instance.projectGoals.Count) );
		credibility = bonus;

		if (bonus >= 0) {
			credibilityUI.text = "+" + bonus.ToString ();
		} else {
			credibilityUI.text = bonus.ToString ();
		}

	}

	private void recalculateAnimVelocity() {
		animVelocity = Mathf.Lerp ( ((float)distance/ Mathf.Max((timeOfAnimation - ( Time.time - firstAnimationTime )), 0.01f)) , 0.001f, (Time.time - firstAnimationTime)/timeOfAnimation );
		realTimeBetweenAudios = Mathf.Lerp(0.001f, ((float)distance/ Mathf.Max((timeOfAnimation - ( Time.time - firstAnimationTime )), 0.01f)), (Time.time - firstAnimationTime) / timeOfAnimation);
//		Debug.Log ("Velocidade " + animVelocity + " [" + ((float)distance/timeOfAnimation) + ",0," + (Time.time - firstAnimationTime) +"/"+timeOfAnimation + "] " + Time.time);
	}

	private void calculateDistance() {
		distance = 0f;

		for (int i = 0; i < GameStateManager.Instance.projectScores [currentProjectArea].Count; i++) {
			distance += GameStateManager.Instance.projectScores [currentProjectArea] [i];
		}

		finalScores.Add ( (int)distance);
		distance /= GameStateManager.Instance.projectMaxGoals [currentProjectArea];
		Debug.Log ("Distance to walk " + distance + " in " + currentProjectArea);

//		distance = .5f;

		recalculateAnimVelocity ();

	}

	public void showProjectResults() {
		resetCanvas ();

		clientNameUI.text = GameStateManager.Instance.clientName;
		payment = GameStateManager.Instance.projectPayment;
		paymentUI.text = "G$ +" + (GameStateManager.Instance.moneyToString(payment));

		GameStateManager.Instance.calculateProjectGoals ();

		for (int i = 0 ; i < GameStateManager.Instance.projectGoals.Count ; i++) {
			float percentage = (float)GameStateManager.Instance.projectGoals[i]/(float)GameStateManager.Instance.projectMaxGoals[i];
			Vector3 newPos = new Vector3 (Mathf.Lerp(minGoalMarkerX,maxGoalMarkerX,percentage), 0f, 0f);

			projectAreasGoalMarker [i].localPosition = newPos;
		}


		firstAnimationTime = Time.time;
		calculateDistance ();

		this.gameObject.SetActive (true);
	}

	private void resetCanvas() {
		clientNameUI.text = "Sem Cliente";
		paymentUI.text = "G$ + 0,00";
		credibilityUI.text = "+0";
		count = 0;

		foreach(Image i in projectAreasFillBars) {
			i.fillAmount = 0f;
		}

		foreach(Image i in projectAreasGoalAchieved) {
			Color temp = i.color;
			temp.a = 0f;
			i.color = temp;
		}

	}

//	public void OnEnable() {
//		resetCanvas ();
//
//		firstAnimationTime = Time.time;
//		calculateDistance ();
//	}

	public void closeResults() {
		GameStateManager.Instance.finalResults (payment, credibility);
	}
}
