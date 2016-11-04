using UnityEngine;
using System.Collections;

public class SetCameraPosition : MonoBehaviour {
	private bool moving = false;
	private float moveSpeed;
	private Vector3 dest;
	private Vector3 dirControl = new Vector3(1f,1f,1f); // 1 means should increase, -1 means should decrease
	private Rigidbody2D body;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (moving) {
			if ( transform.position.x * dirControl.x > dest.x * dirControl.x
				|| transform.position.y * dirControl.y > dest.y * dirControl.y
				|| transform.position.z * dirControl.z > dest.z * dirControl.z  ) {

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

		if (dest.x > transform.position.x) {
			dirControl.x = 1f;
		} else if (dest.x < transform.position.x) {
			dirControl.x = -1f;
		}

		if (dest.y > transform.position.y) {
			dirControl.y = 1f;
		} else if (dest.y < transform.position.y) {
			dirControl.y = -1f;
		}

		if (dest.z > transform.position.z) {
			dirControl.z = 1f;
		} else if (dest.z < transform.position.z) {
			dirControl.z = -1f;
		}

		moving = true;
		body.velocity = (dest - transform.position) / duration ;

	}

	
}
