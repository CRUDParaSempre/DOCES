using UnityEngine;
using System.Collections;

public class ArrowTopScript : MonoBehaviour {

	public int offset;
	public Transform t_Transform;

	private TopScript t_Script;

	// Use this for initialization
	void Start () {
		t_Script = t_Transform.gameObject.GetComponent<TopScript> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void clickedArrow() {
		int new_val = t_Script.value + offset;
		t_Script.value = new_val;
	}
}
