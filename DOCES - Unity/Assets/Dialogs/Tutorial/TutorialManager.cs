//Created by Marcelo Gomes (08/11)

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TutorialManager : MonoBehaviour {
	[SerializeField] private Text upTutorialText = null;
	[SerializeField] private Canvas upTutorialCanvas = null;

	[SerializeField] private Text downTutorialText = null;
	[SerializeField] private Canvas downTutorialCanvas = null;

	[SerializeField] private List<RectTransform> fadeBlocks = new List<RectTransform>();

	private int index=0;


	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	public void showTutorialDialog(string text, float focusX, float focusY, float focusWidth, float focusHeight, bool aboveFocus) {
		createFocus (focusX,focusY,focusWidth,focusHeight);
		RectTransform rtran;

		if (aboveFocus) {
			upTutorialText.text = text ;

			rtran = upTutorialCanvas.GetComponent<RectTransform> ();
			Vector3 newPos = new Vector3(focusX,focusY,0f);
			newPos.x += focusWidth / 2;

			rtran.position = newPos;

			upTutorialCanvas.gameObject.SetActive (true);
		} else {
			downTutorialText.text = text ;

			rtran = downTutorialCanvas.GetComponent<RectTransform> ();
			Vector3 newPos = new Vector3(focusX,focusY,0f);
			newPos.x += focusWidth / 2;
			newPos.y -= focusWidth;

			rtran.position = newPos;

			downTutorialCanvas.gameObject.SetActive (true);
		}



		this.gameObject.SetActive (true);
	}

	private void createFocus(float x, float y, float width, float height) {
		foreach (RectTransform rt in fadeBlocks) {
			rt.gameObject.SetActive (true);
		}

		Vector3 newPos;

		//treat top fade block
		newPos = new Vector3(x,0f,0f);
		Debug.Log (Camera.main.ScreenToWorldPoint(newPos));

		fadeBlocks[0].localPosition = newPos;
		Debug.Log (fadeBlocks[0].position );
		//fadeBlocks [0].sizeDelta = new Vector2(width, y );
	}
}