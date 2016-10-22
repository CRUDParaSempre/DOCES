using UnityEngine;
using System.Collections;

public class LogoScript : MonoBehaviour {

	public int value;
	public Sprite logo0;
	public Sprite logo1;
	public Sprite logo2;
	public Sprite logo3;
	public Sprite logo4;
	public Sprite logo5;
	private SpriteRenderer rend;
	public SpriteRenderer logo;

	// Use this for initialization
	void Start () {
		rend = logo.GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {
		if (value % 6 == 0) {
			rend.sprite = logo0;
		} else if (value % 6 == 1 || value % 6 == -1) {
			rend.sprite = logo1;
		} else if (value % 6 == 2 || value % 6 == -2) {
			rend.sprite = logo2;
		} else if (value % 6 == 3 || value % 6 == -3) {
			rend.sprite = logo3;
		} else if (value % 6 == 4 || value % 6 == -4) {
			rend.sprite = logo4;
		} else if (value % 6 == 5 || value % 6 == -5) {
			rend.sprite = logo5;
		} 
	}
}
