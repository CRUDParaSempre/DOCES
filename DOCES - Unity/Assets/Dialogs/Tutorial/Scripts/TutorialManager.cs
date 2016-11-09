//created by Marcelo Gomes (09-11)

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {
	[SerializeField] private float screenWidth=1024f, screenHeight=768f;

	[SerializeField] private Text upTutorialText=null;
	[SerializeField] private Canvas upTutorialCanvas=null;
	[SerializeField] private Image upPreviousButton=null;


	[SerializeField] private Text botTutorialText=null;
	[SerializeField] private Canvas botTutorialCanvas=null;
	[SerializeField] private Image botPreviousButton=null;

	[SerializeField] private List<RectTransform> fadeBlocks = new List<RectTransform> ();

	private List<string> tutorialTexts = new List<string>();
	private int index=0;
	private bool aboveFocus = false;
	private Color halfTransparent = new Color(1f,1f,1f,.5f);
	private Color opaque = new Color(1f,1f,1f,1f);


	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

	}

	public void showTutorialAtPosition(List<string> texts, float focusX, float focusY, float focusWidth, float focusHeight, bool aboveFocus, float xPivot) {
		createFocusArea (focusX,focusY,focusWidth,focusHeight);
		Vector3 newPos;
		tutorialTexts = texts;
		this.aboveFocus = aboveFocus;

		if (aboveFocus) {
			//set tutorial message position
			newPos = new Vector3 (Mathf.Lerp(focusX,(focusX + focusWidth),xPivot), -focusY, 0f);
			upTutorialCanvas.GetComponent<RectTransform> ().localPosition = newPos;

			//initialize text
			upTutorialText.text = texts [0];

			//activate tutorial message canvas
			upTutorialCanvas.gameObject.SetActive (true);

			//make previous tip unavailable
			upPreviousButton.color = halfTransparent;
			upPreviousButton.gameObject.GetComponent<CircleCollider2D> ().enabled = false;



		} else {
			newPos = new Vector3 (Mathf.Lerp(focusX,(focusX + focusWidth),xPivot), (-focusY + -focusHeight), 0f);
			botTutorialCanvas.GetComponent<RectTransform> ().localPosition = newPos;

			botTutorialText.text = texts [0];

			botTutorialCanvas.gameObject.SetActive (true);

			botPreviousButton.color = halfTransparent;
			botPreviousButton.gameObject.GetComponent<CircleCollider2D> ().enabled = false;

		}




		this.gameObject.SetActive (true);
	}

	public void showTutorialAtPosition(string text, float focusX, float focusY, float focusWidth, float focusHeight, bool aboveFocus, float xPivot) {
		List<string> l = new List<string> ();
		l.Add (text);

		showTutorialAtPosition (l, focusX, focusY, focusWidth, focusHeight, aboveFocus, xPivot);
	}

	private void createFocusArea(float x, float y, float width, float height) {
		foreach(RectTransform rt in fadeBlocks) {
			rt.gameObject.SetActive (true);
		}

		//top fade block position and size
		fadeBlocks[0].localPosition = new Vector3(0f,0f,0f);
		fadeBlocks [0].sizeDelta = new Vector2 (screenWidth,y);

		//bot fade block position and size
		fadeBlocks[1].localPosition = new Vector3(0f,-y-height,0f);
		fadeBlocks[1].sizeDelta = new Vector2(screenWidth, screenHeight - fadeBlocks [0].sizeDelta.y - height);

		//left fade block position and size
		fadeBlocks[2].localPosition = new Vector3(0f,-y,0f);
		fadeBlocks [2].sizeDelta = new Vector2 (x,height);

		//right fade block position and size
		fadeBlocks[3].localPosition = new Vector3(width+x,-y,0f);
		fadeBlocks [3].sizeDelta = new Vector2 (screenWidth - fadeBlocks[2].sizeDelta.x - width,height);
	}

	public void nextTutorialTip() {

		//there is more tips to show
		if (++index < tutorialTexts.Count) {
			if (aboveFocus) {
				upTutorialText.text = tutorialTexts [index];
				upPreviousButton.color = opaque;
				upPreviousButton.gameObject.GetComponent<CircleCollider2D> ().enabled = true;
			} else {
				botTutorialText.text = tutorialTexts [index];
				botPreviousButton.color = opaque;
				botPreviousButton.gameObject.GetComponent<CircleCollider2D> ().enabled = true;
			}
		
		//nothing else to show, deactivate tutorial
		} else {

			foreach(RectTransform rt in fadeBlocks) {
				rt.gameObject.SetActive (true);
			}

			upTutorialCanvas.gameObject.SetActive (false);
			botTutorialCanvas.gameObject.SetActive (false);
			this.gameObject.SetActive (false);
		}
	}

	public void previousTutorialTip() {

		//there is a previous tip to show
		if (--index > 0) {
			if (aboveFocus) {
				upTutorialText.text = tutorialTexts [index];
			} else {
				botTutorialText.text = tutorialTexts [index];
			}


		//we are at the first ti
		} else {

			if (aboveFocus) {
				upTutorialText.text = tutorialTexts [index];
				upPreviousButton.color = halfTransparent;
				upPreviousButton.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
			} else {
				botTutorialText.text = tutorialTexts [index];
				botPreviousButton.color = halfTransparent;
				botPreviousButton.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
			}

		}
	}

	public void testTutorialDialogue() {
		List<string> l = new List<string> ();
		l.Add ("Cara se voce apertar nesse botao de continuar jogo você vai carregar seu jogo salvo! É isso, tenho mais nada pra falar não!");
		l.Add ("Mas como eu preciso testar essa bagaça eu vou echer de texto aqui");
		l.Add ("askjdb aishd loash díhsadlusgaoç hoshy 12ye71 2e7 1os8yd a9s7dp ausgdçausdg aosy 192 ety1u gskkdjgasild tas");
		l.Add ("vlw fera!");

		showTutorialAtPosition (l,434f,583f,159f,49f,true,.5f);
	}
}