using UnityEngine;
using System.Collections;

public class TopScript : MonoBehaviour {

	public int value;
	public Sprite blusa0;
	private SpriteRenderer rend;
	public SpriteRenderer blusa;

	// Use this for initialization
	void Start () {
		rend = blusa.GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
