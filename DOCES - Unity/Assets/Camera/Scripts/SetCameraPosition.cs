using UnityEngine;
using System.Collections;

public class SetCameraPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void setCameraPosition(int x, int y, int z) {
		Camera.main.transform.position = new Vector3 (x,y,z);
	}
}
