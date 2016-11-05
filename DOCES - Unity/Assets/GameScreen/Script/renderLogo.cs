 using UnityEngine;
 using System.Collections;
 
 public class renderLogo : MonoBehaviour {
 
 	[SerializeField] private int id = 0;
 	public Sprite logo0;
 	public Sprite logo1;
 	public Sprite logo2;
 	public Sprite logo3;
 	public Sprite logo4;
 	public Sprite logo5;
 	private SpriteRenderer rend;
 	public SpriteRenderer logo;
 
 	// Use this for initialization
 	public void Start () {
 		rend = logo.GetComponent<SpriteRenderer> ();
		GameObject obj = GameObject.Find("GameStateManager");
		GameStateManager gsm = obj.GetComponent<GameStateManager>();
		id = gsm.getLogoId();
 	}
 	
 	// Update is called once per frame
 	void Update () {
 		
 		
 		if (id == 0) {
 			rend.sprite = logo0;
 		} else if (id == 1 || id == -1) {
 			rend.sprite = logo1;
 		} else if (id == 2 || id == -2) {
 			rend.sprite = logo2;
 		} else if (id == 3 || id == -3) {
 			rend.sprite = logo3;
 		} else if (id == 4 || id == -4) {
 			rend.sprite = logo4;
 		} else if (id == 5 || id == -5) {
 			rend.sprite = logo5;
 		}
 	
 	}
 }