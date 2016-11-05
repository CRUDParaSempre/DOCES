using UnityEngine;
using System.Collections;

public class renderSkin : MonoBehaviour {
	private Color col;

	private SpriteRenderer rendhead;
	public SpriteRenderer head;

	private SpriteRenderer rendarm;
	public SpriteRenderer arm;

	private SpriteRenderer rendbody;
	public SpriteRenderer body;

	private SpriteRenderer rendleg;
	public SpriteRenderer leg;

	private SpriteRenderer rendfeet;
	public SpriteRenderer feet;

	// Use this for initialization
	public void Start () {
		rendhead = head.GetComponent<SpriteRenderer> ();
		rendarm = arm.GetComponent<SpriteRenderer> ();
		rendbody = body.GetComponent<SpriteRenderer> ();
		rendleg = leg.GetComponent<SpriteRenderer> ();
		rendfeet = feet.GetComponent<SpriteRenderer> ();
		GameObject obj = GameObject.Find("GameStateManager");
		GameStateManager stateManager = obj.GetComponent<GameStateManager>();
		col = stateManager.getItemColor (GameStateManager.Colorable.Skin);
	}

	// Update is called once per frame
	void Update () {
		rendhead.color = col;
		rendarm.color = col;
		rendbody.color = col;
		rendleg.color = col;
		rendfeet.color = col;
	}
}
