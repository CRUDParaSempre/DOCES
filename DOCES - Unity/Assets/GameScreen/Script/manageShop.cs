using UnityEngine;
using System.Collections;

public class manageShop : MonoBehaviour {
	private SpriteRenderer abaLoja, botaoFechar; 
	private GameObject obj;

	// Use this for initialization
	void Start () {
		obj = GameObject.Find("Shop");
      	//rend = obj.GetComponent<SpriteRenderer> ();
      	//rend.enabled = false;	
      	obj.active = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateState(){
		obj.active = !obj.active;
	}
}
