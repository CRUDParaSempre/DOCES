using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class getCreativity : MonoBehaviour {

	public Text cardCreativity;
	public Cards_CSV cardTable;
	public int id;


	// Use this for initialization
	void Start () {

		cardCreativity = GetComponent<Text> ();
		cardCreativity.text = cardTable.getCreativity ("Requisitos", id);
		Debug.Log (cardCreativity.text);
	}

	// Update is called once per frame
	void Update () {

	}
}
