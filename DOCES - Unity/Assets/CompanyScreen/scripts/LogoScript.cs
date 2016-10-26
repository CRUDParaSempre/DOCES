using UnityEngine;
using System.Collections;

public class LogoScript : MonoBehaviour {

	[SerializeField] private int _value = 0;
	[SerializeField] private int _length = 21;
	public Sprite logo0;
	public Sprite logo1;
	public Sprite logo2;
	public Sprite logo3;
	public Sprite logo4;
	public Sprite logo5;
	private SpriteRenderer rend;
	public SpriteRenderer logo;

	public int value {
		set;
		get;
	}

	public int length {
		set;
		get;
	}

	// Use this for initialization
	void Start () {
		rend = logo.GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {
		if (_value % 6 == 0) {
			rend.sprite = logo0;
		} else if (_value % 6 == 1 || _value % 6 == -1) {
			rend.sprite = logo1;
		} else if (_value % 6 == 2 || _value % 6 == -2) {
			rend.sprite = logo2;
		} else if (_value % 6 == 3 || _value % 6 == -3) {
			rend.sprite = logo3;
		} else if (_value % 6 == 4 || _value % 6 == -4) {
			rend.sprite = logo4;
		} else if (_value % 6 == 5 || _value % 6 == -5) {
			rend.sprite = logo5;
		} 
	}

	public void Increment (){
		int new_val = (_value + 1 + _length) % _length;
		_value = new_val;
	}

	public void Decrement (){
		int new_val = (_value + 1 + _length) % _length;
		_value = new_val;
	}

	public int getLogoId (){
		return _value;
	}
}
