using UnityEngine;
using System.Collections;

public class ShoesScript : MonoBehaviour {

	[SerializeField] private int _value = 0;
	[SerializeField] private int _length = 4;
	public Sprite sapato0;
	public Sprite sapato1;
	public Sprite sapato2;
	public Sprite sapato3;
	private SpriteRenderer rend;
	public SpriteRenderer sapato;

	public int value {
		get { return _value; }
		set { _value = value; }
	}

	public int length {
		get { return _length; }
		set { _length = length; }
	}

	// Use this for initialization
	void Start () {
		rend = sapato.GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {
		if (value % 4 == 0) {
			rend.sprite = sapato0;
		} else if (value % 4 == 1 || value % 4 == -1) {
			rend.sprite = sapato1;
		} else if (value % 4 == 2 || value % 4 == -2) {
			rend.sprite = sapato2;
		} else if (value % 4 == 3 || value % 4 == -3) {
			rend.sprite = sapato3;
		} 
	}

	public int getShoesId (){
		return value;
	}
}
