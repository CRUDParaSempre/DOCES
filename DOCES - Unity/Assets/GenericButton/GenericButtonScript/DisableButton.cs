using UnityEngine;
using System.Collections;

public class DisableButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnDisable() {
		this.gameObject.SetActive (false);
	}
}
