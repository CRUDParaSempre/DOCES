using UnityEngine;
using System.Collections;

public class TopScript : MonoBehaviour {

	public int value;
	public Sprite blusa0;
	public Sprite blusa1;
	public Sprite blusa2;
	public Sprite blusa3;
	public Sprite blusa4;
	public Sprite blusa5;
	public Sprite blusa6;
	public Sprite blusa7;
	public Sprite blusa8;
	public Sprite blusa9;

	private SpriteRenderer rend;
	public SpriteRenderer blusa;

	// Use this for initialization
	void Start () {
		rend = blusa.GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {
		if (value % 10 == 0) {
			rend.sprite = blusa0;
		} else if (value % 10 == 1 || value % 10 == -1) {
			rend.sprite = blusa1;
		} else if (value % 10 == 2 || value % 10 == -2) {
			rend.sprite = blusa2;
		} else if (value % 10 == 3 || value % 10 == -3) {
			rend.sprite = blusa3;
		} else if (value % 10 == 4 || value % 10 == -4) {
			rend.sprite = blusa4;
		} else if (value % 10 == 5 || value % 10 == -5) {
			rend.sprite = blusa5;
		} else if (value % 10 == 6 || value % 10 == -6) {
			rend.sprite = blusa6;
		} else if (value % 10 == 7 || value % 10 == -7) {
			rend.sprite = blusa7;
		} else if (value % 10 == 8 || value % 10 == -8) {
			rend.sprite = blusa8;
		} else if (value % 10 == 9 || value % 10 == -9) {
			rend.sprite = blusa9;
		} 
	}
}
