using UnityEngine;
using System.Collections;

public class SetCameraPosition : MonoBehaviour {
	private bool moving = false;
	private float moveSpeed;
	private Vector3 dest;
	private Rigidbody2D body;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (moving) {
			if (Vector3.Distance (transform.position, dest) < .5f) {
				transform.position = dest;
				body.velocity = Vector2.zero;
				moving = false;
			}
		}
	}


	public void setCameraPosition(int x, int y, int z) {
		Camera.main.transform.position = new Vector3 (x,y,z);
	}

	public void moveCameraTo(Vector3 dest, float duration) {
		this.dest = dest;
		body.velocity = (dest - transform.position) / duration ;
		moving = true;
	}

	
}
