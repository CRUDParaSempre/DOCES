using UnityEngine;
using System.Collections;

public class DoorManager : MonoBehaviour {
	private Collider2D coll=null;
		
	// Use this for initialization
	void Start () {
		coll = GetComponent<Collider2D> ();
		coll.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void activateDoor() {
		coll.enabled = true;
	}

	public void desactivateDoor() {
		coll.enabled = false;
	}
}
