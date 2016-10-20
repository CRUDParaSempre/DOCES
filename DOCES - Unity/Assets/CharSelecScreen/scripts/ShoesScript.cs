using UnityEngine;
using System.Collections;

public class ShoesScript : MonoBehaviour {

	public int value;
	public Sprite sapato0;
	public Sprite sapato1;
	public Sprite sapato2;
	public Sprite sapato3;
	private SpriteRenderer rend;
	public SpriteRenderer sapato;

	// Use this for initialization
	void Start () {
		rend = sapato.GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {
		if (value % 4 == 0) {
			rend.sprite = sapato0;
		} else if (value % 4 == 1) {
			rend.sprite = sapato1;
		} else if (value % 4 == 2) {
			rend.sprite = sapato2;
		} else if (value % 4 == 3) {
			rend.sprite = sapato3;
		} 
	}
}
