﻿using UnityEngine;
using System.Collections;

public class HairScript : MonoBehaviour {

	public int value;
	public Sprite cabelo0;
	public Sprite cabelo1;
	public Sprite cabelo2;
	public Sprite cabelo3;
	public Sprite cabelo4;
	public Sprite cabelo5;
	public Sprite cabelo6;
	public Sprite cabelo7;
	public Sprite cabelo8;
	public Sprite cabelo9;
	public Sprite cabelo10;
	public Sprite cabelo11;
	public Sprite cabelo12;
	public Sprite cabelo13;
	public Sprite cabelo14;
	public Sprite cabelo15;
	public Sprite cabelo16;
	public Sprite cabelo17;
	public Sprite cabelo18;
	public Sprite cabelo19;
	public Sprite cabelo20;
	public Sprite cabelo21;
	public Sprite cabelo22;
	public Sprite cabelo23;

	private SpriteRenderer rend;
	public SpriteRenderer cabelo;

	// Use this for initialization
	void Start () {
		rend = cabelo.GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {
		if (value % 24 == 0) {
			rend.sprite = cabelo0;
		} else if (value % 24 == 1) {
			rend.sprite = cabelo1;
		} else if (value % 24 == 2) {
			rend.sprite = cabelo2;
		} else if (value % 24 == 3) {
			rend.sprite = cabelo3;
		} else if (value % 24 == 4) {
			rend.sprite = cabelo4;
		} else if (value % 24 == 5) {
			rend.sprite = cabelo5;
		} else if (value % 24 == 6) {
			rend.sprite = cabelo6;
		} else if (value % 24 == 7) {
			rend.sprite = cabelo7;
		} else if (value % 24 == 8) {
			rend.sprite = cabelo8;
		} else if (value % 24 == 9) {
			rend.sprite = cabelo9;
		} else if (value % 24 == 10) {
			rend.sprite = cabelo10;
		} else if (value % 24 == 11) {
			rend.sprite = cabelo11;
		} else if (value % 24 == 12) {
			rend.sprite = cabelo12;
		} else if (value % 24 == 13) {
			rend.sprite = cabelo13;
		} else if (value % 24 == 14) {
			rend.sprite = cabelo14;
		} else if (value % 24 == 15) {
			rend.sprite = cabelo15;
		} else if (value % 24 == 16) {
			rend.sprite = cabelo16;
		} else if (value % 24 == 17) {
			rend.sprite = cabelo17;
		} else if (value % 24 == 18) {
			rend.sprite = cabelo18;
		} else if (value % 24 == 19) {
			rend.sprite = cabelo19;
		} else if (value % 24 == 20) {
			rend.sprite = cabelo20;
		} else if (value % 24 == 21) {
			rend.sprite = cabelo21;
		} else if (value % 24 == 22) {
			rend.sprite = cabelo22;
		} else if (value % 24 == 23) {
			rend.sprite = cabelo23;
		}
	}
}