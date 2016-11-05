using UnityEngine;
using System.Collections;

public class renderShoes : MonoBehaviour {
	private int _shoesId;
	public Sprite shoe0;
	public Sprite shoe1;
	public Sprite shoe2;
	public Sprite shoe3;
	private SpriteRenderer rend;
	public SpriteRenderer shoe;
	// Use this for initialization
	public void Start () {
		rend = shoe.GetComponent<SpriteRenderer> ();
		GameObject obj = GameObject.Find("GameStateManager");
		GameStateManager stateManager = obj.GetComponent<GameStateManager>();
		_shoesId = stateManager.getShoesId ();
	}

	// Update is called once per frame
	void Update () {
		if (_shoesId== 0) {
			rend.sprite = shoe0;
		} else if (_shoesId== 1 || _shoesId== -1) {
			rend.sprite = shoe1;
		} else if (_shoesId== 2 || _shoesId== -2) {
			rend.sprite = shoe2;
		} else if (_shoesId== 3 || _shoesId== -3) {
			rend.sprite = shoe3;
		} 
	}
}
