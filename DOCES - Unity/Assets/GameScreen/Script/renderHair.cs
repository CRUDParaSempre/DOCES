using UnityEngine;
using System.Collections;

public class renderHair : MonoBehaviour {

	private int _hairId;

	public Sprite cabelo1;
	public Sprite cabelo2;
	public Sprite cabelo3;
	public Sprite cabelo4;
	public Sprite cabelo5;
	public Sprite cabelo6;
	public Sprite cabelo7;
	public Sprite cabelo8;
	public Sprite cabelo9;
	public Sprite cabelo10;
	public Sprite cabelo11;
	public Sprite cabelo12;
	public Sprite cabelo13;
	public Sprite cabelo14;
	public Sprite cabelo15;
	public Sprite cabelo16;
	public Sprite cabelo17;
	public Sprite cabelo18;
	public Sprite cabelo19;
	public Sprite cabelo20;
	public Sprite cabelo21;
	private SpriteRenderer rend;
	public SpriteRenderer Hair;

	void Test(){
	}

	// Use this for initialization
	public void Start () {
		rend = Hair.GetComponent<SpriteRenderer> ();
		GameObject obj = GameObject.Find("GameStateManager");
		GameStateManager stateManager = obj.GetComponent<GameStateManager>();
		_hairId = stateManager.getHairId ();
	}
	
	// Update is called once per frame
	void Update () {
		
		//Debug.Log ("hair " + _hairId);
		if (_hairId == 0 || _hairId == -0) {
			rend.sprite = cabelo1;
		} else if (_hairId == 1 || _hairId == -1) {
			rend.sprite = cabelo2;
		} else if (_hairId == 2 || _hairId == -2) {
			rend.sprite = cabelo3;
		} else if (_hairId == 3 || _hairId == -3) {
			rend.sprite = cabelo4;
		} else if (_hairId == 4 || _hairId == -4) {
			rend.sprite = cabelo5;
		} else if (_hairId == 5 || _hairId == -5) {
			rend.sprite = cabelo6;
		} else if (_hairId == 6 || _hairId == -6) {
			rend.sprite = cabelo7;
		} else if (_hairId == 7 || _hairId == -7) {
			rend.sprite = cabelo8;
		} else if (_hairId == 8 || _hairId == -8) {
			rend.sprite = cabelo9;
		} else if (_hairId == 9 || _hairId == -9) {
			rend.sprite = cabelo10;
		} else if (_hairId == 10 || _hairId == -10) {
			rend.sprite = cabelo11;
		} else if (_hairId == 11 || _hairId == -11) {
			rend.sprite = cabelo12;
		} else if (_hairId == 12 || _hairId == -12) {
			rend.sprite = cabelo13;
		} else if (_hairId == 13 || _hairId == -13) {
			rend.sprite = cabelo14;
		} else if (_hairId == 14 || _hairId == -14) {
			rend.sprite = cabelo15;
		} else if (_hairId == 15 || _hairId == -15) {
			rend.sprite = cabelo16;
		} else if (_hairId == 16 || _hairId == -16) {
			rend.sprite = cabelo17;
		} else if (_hairId == 17 || _hairId == -17) {
			rend.sprite = cabelo18;
		} else if (_hairId == 18 || _hairId == -18) {
			rend.sprite = cabelo19;
		} else if (_hairId == 19 || _hairId == -19) {
			rend.sprite = cabelo20;
		} else if (_hairId == 20 || _hairId == -20) {
			rend.sprite = cabelo21;
		}
	}
}
