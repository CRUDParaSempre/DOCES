using UnityEngine;
using System.Collections;

public class SetRotationClockwise : MonoBehaviour {

	[SerializeField] private bool clockwise = true;
    private Animator aController;

    public void SetClockwise() {
		aController.SetBool("clockwise", true); 
	}

    public void SetCounterClockwise() {
		aController.SetBool("clockwise", false); 
    }

	// Use this for initialization
	void Start () {
        aController = GetComponent<Animator>();    

		if (clockwise) {
			SetClockwise ();
		} else {
			SetCounterClockwise ();		
		}
            
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
