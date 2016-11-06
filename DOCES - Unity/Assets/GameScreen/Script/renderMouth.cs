using UnityEngine;
using System.Collections;

public class renderMouth : MonoBehaviour {
	private int _sexo;
	public Sprite mouthF;
	public Sprite mouthM;
	private SpriteRenderer rend;
	public SpriteRenderer mouth;

	// Use this for initialization
	public void Start () {
		rend = mouth.GetComponent<SpriteRenderer> ();
		GameObject obj = GameObject.Find("GameStateManager");
		GameStateManager stateManager = obj.GetComponent<GameStateManager>();
		_sexo = stateManager.getSexo ();
	}
	
	// Update is called once per frame
	void Update () {
		if (_sexo == 0) {
			rend.sprite = mouthF;
		} else {
			rend.sprite = mouthM;
		}
	}
}
