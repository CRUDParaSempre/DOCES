using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class getName : MonoBehaviour {

	public Text cardName;
	public Cards_CSV cardTable;


	// Use this for initialization
	void Start () {

		cardName = GetComponent<Text> ();
		cardName.text = cardTable.Find_Nome_da_carta ("Casos de Uso").Nome_da_carta;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
