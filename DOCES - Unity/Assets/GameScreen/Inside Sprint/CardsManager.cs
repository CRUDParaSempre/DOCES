//Created by Marcelo Gomes  | Revised by: Mariana Silva
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CardsManager : MonoBehaviour {
	[SerializeField] private List<int> numberOfCardsPerType = null; // 0 = requisitos, 1 = analise, 2 = desenho, 3 = desenvolvimento, 4 = testes
	[SerializeField] private Cards_CSV csvManager = null;
	[SerializeField] private List<GameObject> cards = null;
	[SerializeField] private List<Sprite> cardBacks = null;
	[SerializeField] private List<Sprite> cardFronts = null;
	[SerializeField] private List<Color> cardColors = null;
	private RectTransform rt;
	[SerializeField] private List<int> cardTypes = new List<int>();

	[SerializeField] private List<float> typeChance = new List<float> ();

	// Use this for initialization
	void Start () {
		rt = GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void fillCards() {
		fillPool ();

		shuffleType (100);

		for(int i=0; i < cards.Count; i++) {
			GameObject card = cards [i];
			GameObject cardBackground = (card.GetComponent<RectTransform> ().GetChild (0)).gameObject;

			List<Text> cardTexts = new List<Text>(); //0 = name, 1 = description, 2 = bonus, 3 = criCost, 4 = logCost, 5 = orgCost, 6 = golCost
			foreach ( RectTransform rct in cardBackground.GetComponent<RectTransform>()) {
				Text t = rct.gameObject.GetComponent<Text> ();
					
				if (t != null) {
					cardTexts.Add(t);
				}

				foreach ( RectTransform rct2 in rct.gameObject.GetComponent<RectTransform>()) {
					t = rct2.GetChild(0).gameObject.GetComponent<Text> ();

					if (t != null) {
						cardTexts.Add(t);
					}
				}
			}

			card.GetComponent<CardClickManager> ().type = idToCardName (cardTypes [i]);

			int id = randomizeId(idToCardName(cardTypes[i]));
			setCardStyle (card, idToCardName(cardTypes[i]));

			//preenche o nome que é o primeiro filho do primeiro filho da carta
			cardTexts[0].text = csvManager.getName(idToCardName(cardTypes[i]),id);
			cardTexts [0].color = cardColors [cardNameToId(idToCardName(cardTypes[i]))];

			List<int> costs = new List<int> ();
			costs.Add (int.Parse( csvManager.getCreativity (idToCardName (cardTypes [i]), id)));
			costs.Add (int.Parse( csvManager.getLogic (idToCardName (cardTypes [i]), id)));
			costs.Add (int.Parse( csvManager.getOrganization (idToCardName (cardTypes [i]), id)));
			costs.Add (int.Parse( csvManager.getMoney (idToCardName (cardTypes [i]), id)));

			card.GetComponent<CardClickManager> ().costs = costs;

			cardTexts [2].text = "+" + csvManager.getBonus(idToCardName(cardTypes[i]),id) + " em " + idToCardName(cardTypes[i]);
			card.GetComponent<CardClickManager> ().bonusValue = int.Parse( csvManager.getBonus (idToCardName (cardTypes [i]), id));

			GameStateManager.Instance.projectMaxGoals [cardTypes [i]] += card.GetComponent<CardClickManager> ().bonusValue;

			cardTexts [1].text = csvManager.getDescription (idToCardName(cardTypes[i]),id);
			cardTexts [3].text = costs[0].ToString();
			cardTexts [4].text = costs[1].ToString();
			cardTexts [5].text = costs[2].ToString();
			cardTexts [6].text = abreviateMoney(costs[3].ToString());
		}
	}


	private void shuffleType(int changes){
		int temp = 0;
		int index1, index2;
		for (int i = 0; i < changes; i++) {
			index1 = Random.Range (0, cardTypes.Count);
			index2 = Random.Range (0, cardTypes.Count);

			temp = cardTypes [index1];
			cardTypes [index1] = cardTypes [index2];
			cardTypes [index2] = temp;
		}
		
	}

	private int randomizeId (string type) {
		if (type.ToLower().CompareTo("requisitos") == 0) {
			return Random.Range (0, numberOfCardsPerType [0]);
		} else if (type.ToLower().CompareTo("análise") == 0) {
			return Random.Range (0, numberOfCardsPerType [1]);
		} else if (type.ToLower().CompareTo("desenho") == 0) {
			return Random.Range (0, numberOfCardsPerType [2]);
		} else if (type.ToLower().CompareTo("desenvolvimento") == 0) {
			return Random.Range (0, numberOfCardsPerType [3]);
		} else if (type.ToLower().CompareTo("testes") == 0) {
			return Random.Range (0, numberOfCardsPerType [4]);
		}
		Debug.LogError ("Tipo de carta inválido!");
		return 0;
	}

	public static string abreviateMoney(string price) {
		string result = "";

		if (price.Length == 4) {
			if (int.Parse (price.ToString())%1000 > 0) {
				result =  ("+" + price[0].ToString() + "K");
			
			} else {
				result = (price[0].ToString() + "K");
			}

		} else if (price.Length == 5) {
			if (int.Parse (price.ToString ()) % 10000 > 0) {
				result =  ("+" + price [0].ToString () + price [1].ToString () + "K");
			} else {
				result =  (price [0].ToString () + price [1].ToString () + "K");
			}
		} else if (price.Length < 4) {
			result =  price;
		}

		if (result.Length == 0) {
			Debug.LogError ("Valor nao válido");
		}

		return result;
	}

	private void setCardStyle(GameObject card, string typeId) {
		GameObject cardBackgroud = card.GetComponent<RectTransform> ().GetChild (0).gameObject;
		int index = cardNameToId(typeId);

		cardBackgroud.GetComponent<Image> ().sprite = cardBacks [index];
		cardBackgroud.GetComponentInParent<CardClickManager> ().setFrontSprite (cardFronts [index]);
	}

	private int cardNameToId(string typeId) {
		int index = 0;

		if (typeId.ToLower ().CompareTo ("requisitos") == 0) {
			index = 0;
		} else if (typeId.ToLower ().CompareTo ("análise") == 0) {
			index = 1;
		} else if (typeId.ToLower ().CompareTo ("desenho") == 0) {
			index = 2;
		} else if (typeId.ToLower ().CompareTo ("desenvolvimento") == 0) {
			index = 3;
		} else if (typeId.ToLower ().CompareTo ("testes") == 0) {
			index = 4;
		}

		return index;
	}


	private string idToCardName(int id){
		switch (id) {
			case 0:
				return "Requisitos"; 
			case 1:
				return "Análise";
			case 2:
				return "Desenho";
			case 3:
				return "Desenvolvimento";
			case 4:
				return "Testes";

		default:
			Debug.LogError ("Id inválido!");
				return "";		
		}

	}


	private void fillPool(){
		float currentWeek = (float)GameStateManager.Instance.currentWeek - (float)GameStateManager.Instance.projectStartWeek;
		float projectDeadline = (float)GameStateManager.Instance.projectDeadline - (float)GameStateManager.Instance.projectStartWeek;
		float projectPercentage = currentWeek / projectDeadline;
		int cardCount = 0;
		int cardCountTotal = 0;

		typeChance[0] = (projectPercentage < .4) ? (-10f/4f)*projectPercentage + 1 : 0; //requisitos
		typeChance[1] = (projectPercentage < .3) ? (projectPercentage*5f/3f + 0.5f) : Mathf.Max((-5f*projectPercentage + 5f/2f), 0f); //análise
		typeChance[2] = (projectPercentage < .5) ? (projectPercentage*8f/5f + 0.2f) : Mathf.Max((-10f*projectPercentage + 6f), 0f); //desenho
		typeChance[3] = (projectPercentage < .65) ? Mathf.Max((projectPercentage*4f - 8f/5f), 0f) : (-17f/7f*projectPercentage + 361f/140f); //desenvolvimento
		typeChance[4] = (projectPercentage < .85) ? Mathf.Max((projectPercentage*20f/7f - 10f/7f), 0f) : 1f; //testes


		normalizeChances ();
		Debug.Log (typeChance[0]*100 + "% " + typeChance[1]*100 + "% " + typeChance[2]*100 + "% " + typeChance[3]*100 + "% " + typeChance[4]*100 + "%");

		for (int i = 0; i < typeChance.Count; i++) {	
			cardCount = 0;
			for (int j = cardCount; j < Mathf.Floor(typeChance[i]*10); j++){
				cardTypes[cardCountTotal] = i;
				cardCount++;
				cardCountTotal++;
			}

		}

		for (int i = cardCountTotal; i < cardTypes.Count; i++){
			float random = Random.value;

			if (random >= 0 && random < typeChance [0]) {
				cardTypes [i] = 0;			
			} else if (random >= typeChance [0] && random < typeChance[0] + typeChance[1]) { 
				cardTypes [i] = 1;			
			} else if (random >= typeChance[0] + typeChance[1] && random < typeChance[0] + typeChance[1] + typeChance[2]) {
				cardTypes [i] = 2;			
			} else if (random >= typeChance[0] + typeChance[1] + typeChance[2] && random < typeChance[0] + typeChance[1] + typeChance[2] + typeChance[3]) {
				cardTypes [i] = 3;			
			} else if (random >= typeChance[0] + typeChance[1] + typeChance[2] + typeChance[3] && random < typeChance[0] + typeChance[1] + typeChance[2] + typeChance[3] + typeChance[4]) {
				cardTypes [i] = 4;			
			}else {
			}
		}
	}

	private float crossMultiplication(float a, float b){
	
		return b / a;
	
	}

	private void normalizeChances(){
		float sum = 0;

		for (int i = 0; i < typeChance.Count; i++) {
			sum += typeChance [i];
		
		}

		for (int i = 0; i < typeChance.Count; i++) {

			typeChance [i] = crossMultiplication (sum, typeChance[i]);

		}

	}

	public void distributeProjectScores() {
		for (int i = 0; i < cards.Count; i++) {
			GameObject card = cards [i];
			CardClickManager manager = card.GetComponent<CardClickManager> ();


			if (manager.cardState == CardClickManager.CardState.Selected || manager.cardState == CardClickManager.CardState.SelectedAndZoomed	) {
				Debug.Log ("Card " + i + " " + manager.type);
				GameStateManager.Instance.addProjectScores (manager.bonusValue,manager.type);
			}
		}
	}
}
