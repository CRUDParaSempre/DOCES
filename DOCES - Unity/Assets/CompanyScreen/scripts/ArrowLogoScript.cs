using UnityEngine;
using System.Collections;

public class ArrowLogoScript: MonoBehaviour {

	public int offset;
	public Transform l_Transform;

	private LogoScript l_Script;

	// Use this for initialization
	void Start () {
		l_Script = l_Transform.gameObject.GetComponent<LogoScript> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void clickedArrow() {
		int new_val = l_Script.value + offset;
		l_Script.value = new_val;
	}
}
