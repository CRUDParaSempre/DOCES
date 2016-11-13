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

	// Use this for initialization
	void Start () {
		rt = GetComponent<RectTransform> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void fillCards() {
		foreach (GameObject card in cards) {
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

			string type = randomizeType();
			int id = randomizeId();

			setCardStyle (card, type);

			//preenche o nome que é o primeiro filho do primeiro filho da carta
			cardTexts[0].text = csvManager.getName(type,id);
			cardTexts [0].color = cardColors [cardNameToId(type)];

			cardTexts [1].text = csvManager.getDescription (type,id);
			cardTexts [2].text = "+" + csvManager.getBonus(type,id) + " em " + type;
			cardTexts [3].text = csvManager.getCreativity (type,id);
			cardTexts [4].text = csvManager.getLogic(type,id);
			cardTexts [5].text = csvManager.getOrganization(type,id);
			cardTexts [6].text = abreviateMoney(csvManager.getMoney (type,id));
		}
	}

	private string randomizeType() {
		return "Desenvolvimento";
	}

	private int randomizeId () {
		return 2;
	}

	private string abreviateMoney(string price) {
		Debug.Log (price);
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
}
