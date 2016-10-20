using UnityEngine;
using System.Collections;

public class HairScript : MonoBehaviour {

	public int value;
	public Sprite cabelo0;
	private SpriteRenderer rend;
	public SpriteRenderer cabelo;

	// Use this for initialization
	void Start () {
		rend = cabelo.GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {

	}
}
