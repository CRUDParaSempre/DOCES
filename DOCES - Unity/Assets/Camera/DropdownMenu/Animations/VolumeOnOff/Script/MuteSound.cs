using UnityEngine;
using System.Collections;



public class MuteSound : MonoBehaviour {
	// Use this for initialization
	void Start () {
		AudioListener.pause = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void MuteAudioFunction(){				
		AudioListener.pause = !AudioListener.pause;
	}
}
