using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class getMoney : MonoBehaviour {

	public Text cardMoney;
	public Cards_CSV cardTable;
	public int id;


	// Use this for initialization
	void Start () {

		cardMoney = GetComponent<Text> ();
		cardMoney.text = cardTable.getMoney ("Requisitos", id);
		Debug.Log (cardMoney.text);
	}

	// Update is called once per frame
	void Update () {

	}
}
