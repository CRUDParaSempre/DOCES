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
	[SerializeField] private List<RectTransform> projectAreasGoalMarker=null;

	[SerializeField]private int minGoalMarkerX=21;
	[SerializeField]private int maxGoalMarkerX=390;

	[SerializeField] private float timeBetweenAnimation = 0f;
	private float lastAnimationTime;
	private float firstAnimationTime;
	[SerializeField] private float timeOfAnimation = 0f;

	private int distance = 0;
	private float animVelocity = 1f;

	private int currentProjectArea = 0;

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
		projectAreasFillBars [currentProjectArea].fillAmount += animVelocity * Time.deltaTime;
		changeProjectArea ();
		recalculateAnimVelocity ();
	}

	private void changeProjectArea() {
		if (projectAreasFillBars [currentProjectArea].fillAmount > distance / GameStateManager.Instance.projectMaxGoals [currentProjectArea] - .001f) {
			currentProjectArea++;
			calculateDistance ();
		}
	}

	private void recalculateAnimVelocity() {
		animVelocity = Mathf.Lerp (((float)distance/timeOfAnimation), 0, (Time.time - firstAnimationTime)/timeOfAnimation );
		Debug.Log ("Velocidade " + animVelocity);
	}

	private void calculateDistance() {
		distance = 0;
		for (int i = 0; i < GameStateManager.Instance.projectScores [currentProjectArea].Count; i++) {
			distance += GameStateManager.Instance.projectScores [currentProjectArea] [i];
		}

		recalculateAnimVelocity ();
		Debug.Log ("Distance to walk " + distance + " in " + currentProjectArea);
	}

	public void showProjectResults() {
		resetCanvas ();

		clientNameUI.text = GameStateManager.Instance.clientName;
		paymentUI.text = "G$ +" + (GameStateManager.Instance.projectPayment.ToString());

		GameStateManager.Instance.calculateProjectGoals ();

		for (int i = 0 ; i < GameStateManager.Instance.projectGoals.Count ; i++) {
			float percentage = (float)GameStateManager.Instance.projectGoals[i]/(float)GameStateManager.Instance.projectMaxGoals[i];
			Vector3 newPos = new Vector3 (Mathf.Lerp(minGoalMarkerX,maxGoalMarkerX,percentage), 0f, 0f);

			projectAreasGoalMarker [i].localPosition = newPos;
		}


		calculateDistance ();

		this.gameObject.SetActive (true);
		firstAnimationTime = Time.time;
	}

	private void resetCanvas() {
		clientNameUI.text = "Sem Cliente";
		paymentUI.text = "G$ + 0,00";
		credibilityUI.text = "+0";

		foreach(Image i in projectAreasFillBars) {
			i.fillAmount = 0f;
		}

		foreach(Image i in projectAreasGoalAchieved) {
			Color temp = i.color;
			temp.a = 0f;
			i.color = temp;
		}

	}
}
