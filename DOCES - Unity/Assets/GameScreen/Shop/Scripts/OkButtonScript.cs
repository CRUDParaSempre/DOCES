using UnityEngine;
using System.Collections;

public class OkButtonScript : MonoBehaviour {

	public BoardScript _boardScript;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseDown() {
		Debug.Log ("botao ok");
		_boardScript.compraItem ();
	}
}
