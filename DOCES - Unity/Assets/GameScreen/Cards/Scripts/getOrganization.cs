using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class getOrganization : MonoBehaviour {

	public Text cardOrganization;
	public Cards_CSV cardTable;
	public int id;


	// Use this for initialization
	void Start () {

		cardOrganization = GetComponent<Text> ();
		cardOrganization.text = cardTable.getOrganization ("Requisitos", id);
		Debug.Log (cardOrganization.text);
	}

	// Update is called once per frame
	void Update () {

	}
}
