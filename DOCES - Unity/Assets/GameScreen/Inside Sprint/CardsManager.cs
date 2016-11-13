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

			int id = randomizeId(idToCardName(cardTypes[i]));
			setCardStyle (card, idToCardName(cardTypes[i]));

			//preenche o nome que é o primeiro filho do primeiro filho da carta
			cardTexts[0].text = csvManager.getName(idToCardName(cardTypes[i]),id);
			cardTexts [0].color = cardColors [cardNameToId(idToCardName(cardTypes[i]))];

			cardTexts [1].text = csvManager.getDescription (idToCardName(cardTypes[i]),id);
			cardTexts [2].text = "+" + csvManager.getBonus(idToCardName(cardTypes[i]),id) + " em " + idToCardName(cardTypes[i]);
			cardTexts [3].text = csvManager.getCreativity (idToCardName(cardTypes[i]),id);
			cardTexts [4].text = csvManager.getLogic(idToCardName(cardTypes[i]),id);
			cardTexts [5].text = csvManager.getOrganization(idToCardName(cardTypes[i]),id);
			cardTexts [6].text = abreviateMoney(csvManager.getMoney (idToCardName(cardTypes[i]),id));
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

	private string abreviateMoney(string price) {
		if (price.Length == 4) {
			return (price[0].ToString() + "K");

		} else if (price.Length == 5) {
			return (price[0].ToString() + price[1].ToString() + "K");
		} else if (price.Length < 4) {
			return price;
		}

		Debug.LogError ("Valor nao válido");
		return "";
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
		float currentWeek = (float)GameStateManager.Instance.currentWeek;
		float projectDeadline = (float)GameStateManager.Instance.projectDeadline;
		float projectPercentage = currentWeek / projectDeadline;
		int cardCount = 0;
		int cardCountTotal = 0;

		typeChance[0] = (projectPercentage < .4) ? (-10f/4f)*projectPercentage + 1 : 0; //requisitos
		typeChance[1] = (projectPercentage < .3) ? (projectPercentage*5f/3f + 0.5f) : Mathf.Max((-5f*projectPercentage + 5f/2f), 0f); //análise
		typeChance[2] = (projectPercentage < .5) ? (projectPercentage*8f/5f + 0.2f) : Mathf.Max((-10f*projectPercentage + 6f), 0f); //desenho
		typeChance[3] = (projectPercentage < .65) ? Mathf.Max((projectPercentage*4f - 8f/5f), 0f) : (-20f/7f*projectPercentage + 20f/7f); //desenvolvimento
		typeChance[4] = (projectPercentage < .85) ? Mathf.Max((projectPercentage*20f/7f - 10f/7f), 0f) : 1f; //testes

		Debug.Log (typeChance[0] + " " + typeChance[1] + " " + typeChance[2] + " " + typeChance[3] + " " + typeChance[4]);

		normalizeChances ();

		for (int i = 0; i < typeChance.Count; i++) {	
			cardCount = 0;
			for (int j = cardCount; j < Mathf.Floor(typeChance[i]*10); j++){

				cardTypes[j] = i;
				cardCount++;
				cardCountTotal++;
			}

		}

		for (int i = cardCountTotal; i < cards.Count; i++){
			float random = Random.value;

			if (random < typeChance [0]) {
				cardTypes [i] = 0;			
			} else if (random >= typeChance [0] && random < typeChance[0] + typeChance[1]) {
				cardTypes [i] = 1;			
			} else if (random >= typeChance[0] + typeChance[1] && random < typeChance[0] + typeChance[1] + typeChance[2]) {
				cardTypes [i] = 2;			
			} else if (random >= typeChance[0] + typeChance[1] + typeChance[2] && random < typeChance[0] + typeChance[1] + typeChance[2] + typeChance[3]) {
				cardTypes [i] = 3;			
			} else if (random >= typeChance[0] + typeChance[1] + typeChance[2] + typeChance[3] && random < typeChance[0] + typeChance[1] + typeChance[2] + typeChance[3] + typeChance[4]) {
				cardTypes [i] = 4;			
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

}
