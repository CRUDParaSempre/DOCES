using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {
	[SerializeField] private float screenWidth=1024f, screenHeight=768f;
	[SerializeField] private Text upTutorialText=null;
	[SerializeField] private Canvas upTutorialCanvas=null;

	[SerializeField] private Text botTutorialText=null;
	[SerializeField] private Canvas botTutorialCanvas=null;

	[SerializeField] private List<RectTransform> fadeBlocks = new List<RectTransform> ();

	private List<string> tutorialTexts = new List<string>();
	private int index=0;


	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	public void showTutorialAtPosition(List<string> texts, float focusX, float focusY, float focusWidth, float focusHeight, bool aboveFocus, float xPivot) {
		createFocusArea (focusX,focusY,focusWidth,focusHeight);
		Vector3 newPos;
		RectTransform rtrans;
		tutorialTexts = texts;

		if (aboveFocus) {
			newPos = new Vector3 (Mathf.Lerp(focusX,(focusX + focusWidth),xPivot), focusY, 0f);
			upTutorialCanvas.GetComponent<RectTransform> ().localPosition = newPos;
			upTutorialText.text = texts [0];
			upTutorialCanvas.gameObject.SetActive (true);

		} else {
			newPos = new Vector3 (Mathf.Lerp(focusX,(focusX + focusWidth),xPivot), (focusY + focusHeight), 0f);
			botTutorialCanvas.GetComponent<RectTransform> ().localPosition = newPos;
			botTutorialText.text = texts [0];
			botTutorialCanvas.gameObject.SetActive (true);
		}

		this.gameObject.SetActive (true);
	}

	public void showTutorialAtPosition(string text, float focusX, float focusY, float focusWidth, float focusHeight, bool aboveFocus, float xPivot) {
		createFocusArea (focusX,focusY,focusWidth,focusHeight);
		Vector3 newPos;
		RectTransform rtrans;

		if (aboveFocus) {
			newPos = new Vector3 (Mathf.Lerp(focusX,(focusX + focusWidth),xPivot), -focusY, 0f);
			upTutorialCanvas.GetComponent<RectTransform> ().localPosition = newPos;
			upTutorialText.text = text;
			upTutorialCanvas.gameObject.SetActive (true);

		} else {
			newPos = new Vector3 (Mathf.Lerp(focusX,(focusX + focusWidth),xPivot), (-focusY - focusHeight), 0f);
			botTutorialCanvas.GetComponent<RectTransform> ().localPosition = newPos;
			botTutorialText.text = text;
			botTutorialCanvas.gameObject.SetActive (true);
		}

		this.gameObject.SetActive (true);
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
}