using UnityEngine;
using System.Collections;

public class renderShoes : MonoBehaviour {
	private int _shoesId;
	private Color col;
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
		col = stateManager.getItemColor (GameStateManager.Colorable.Shoes);
	}

	// Update is called once per frame
	void Update () {
		rend.color = col;
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
