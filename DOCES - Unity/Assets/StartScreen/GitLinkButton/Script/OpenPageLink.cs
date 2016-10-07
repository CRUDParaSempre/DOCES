using UnityEngine;
using System.Collections;

public class OpenPageLink : MonoBehaviour {
	[SerializeField] private string link;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OpenLink(){
		Application.OpenURL (link);
		//"https://github.com/CRUDParaSempre/DOCES/wiki");
	}
}
