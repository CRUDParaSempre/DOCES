﻿using UnityEngine;
using System.Collections;

public class BottomScript : MonoBehaviour {

	public int value;
	public Sprite calça0;
	public Sprite calça1;
	public Sprite calça2;
	public Sprite calça3;
	public Sprite calça4;
	public Sprite calça5;
	public Sprite calça6;
	public Sprite calça7;
	private SpriteRenderer rend;
	public SpriteRenderer calça;

	// Use this for initialization
	void Start () {
		rend = calça.GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {
		if (value % 8 == 0) {
			rend.sprite = calça0;
		} else if (value % 8 == 1) {
			rend.sprite = calça1;
		} else if (value % 8 == 2) {
			rend.sprite = calça2;
		} else if (value % 8 == 3) {
			rend.sprite = calça3;
		} else if (value % 8 == 4) {
			rend.sprite = calça4;
		} else if (value % 8 == 5) {
			rend.sprite = calça5;
		} else if (value % 8 == 6) {
			rend.sprite = calça6;
		} else if (value % 8 == 7) {
			rend.sprite = calça7;
		} 
	}
}