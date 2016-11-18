//Created by Marcelo Gomes  | Revised by: Mariana Silva
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ClientManager : MonoBehaviour {
	[SerializeField] private Text titleText=null;
	[SerializeField] private Text descriptionText=null;
	[SerializeField] private Image previousButton=null;
	[SerializeField] private Image nextButton=null;
	[SerializeField] private Image acceptButton=null;
	[SerializeField] private Image denyButton=null;

	[SerializeField] private Project_CSV projectCSV = null;

	[SerializeField] private string clientName = null;
	[SerializeField] private List<Sprite> clientImages = null;
	[SerializeField] private Image canvasClientImage = null;
	private int clientImageID = 0;

	[SerializeField] private int _deadline = 0;
	public int deadline {
		get { return _deadline; }
	}

	[SerializeField] private int _payment = 0;
	public int payment {
		get { return _payment ;}
	}

	[SerializeField] private string _difficulty = null;
	public string difficulty {
		get {  return _difficulty; }
	}

//	[SerializeField] private List<float> difficultyRatio = null;
//	[SerializeField] private List<int> maxGoals = null;
//	[SerializeField] private List<int> _goals = null;
//	public List<int> goals {
//		get {  return _goals; }
//	}

	private List<string> projectTexts = new List<string>();
	private int index=0;

	private Color halfTransparent = new Color(1f,1f,1f,.5f);
	private Color opaque = new Color(1f,1f,1f,1f);


	// Use this for initialization
	void Start () {

	}

	void Awake() {
		
	}

	// Update is called once per frame
	void Update () {

	}

	public void showClient(string difficulty) {
		randomizeClientByDifficulty (difficulty);

		//initialize client image
		canvasClientImage.sprite = clientImages[clientImageID];

		//initialize text
		descriptionText.text = projectTexts [0];
		titleText.text = clientName;

		//make last page (project information)
		projectTexts.Add("Cliente: "+ clientName +".\nDificuldade: " + difficulty + ".\nPrazo de entrega: " + deadline + " semanas.\nPagamento: G$ " + GameStateManager.Instance.moneyToString(payment) );

		//make previous tip unavailable
		previousButton.color = halfTransparent;
		previousButton.gameObject.GetComponent<CircleCollider2D> ().enabled = false;

		//make previous tip available
		nextButton.color = opaque;
		nextButton.gameObject.GetComponent<CircleCollider2D> ().enabled = true;

		//hide accept/deny buttons
		acceptButton.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
		acceptButton.gameObject.SetActive (false);

		denyButton.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
		denyButton.gameObject.SetActive (false);

		this.gameObject.SetActive (true);
	}

	public void nextPage() {
		// 0  , 1 , 2
		// pg1,pg2,pg2
		// index=1

		//there is more than one page to show
		if (++index < projectTexts.Count-1) {
			descriptionText.text = projectTexts [index];
			previousButton.color = opaque;
			previousButton.gameObject.GetComponent<CircleCollider2D> ().enabled = true;

		//showing last page
		} else {
			descriptionText.text = projectTexts [index];
			titleText.text = "Detalhes do Contrato";

			previousButton.color = opaque;
			previousButton.gameObject.GetComponent<CircleCollider2D> ().enabled = true;

			nextButton.color = halfTransparent;
			nextButton.gameObject.GetComponent<CircleCollider2D> ().enabled = false;

			acceptButton.gameObject.GetComponent<CircleCollider2D> ().enabled = true;
			acceptButton.gameObject.SetActive (true);
			denyButton.gameObject.GetComponent<CircleCollider2D> ().enabled = true;
			denyButton.gameObject.SetActive (true);
		}
	}

	public void previousPage() {

		//is showing last page, need to hide the buttons
		if( index-- == projectTexts.Count-1 ) {
			descriptionText.text = projectTexts [index];
			titleText.text = clientName;

			previousButton.color = opaque;
			previousButton.gameObject.GetComponent<CircleCollider2D> ().enabled = true;

			nextButton.color = opaque;
			nextButton.gameObject.GetComponent<CircleCollider2D> ().enabled = true;

			acceptButton.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
			acceptButton.gameObject.SetActive (false);

			denyButton.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
			denyButton.gameObject.SetActive (false);

		//there is a previous tip to show
		} else if (index > 0) {
				descriptionText.text = projectTexts [index];

		//we are at the first page
		} else {
			descriptionText.text = projectTexts [index];
			previousButton.color = halfTransparent;
			previousButton.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
		}
	}

	public void testClient() {
		showClient ("Baixa");
	}

//	private void determineDifficulty() {
//		if (difficulty.ToLower ().CompareTo ("baixa") == 0) {
//			for (int i = 0; i < maxGoals.Count; i++) {
//				_goals [i] = (int)Mathf.Round(maxGoals [i] * difficultyRatio [0]);
//			}
//
//		} else if (difficulty.ToLower ().CompareTo ("média") == 0) {
//			for (int i = 0; i < maxGoals.Count; i++) {
//				_goals [i] = (int)Mathf.Round(maxGoals [i] * difficultyRatio [1]);
//			}
//
//		} else if (difficulty.ToLower ().CompareTo ("alta") == 0) {
//			for (int i = 0; i < maxGoals.Count; i++) {
//				_goals [i] = (int)Mathf.Round(maxGoals [i] * difficultyRatio [2]);
//			}
//
//		} else if (difficulty.ToLower ().CompareTo ("altíssima") == 0) {
//			for (int i = 0; i < maxGoals.Count; i++) {
//				_goals [i] = (int)Mathf.Round(maxGoals [i] * difficultyRatio [3]);
//			}
//
//		}
//	}

//	private string moneyToString(int payment) {
//		string parsing = payment.ToString ();
//		string reverseResult = "00,";
//		int count = 0;
//		//3210
//		//2000
//		for (int i = parsing.Length-1 ; i >= 0 ; i--) {
//			if (count++ % 3 == 0 && i !=parsing.Length-1 ) {
//				reverseResult += ("." + parsing [i]);
//			} else {
//				reverseResult += parsing [i];
//			}
//		}
//
//		string result = "";
//		for (int i = reverseResult.Length - 1; i >= 0; i--) {
//			result += reverseResult [i];
//		}
//
//		return result;
//	}

	public void acceptClient() {
//		determineDifficulty ();

		GameStateManager.Instance.newClientAccepted(clientName,deadline,payment, _difficulty);
		this.gameObject.SetActive (false);
	}

	public void rejectedClient() {
		GameStateManager.Instance.newClientRejected ();
		this.gameObject.SetActive (false);
	}

	public void randomizeClientByDifficulty(string difficulty){
		projectCSV.Load (projectCSV.file);

		int random = Random.Range (0,4);
		List<string> infos = projectCSV.getInfo (difficulty, random);

		clientImageID = int.Parse (infos[0]);

		clientName = infos [1];

		projectTexts.Clear ();
		projectTexts.Add(infos[2]);
		projectTexts.Add(infos[3]);

		index = 0;
		_difficulty = difficulty;
		_payment = int.Parse (infos [4]);
		_deadline = int.Parse (infos [5]);

	}
		
	public void OnEnable(){
		showClient (GameStateManager.Instance.newClientDifficulty);	
		GameStateManager.Instance.setGameState (GameStateManager.GameState.GameClient);
	}
}

//currentWeek = 1
//projectDeadline = currentWeek + 5; (6)
//sprint1 semana1
//seprint2 semana2
//sprinte3 semana3
//sprint4 semana4
//sprint5 semana5
//semana 6 entrega