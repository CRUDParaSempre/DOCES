using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]
public class CardClickManager : MonoBehaviour {
	[SerializeField] private int clicksToSelect = 2;
	[SerializeField] private int clicksToZoom = 1;
	[SerializeField] private float clickInterval = 0.1f;
	private int MAXCLICKS = 2;
	private int clicksCount = 0;
	private float lastClickTime = 0f;
	private bool isMouseOver = false;
	private bool isClickable = false;

	private enum CardState { NotActivated, Activated, Zoomed, Selected, SelectedAndZoomed }
	private CardState cardState = CardState.NotActivated; //0 = not activated, 1 = activated, 2 = zoomed, 3 = selected, 4 = Selected and Zoomed

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		anim.SetBool ("activated", false);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			if ((cardState == CardState.Zoomed || cardState == CardState.SelectedAndZoomed)) {
				zoomOutCard ();

			} else if (isMouseOver && isClickable) {
				if (Time.time - lastClickTime > clickInterval) {
					clicksCount = 1;
				} else { 
					clicksCount++;
				}

				lastClickTime = Time.time;
				clicksCount = Mathf.Min (MAXCLICKS, clicksCount);
			}
		}

		if (Time.time - lastClickTime > clickInterval) {
			if (clicksCount == clicksToSelect && cardState == CardState.Activated) {
				Debug.Log ("Time: " + Time.time + " " + clicksCount + " " + cardState );
				selectCard ();
				clicksCount = 0;

			} else if (clicksCount == clicksToSelect && cardState == CardState.Selected) {
				Debug.Log ("Time: " + Time.time + " " + clicksCount + " " + cardState );
				deselectCard ();
				clicksCount = 0;

			} else if (clicksCount == clicksToZoom && (cardState == CardState.Activated || cardState == CardState.Selected)) {
				Debug.Log ("Time: " + Time.time + " " + clicksCount + " " + cardState );
				zoomInCard ();
				clicksCount = 0;
			}
		}
	}

	void selectCard() {
		cardState = CardState.Selected;

		anim.SetBool ("selected", true);
	}

	void deselectCard() {
		cardState = CardState.Activated;

		anim.SetBool ("selected", false);
	}

	void zoomInCard() {
		if (cardState == CardState.Activated) {
			cardState = CardState.Zoomed;

		} else if (cardState == CardState.Selected) {
			cardState = CardState.SelectedAndZoomed;
		}

		anim.SetBool ("zoomIn", true);
	}

	void zoomOutCard() {
		if (cardState == CardState.Zoomed) {
			cardState = CardState.Activated;

		} else if (cardState == CardState.SelectedAndZoomed) {
			cardState = CardState.Selected;
		}

		anim.SetBool ("zoomIn", false);
	}

	public void activateCard() {
		anim.SetBool ("activated", true);
		isClickable = true;
		cardState = CardState.Activated;
	}

	void OnMouseEnter() {
		isMouseOver = true;
	}

	void OnMouseExit() {
		isMouseOver = false;
	}
}
