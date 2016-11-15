using UnityEngine;
using System.Collections;

public class ObjectButtonScript : MonoBehaviour {

	public BoardScript _boardScript;
	public int index;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseDown() {
		_boardScript.selecionaItem (index);
	}
}
