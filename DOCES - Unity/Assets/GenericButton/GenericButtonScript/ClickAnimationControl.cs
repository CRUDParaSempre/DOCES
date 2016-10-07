using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Fungus;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class ClickAnimationControl : MonoBehaviour {
	private Animator anim;
	private int stage = 0;
	private bool isMouseOver = false;
	private bool clicked = false;
	private SpriteRenderer rend;

	[SerializeField] private Fungus.Flowchart flowchart;
	[SerializeField] private string blockName;
	[SerializeField] private List<Sprite> buttonSprites = new List<Sprite>(); // 0 not selected, 1 selected, 2 pressed
	[SerializeField] private bool changeSpriteWhileClick = true;
	[SerializeField] private AudioSource selectedSound = null;
	[SerializeField] private AudioSource clickSound = null;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rend = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isMouseOver && Input.GetMouseButtonDown(0)) {
			setMouseStatus (2);
			clicked = true;

			if (clickSound != null) {
				clickSound.Play ();
			}

			if (changeSpriteWhileClick) {
				rend.sprite = buttonSprites [2];
			} else {
				if (rend.sprite == buttonSprites [1]) {
					rend.sprite = buttonSprites [0];
				} else if(rend.sprite == buttonSprites[0]) {
					rend.sprite = buttonSprites [1];
				}
			}

		} else if(clicked && Input.GetMouseButtonUp(0)) {
			
			clicked = false;

			if (changeSpriteWhileClick) {
				if (isMouseOver) {
					rend.sprite = buttonSprites [1];
					setMouseStatus (1);
				} else {
					rend.sprite = buttonSprites [0];
					setMouseStatus (0);
				}
			} else {
				if (isMouseOver) {
					setMouseStatus (1);
				} else {
					setMouseStatus (0);
				}
			}

			flowchart.ExecuteBlock (blockName);

		}
	}

	public void setMouseStatus(int mouseStatus) {

		//mouse not over
		if (mouseStatus == 0) {
			anim.SetInteger ("stage",0);

		//mouse over
		} else if(mouseStatus == 1) {
			anim.SetInteger ("stage",1);

		//clicked
		} else if (mouseStatus == 2) {
			anim.SetInteger ("stage",2);
		}
	}

	public void setAnimationParam(string paramName, bool value) {
		anim.SetBool (paramName,value);
	}

	public bool getAnimationParam(string paramName) {
		return anim.GetBool (paramName);
	}

	public void OnMouseEnter() {
		setMouseStatus (1);
		isMouseOver = true;

		if (changeSpriteWhileClick) {
			rend.sprite = buttonSprites [1];
		}

		if (selectedSound != null) {
			selectedSound.Play ();
		}
	}

	public void OnMouseExit() {
		setMouseStatus (0);
		isMouseOver = false;

		if (changeSpriteWhileClick) {
			rend.sprite = buttonSprites [0];
		}
	}
}
