using UnityEngine;
using System.Collections;

public class ReturnToHome : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void saveGameState(){

	}

	public void returnToHomeAction(){
		saveGameState ();
		Camera.main.GetComponent <SetCameraPosition>().setCameraPosition(0, 600, -10);
	}
}
