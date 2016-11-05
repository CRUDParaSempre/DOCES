using UnityEngine;
using System.Collections;

public class renderArms : MonoBehaviour {

	private int _shirtId;
	public Sprite top0;
	public Sprite top1;
	public Sprite top2;
	public Sprite top3;
	public Sprite top4;
	public Sprite top5;
	public Sprite top6;
	public Sprite top7;
	public Sprite top8;
	public Sprite top9;

	private SpriteRenderer rend;
	public SpriteRenderer top;
	// Use this for initialization
	public void Start () {
		rend = top.GetComponent<SpriteRenderer> ();
		GameObject obj = GameObject.Find("GameStateManager");
		GameStateManager stateManager = obj.GetComponent<GameStateManager>();
		_shirtId = stateManager.getShirtId ();
	}

	// Update is called once per frame
	void Update () {
		Debug.Log ("shirt " + _shirtId);
		if (_shirtId == 0) {
			rend.sprite = top0;
		} else if (_shirtId == 1 || _shirtId == -1) {
			rend.sprite = top1;
		} else if (_shirtId == 2 || _shirtId == -2) {
			rend.sprite = top2;
		} else if (_shirtId == 3 || _shirtId == -3) {
			rend.sprite = top3;
		} else if (_shirtId == 4 || _shirtId == -4) {
			rend.sprite = top4;
		} else if (_shirtId == 5 || _shirtId == -5) {
			rend.sprite = top5;
		} else if (_shirtId == 6 || _shirtId == -6) {
			rend.sprite = top6;
		} else if (_shirtId == 7 || _shirtId == -7) {
			rend.sprite = top7;
		} else if (_shirtId == 8 || _shirtId == -8) {
			rend.sprite = top8;
		} else if (_shirtId == 9 || _shirtId == -9) {
			rend.sprite = top9;
		} 	
	}
}
