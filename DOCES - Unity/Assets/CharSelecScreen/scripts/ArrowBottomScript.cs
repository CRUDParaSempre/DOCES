using UnityEngine;
using System.Collections;

public class ArrowBottomScript : MonoBehaviour {

	public int offset;
	public Transform b_Transform;

	private BottomScript b_Script;

	// Use this for initialization
	void Start () {
		b_Script = b_Transform.gameObject.GetComponent<BottomScript> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void clickedArrow() {
		int new_val = b_Script.value + offset;
		b_Script.value = new_val;
	}
}
