using UnityEngine;
using System.Collections;

public class ArrowShoesScript : MonoBehaviour {

	public int offset;
	public Transform s_Transform;

	private ShoesScript s_Script;

	// Use this for initialization
	void Start () {
		s_Script = s_Transform.gameObject.GetComponent<ShoesScript> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void clickedArrow() {
		int new_val = s_Script.value + offset;
		s_Script.value = new_val;
	}
}
