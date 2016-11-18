using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Canvas))]
public class CardClickManager : MonoBehaviour {
	[SerializeField] private Sprite activatedSprite;
	[SerializeField] private Image cardBack;
	[SerializeField] private float activateTime;
	[SerializeField] private AbilitiesManager abiManager;
	[SerializeField] private WarningManager warning;
	private bool spriteUpdated = false;
	private RectTransform rt;
	private List<int> _costs;
	public List<int> costs {
		set{ _costs = value; }
		get{ return _costs; }
	}

	private int _bonusValue;
	public int bonusValue {
		set{ _bonusValue= value; }
		get{ return _bonusValue; }
	}

	private string _type;
	public string type {
		set{ _type = value; }
		get{ return _type; }
	}

	private Canvas can;

	[SerializeField] private int clicksToSelect = 2;
	[SerializeField] private int clicksToZoom = 1;
	[SerializeField] private float clickInterval = 0.1f;
	private int MAXCLICKS = 2;
	private int clicksCount = 0;
	private float lastClickTime = 0f;
	private bool isMouseOver = false;
	private bool isClickable = false;

	public enum CardState { NotActivated, Activated, Zoomed, Selected, SelectedAndZoomed }
	private CardState _cardState= CardState.NotActivated; //0 = not activated, 1 = activated, 2 = zoomed, 3 = selected, 4 = Selected and Zoomed
	public CardState cardState {
		get { return _cardState; }
	}

	private Animator anim;

	// Use this for initialization
	void Awake () {
		_cardState= CardState.NotActivated;
		rt = GetComponent<RectTransform> ();
		anim = GetComponent<Animator> ();
		can = GetComponent<Canvas> ();
	}

	
	// Update is called once per frame
	void Update () {
		if( !spriteUpdated && _cardState== CardState.Activated && rt.localRotation.eulerAngles.y > 80f ) {
			cardBack.sprite = activatedSprite;
			spriteUpdated = true;
		}

		if (Input.GetMouseButtonDown (0)) {
			if ((_cardState== CardState.Zoomed || _cardState== CardState.SelectedAndZoomed)) {
				zoomOutCard ();

			} else if (isMouseOver && isClickable) {
				if (Time.time - lastClickTime > clickInterval) {
//					Debug.Log ("Primeiro Click: " + Time.time);
					clicksCount = 1;
				} else { 
//					Debug.Log ("Segundo Click: " + Time.time);
					clicksCount++;
				}

				lastClickTime = Time.time;
				clicksCount = Mathf.Min (MAXCLICKS, clicksCount);
			}
		}

		if (clicksCount == MAXCLICKS || Time.time - lastClickTime > clickInterval - Time.deltaTime) {
			if (clicksCount == clicksToSelect && _cardState== CardState.Activated) {
				if (abiManager.canSelectCard (_costs)) {
//				Debug.Log ("Time: " + Time.time + " " + clicksCount + " " + _cardState);
					selectCard ();
					clicksCount = 0;
				} else {
					warning.showWarning ("Você não tem pontos suficientes para escolher esta carta!");
					clicksCount = 0;
				}

			} else if (clicksCount == clicksToSelect && _cardState== CardState.Selected) {
//				Debug.Log ("Time: " + Time.time + " " + clicksCount + " " + _cardState);
				deselectCard ();
				clicksCount = 0;

			} else if (clicksCount == clicksToZoom && (_cardState== CardState.Activated || _cardState== CardState.Selected)) {
//				Debug.Log ("Time: " + Time.time + " " + clicksCount + " " + _cardState);
				zoomInCard ();
				clicksCount = 0;
			}
		}

	}

	void selectCard() {
		abiManager.cardSelected (_costs);

		_cardState= CardState.Selected;

		anim.SetBool ("selected", true);
	}

	void deselectCard() {
		abiManager.cardDeselected (_costs);

		_cardState= CardState.Activated;

		anim.SetBool ("selected", false);
	}

	void zoomInCard() {
		GetComponent<RectTransform> ().SetAsLastSibling ();
		if (_cardState== CardState.Activated) {

			_cardState= CardState.Zoomed;

		} else if (_cardState== CardState.Selected) {
			_cardState= CardState.SelectedAndZoomed;
		}

		anim.SetBool ("zoomIn", true);
	}

	void zoomOutCard() {
		if (_cardState== CardState.Zoomed) {
			_cardState= CardState.Activated;

		} else if (_cardState== CardState.SelectedAndZoomed) {
			_cardState= CardState.Selected;
		}

		anim.SetBool ("zoomIn", false);
	}

	public void activateCard() {
		anim.SetBool ("activated", true);
		_cardState= CardState.Activated;
	}

	public void setClick(){
		isClickable = true;	
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

	public void resetCard() {
		//desativar os componentes da frente
		Transform cardBackground = GetComponent<RectTransform>().GetChild(0);

		foreach( Transform t in cardBackground) {
			t.gameObject.SetActive (false);
		}

		//deseleciona
		GameObject cardCover = GetComponent<RectTransform> ().GetChild (1).gameObject;

		Image i = cardCover.GetComponent<Image> ();
		Color c = new Color ();

		c.a = 0f;
		c.b = 1f;
		c.g = 1f;
		c.r = 1f;

		i.color = c;

		//restora as variáveis para o padrão
		anim.SetBool("activated", false);
		anim.SetBool ("zoomIn", false);
		anim.SetBool("selected", false);
		_cardState= CardState.NotActivated;
		spriteUpdated = false;
		rt.localRotation = Quaternion.Euler(new Vector3(0f,0f,0f));
		rt.localScale = new Vector3(.7f,.7f,.7f);
	}

	public void OnDisable() {
		resetCard ();
	}
}
