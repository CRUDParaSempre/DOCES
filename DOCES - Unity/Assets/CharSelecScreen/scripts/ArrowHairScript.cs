using UnityEngine;
using System.Collections;

public class ArrowHairScript : MonoBehaviour {

	public int offset;
	public Transform h_Transform;

	public HairScript h_Script;

	// Use this for initialization
	void Start () {
		h_Script = h_Transform.gameObject.GetComponent<HairScript> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void Increment (){
//		int value = cabelo.GetComponent<HairScript> ().value;
//		int length = cabelo.GetComponent<HairScript> ().length;
		int value = h_Script.value;
		int length = h_Script.length;
//		Debug.Log ("Antes value " + value + " antes length " + length);
		int new_val = (h_Script.value + offset + h_Script.length) % h_Script.length;
//		int new_val = (value + offset + length) % length;
		h_Script.value = new_val;
//		Debug.Log ("depois: " + h_Script.value);
//		cabelo.GetComponent<HairScript> ().value = new_val;

	}

	public void Decrement (){
		// offset = -1
		int new_val = (h_Script.value + offset + h_Script.length) % h_Script.length;
		h_Script.value = new_val;
	}

	public void clickedArrow() {
		// not used anymore
		int new_val = h_Script.value + offset;
		h_Script.value = new_val;
	}
}
