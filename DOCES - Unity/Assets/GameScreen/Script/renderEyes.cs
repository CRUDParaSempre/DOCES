using UnityEngine;
using System.Collections;

public class renderEyes : MonoBehaviour {
	
	private Color col;
	private SpriteRenderer rend;
	public SpriteRenderer eyes;

	// Use this for initialization
	public void Start () {
		rend = eyes.GetComponent<SpriteRenderer> ();
		GameObject obj = GameObject.Find("GameStateManager");
		GameStateManager stateManager = obj.GetComponent<GameStateManager>();
		col = stateManager.getItemColor (GameStateManager.Colorable.Eyes);
	}
	
	// Update is called once per frame
	void Update () {
		rend.color = col;
	}
}
