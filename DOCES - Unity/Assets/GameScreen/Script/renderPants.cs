using UnityEngine;
using System.Collections;

public class renderPants : MonoBehaviour {

	private int _pantsId;
	public Sprite bottom1;
	public Sprite bottom2;
	public Sprite bottom3;
	public Sprite bottom4;
	public Sprite bottom5;
	public Sprite bottom6;
	public Sprite bottom7;
	public Sprite bottom8;
	private SpriteRenderer rend;
	public SpriteRenderer bottom;

	// Use this for initialization
	public void Start () {
		rend = bottom.GetComponent<SpriteRenderer> ();
		GameObject obj = GameObject.Find("GameStateManager");
		GameStateManager stateManager = obj.GetComponent<GameStateManager>();
		_pantsId = stateManager.getHairId ();
	}

	// Update is called once per frame
	void Update () {		
		if (_pantsId == 0) {
			rend.sprite = bottom1;
		} else if (_pantsId == 1 || _pantsId == -1) {
			rend.sprite = bottom2;
		} else if (_pantsId == 2 || _pantsId == -2) {
			rend.sprite = bottom3;
		} else if (_pantsId == 3 || _pantsId == -3) {
			rend.sprite = bottom4;
		} else if (_pantsId == 4 || _pantsId == -4) {
			rend.sprite = bottom5;
		} else if (_pantsId == 5 || _pantsId == -5) {
			rend.sprite = bottom6;
		} else if (_pantsId == 6 || _pantsId == -6) {
			rend.sprite = bottom7;
		} else if (_pantsId == 7 || _pantsId == -7) {
			rend.sprite = bottom8;
		}
	}
}
