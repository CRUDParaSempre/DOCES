using UnityEngine;
using System.Collections;
using Fungus;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]
public class ClickAnimationControl : MonoBehaviour {
	private Animator anim;
	private int stage = 0;
	private bool isMouseOver = false;
	private bool clicked = false;
	[SerializeField] private Fungus.Flowchart flowchart;
	[SerializeField] private string blockName;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isMouseOver && Input.GetMouseButtonDown(0)) {
			setMouseStatus (2);
			clicked = true;

		} else if(clicked && Input.GetMouseButtonUp(0)) {
			setMouseStatus (1);
			clicked = false;
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

	public void OnMouseEnter() {
		setMouseStatus (1);
		isMouseOver = true;
	}

	public void OnMouseExit() {
		setMouseStatus (0);
		isMouseOver = false;
	}
}
