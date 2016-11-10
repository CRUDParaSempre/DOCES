using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class getDescription : MonoBehaviour {

	public Text cardDescription;
	public Cards_CSV cardTable;
	public int id;


	// Use this for initialization
	void Start () {

		cardDescription = GetComponent<Text> ();
		cardDescription.text = cardTable.getDescription ("Requisitos", id);
		Debug.Log (cardTable.getDescription ("Requisitos", id));
	}

	// Update is called once per frame
	void Update () {

	}
}
