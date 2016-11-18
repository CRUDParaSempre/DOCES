using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AbilitiesManager : MonoBehaviour {
	[SerializeField] private List<int> originalStats;
	[SerializeField] private List<int> currentStats;
	[SerializeField] private Color original = new Color(); 
	[SerializeField] private Color reduced = new Color(); 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void initialUpdateTexts() {
		originalStats[0] = GameStateManager.Instance.creativity;
		originalStats[1] = GameStateManager.Instance.logic;
		originalStats[2] = GameStateManager.Instance.organization;
		originalStats[3] = GameStateManager.Instance.golpinhos;

		for (int i = 0 ; i < originalStats.Count ; i++) {
			currentStats [i] = originalStats [i];
		}

		updateTexts ();

	}

	private void updateTexts() {
		Text[] abilities = GetComponentsInChildren<Text>();

		for (int i = 0; i < currentStats.Count-1; i++) {
			abilities [i].text = currentStats [i].ToString ();

			if (currentStats [i] < originalStats [i]) {
				abilities [i].color = reduced;
			} else {
				abilities [i].color = original;
			}
		}

		abilities [3].text = CardsManager.abreviateMoney( currentStats [3].ToString () );
		Debug.Log ("GOLPINHOS: " + abilities [3].text);
		if (currentStats [3] < originalStats [3]) {
			abilities [3].color = reduced;
		} else {
			abilities [3].color = original;
		}
	}

	public void OnEnable() {
		initialUpdateTexts ();
	}

	public bool canSelectCard(List<int> costs) {
		for (int i = 0; i < currentStats.Count; i++) {
			if (currentStats [i] - costs [i] < 0) {
				return false;
			}
		}

		return true;
	}

	public void cardSelected(List<int> costs) {
		for (int i = 0; i < currentStats.Count; i++) {
			currentStats [i] -= costs [i];
		}

		updateTexts ();
	}

	public void cardDeselected(List<int> costs) {
		for (int i = 0; i < currentStats.Count; i++) {
			currentStats [i] += costs [i];
		}

		updateTexts ();
	}
}
