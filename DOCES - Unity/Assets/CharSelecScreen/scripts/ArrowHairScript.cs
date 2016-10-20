using UnityEngine;
using System.Collections;

public class ArrowHairScript : MonoBehaviour {

	public int offset;
	public Transform h_Transform;

	private HairScript h_Script;

	// Use this for initialization
	void Start () {
		h_Script = h_Transform.gameObject.GetComponent<HairScript> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void OnMouseDown() {
		int new_val = h_Script.value + offset;
		h_Script.value = new_val;
	}
}
