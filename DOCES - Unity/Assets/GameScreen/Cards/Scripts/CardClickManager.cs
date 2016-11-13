using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Canvas))]
public class CardClickManager : MonoBehaviour {
	[SerializeField] private Sprite activatedSprite;
	[SerializeField] private Image cardBack;
	[SerializeField] private float activateTime;
	private bool spriteUpdated = false;
	private RectTransform rt;

	private Canvas can;

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
		cardState = CardState.NotActivated;
		rt = GetComponent<RectTransform> ();
		anim = GetComponent<Animator> ();
		can = GetComponent<Canvas> ();
	}

	
	// Update is called once per frame
	void Update () {
		if( !spriteUpdated && cardState == CardState.Activated && Mathf.Abs(rt.localRotation.eulerAngles.y - 90f) < 10f ) {
			cardBack.sprite = activatedSprite;
			spriteUpdated = true;
		}

		if (Input.GetMouseButtonDown (0)) {
			if ((cardState == CardState.Zoomed || cardState == CardState.SelectedAndZoomed)) {
				zoomOutCard ();
//				can.sortingOrder = 18; //ARRUMAR O TEMPO DO ZOOM!


			} else if (isMouseOver && isClickable) {
				if (Time.time - lastClickTime > clickInterval) {
					Debug.Log ("Primeiro Click: " + Time.time);
					clicksCount = 1;
				} else { 
					Debug.Log ("Segundo Click: " + Time.time);
					clicksCount++;
				}

				lastClickTime = Time.time;
				clicksCount = Mathf.Min (MAXCLICKS, clicksCount);
			}
		}

		if (clicksCount == MAXCLICKS || Time.time - lastClickTime > clickInterval - Time.deltaTime) {
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
//				can.sortingOrder = 19;
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
		GetComponent<RectTransform> ().SetAsLastSibling ();
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

	public void setFrontSprite(Sprite front) {
		activatedSprite = front;
	}
}
