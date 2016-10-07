using UnityEngine;
using System.Collections;

public class GitLinkButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OpenLink(){
		Application.OpenURL ("https://github.com/CRUDParaSempre/DOCES/wiki");
	}
}
