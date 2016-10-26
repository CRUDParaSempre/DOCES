using UnityEngine;
using System.Collections;

public class TotalMeterScript : MonoBehaviour {

	[SerializeField] private int _value = 15;
	public Sprite habilidade0;
	public Sprite habilidade1;
	public Sprite habilidade2;
	public Sprite habilidade3;
	public Sprite habilidade4;
	public Sprite habilidade5;
	public Sprite habilidade6;
	public Sprite habilidade7;
	public Sprite habilidade8;
	public Sprite habilidade9;
	public Sprite habilidade10;
	public Sprite habilidade11;
	public Sprite habilidade12;
	public Sprite habilidade13;
	public Sprite habilidade14;
	public Sprite habilidade15;
	private SpriteRenderer rend;
	public SpriteRenderer frasco;

	public int value { 
		set { _value = value; } 
		get { return _value; }
	}

	// Use this for initialization
	void Start () {
		rend = frasco.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (value == 0) {
			rend.sprite = habilidade0;
		} else if (value == 1) {
			rend.sprite = habilidade1;
		} else if (value == 2) {
			rend.sprite = habilidade2;
		} else if (value == 3) {
			rend.sprite = habilidade3;
		} else if (value == 4) {
			rend.sprite = habilidade4;
		} else if (value == 5) {
			rend.sprite = habilidade5;
		} else if (value == 6) {
			rend.sprite = habilidade6;
		} else if (value == 7) {
			rend.sprite = habilidade7;
		} else if (value == 8) {
			rend.sprite = habilidade8;
		} else if (value == 9) {
			rend.sprite = habilidade9;
		} else if (value == 10) {
			rend.sprite = habilidade10;
		} else if (value == 11) {
			rend.sprite = habilidade11;
		} else if (value == 12) {
			rend.sprite = habilidade12;
		} else if (value == 13) {
			rend.sprite = habilidade13;
		} else if (value == 14) {
			rend.sprite = habilidade14;
		} else if (value == 15) {
			rend.sprite = habilidade15;
		} 
	}

	public int getValue (){
		return value;
	}
}
