//Made by Amanda Santos Inspected by Marcelo Gomes

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LogoScript : MonoBehaviour {

	[SerializeField] private int _value = 0;
	[SerializeField] private List<Sprite> logoSprites;
	private SpriteRenderer rend;
	public SpriteRenderer logo;

	public int value {
		set;
		get;
	}

	// Use this for initialization
	void Start () {
		rend = logo.GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void Increment (){
		_value = (_value + 1 + logoSprites.Count) % logoSprites.Count;
		updateSprite ();
	}

	public void Decrement (){
		_value = (_value - 1 + logoSprites.Count) % logoSprites.Count;
		updateSprite ();
	}

	public int getLogoId (){
		return _value;
	}

	private void updateSprite () {
		GameStateManager.Instance.setLogoId(_value);
		rend.sprite = logoSprites [_value];
	}
}
