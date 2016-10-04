using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DropdownMenu : MonoBehaviour {
	[SerializeField] private List<GameObject> dropdownMenuButtonsPrefabs = new List<GameObject>();
	private List<GameObject> instantiatedDropdownButtons = new List<GameObject>();


	// Use this for initialization
	void Start () {
		foreach (GameObject go in dropdownMenuButtonsPrefabs) {
			instantiatedDropdownButtons.Add( Instantiate (go) );
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
