using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class getBonus : MonoBehaviour {

	public Text cardBonus;
	public Cards_CSV cardTable;
	public int id;


	// Use this for initialization
	void Start () {

		cardBonus = GetComponent<Text> ();
		cardBonus.text = "+" + cardTable.getBonus ("Requisitos", id) + " Bonus";
		Debug.Log (cardBonus.text);
	}

	// Update is called once per frame
	void Update () {

	}
}
