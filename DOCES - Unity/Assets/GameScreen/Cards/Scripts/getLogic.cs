using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class getLogic : MonoBehaviour {

	public Text cardLogic;
	public Cards_CSV cardTable;
	public int id;


	// Use this for initialization
	void Start () {

		cardLogic = GetComponent<Text> ();
		cardLogic.text = cardTable.getLogic ("Requisitos", id);
		Debug.Log (cardLogic.text);
	}

	// Update is called once per frame
	void Update () {

	}
}
