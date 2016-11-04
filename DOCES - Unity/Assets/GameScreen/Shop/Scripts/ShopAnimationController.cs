using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class ShopAnimationController : MonoBehaviour {
	private bool shopEnabled = false;
	[SerializeField] private Animator anim;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void openShop() {
		anim.SetBool ("shopOpen",true);
	}

	public void closeShop() {
		anim.SetBool ("shopOpen",false);
	}
}
