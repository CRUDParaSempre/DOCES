using UnityEngine;
using System.Collections;

public class HairScript : MonoBehaviour {

	[SerializeField] private int _value = 0;
	[SerializeField] private int _length = 21;
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

	private SpriteRenderer rend;
	public SpriteRenderer cabelo;

	public int value { 
		set{ _value = value; }
		get{ return _value; }
	}
	public int length { 
		set{ _length = length; }
		get{ return _length; }
	}

	// Use this for initialization
	void Start () {
		rend = cabelo.GetComponent<SpriteRenderer> ();
		_length = 21;
	}

	// Update is called once per frame
	void Update () {
		if (value % length == 0) {
			rend.sprite = cabelo0;
		} else if (value % length == 1 || value % length == -1) {
			rend.sprite = cabelo1;
		} else if (value % length == 2 || value % length == -2) {
			rend.sprite = cabelo2;
		} else if (value % length == 3 || value % length == -3) {
			rend.sprite = cabelo3;
		} else if (value % length == 4 || value % length == -4) {
			rend.sprite = cabelo4;
		} else if (value % length == 5 || value % length == -5) {
			rend.sprite = cabelo5;
		} else if (value % length == 6 || value % length == -6) {
			rend.sprite = cabelo6;
		} else if (value % length == 7 || value % length == -7) {
			rend.sprite = cabelo7;
		} else if (value % length == 8 || value % length == -8) {
			rend.sprite = cabelo8;
		} else if (value % length == 9 || value % length == -9) {
			rend.sprite = cabelo9;
		} else if (value % length == 10 || value % length == -10) {
			rend.sprite = cabelo10;
		} else if (value % length == 11 || value % length == -11) {
			rend.sprite = cabelo11;
		} else if (value % length == 12 || value % length == -12) {
			rend.sprite = cabelo12;
		} else if (value % length == 13 || value % length == -13) {
			rend.sprite = cabelo13;
		} else if (value % length == 14 || value % length == -14) {
			rend.sprite = cabelo14;
		} else if (value % length == 15 || value % length == -15) {
			rend.sprite = cabelo15;
		} else if (value % length == 16 || value % length == -16) {
			rend.sprite = cabelo16;
		} else if (value % length == 17 || value % length == -17) {
			rend.sprite = cabelo17;
		} else if (value % length == 18 || value % length == -18) {
			rend.sprite = cabelo18;
		} else if (value % length == 19 || value % length == -19) {
			rend.sprite = cabelo19;
		} else if (value % length == 20 || value % length == -20) {
			rend.sprite = cabelo20;
		} 
	}

	public int getHairId (){
		return value;
	}
}
