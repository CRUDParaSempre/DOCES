using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class getName : MonoBehaviour {

	public Text cardName;
	public Cards_CSV cardTable;
	public int id;


	// Use this for initialization
	void Start () {

		cardName = GetComponent<Text> ();
		cardName.text = cardTable.getName ("Requisitos", id);
		Debug.Log (cardName.text);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
