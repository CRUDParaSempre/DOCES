using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WarningManager : MonoBehaviour {
	[SerializeField] private Text descriptionText;
	[SerializeField] private Canvas movableCanvas;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void showWarning(string text) {
		this.gameObject.SetActive (true);
		descriptionText.text = text;
	}

	public void showWarningAtPosition(string text, float x, float y) {
		this.gameObject.SetActive (true);
		movableCanvas.GetComponent<RectTransform> ().position = new Vector3 (x,y,0f);
		descriptionText.text = text;
	}
}
