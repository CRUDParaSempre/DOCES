﻿//Criado por Guilherme B Revisado por Marcelo Gomes

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class renderChar : MonoBehaviour {
	private int _hairId;
	private Color haircol;
	public List<Sprite> hairs = new List<Sprite> ();
	private SpriteRenderer hairrend;
	public SpriteRenderer hair;

	private int _shirtId;
	private Color topcol;
	public List<Sprite> tops = new List<Sprite> (); 
	private SpriteRenderer toprend;
	public SpriteRenderer top;
	public List<Sprite> arms = new List<Sprite> (); 
	private SpriteRenderer armrend;
	public SpriteRenderer arm;

	private int _pantsId;
	private Color bottomcol;
	public List<Sprite> bottoms = new List<Sprite> (); 
	private SpriteRenderer bottomrend;
	public SpriteRenderer bottom;

	private int _shoesId;
	private Color shoecol;
	public List<Sprite> shoes = new List<Sprite> (); 
	private SpriteRenderer shoerend;
	public SpriteRenderer shoe;

	private int _sexo;
	public List<Sprite> mouthes = new List<Sprite> (); 
	private SpriteRenderer mouthrend;
	public SpriteRenderer mouth;

	private Color eyecol;
	private SpriteRenderer eyerend;
	public SpriteRenderer eyes;

	private Color skincol;
	private SpriteRenderer rendhead;
	public SpriteRenderer head;
	private SpriteRenderer rendarmskin;
	public SpriteRenderer armskin;
	private SpriteRenderer rendbody;
	public SpriteRenderer body;
	private SpriteRenderer rendleg;
	public SpriteRenderer leg;
	private SpriteRenderer rendfeet;
	public SpriteRenderer feet;

	// Use this for initialization
	public void Start () {
		hairrend = hair.GetComponent<SpriteRenderer> ();
		_hairId = GameStateManager.Instance.hairId;
		haircol = GameStateManager.Instance.getItemColor (GameStateManager.Colorable.Hair);

		toprend = top.GetComponent<SpriteRenderer> ();
		_shirtId = GameStateManager.Instance.shirtId;
		topcol = GameStateManager.Instance.getItemColor (GameStateManager.Colorable.Shirt);
		armrend = arm.GetComponent<SpriteRenderer> ();

		bottomrend = bottom.GetComponent<SpriteRenderer> ();
		_pantsId = GameStateManager.Instance.pantsId;
		bottomcol = GameStateManager.Instance.getItemColor (GameStateManager.Colorable.Pants);

		shoerend = shoe.GetComponent<SpriteRenderer> ();
		_shoesId = GameStateManager.Instance.shoesId;
		shoecol = GameStateManager.Instance.getItemColor (GameStateManager.Colorable.Shoes);

		mouthrend = mouth.GetComponent<SpriteRenderer> ();
		_sexo = GameStateManager.Instance.gender;

		eyerend = eyes.GetComponent<SpriteRenderer> ();
		eyecol = GameStateManager.Instance.getItemColor (GameStateManager.Colorable.Eyes);

		rendhead = head.GetComponent<SpriteRenderer> ();
		rendarmskin = armskin.GetComponent<SpriteRenderer> ();
		rendbody = body.GetComponent<SpriteRenderer> ();
		rendleg = leg.GetComponent<SpriteRenderer> ();
		rendfeet = feet.GetComponent<SpriteRenderer> ();
		skincol = GameStateManager.Instance.getItemColor (GameStateManager.Colorable.Skin);

		hairrend.color = haircol;
		hairrend.sprite = hairs [_hairId];

		toprend.color = topcol;
		toprend.sprite = tops [_shirtId];

		armrend.color = topcol;
		armrend.sprite = arms [_shirtId];

		bottomrend.color = bottomcol;
		bottomrend.sprite = bottoms [_pantsId];

		shoerend.color = shoecol;
		shoerend.sprite = shoes [_shoesId];

		mouthrend.sprite = mouthes [_sexo];

		eyerend.color = eyecol;

		rendhead.color = skincol;
		rendarmskin.color = skincol;
		rendbody.color = skincol;
		rendleg.color = skincol;
		rendfeet.color = skincol;

	}
	
	// Update is called once per frame
	void Update () {

			
	}
}
