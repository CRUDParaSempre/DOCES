using UnityEngine;
using System.Collections;

public class GameStateManager : MonoBehaviour {
	private string _playerName;
	private string _companyName;
	private int _logoId;

	public string playerName {
		set; get;
	}

	public string companyName {
		set; get;
	}

	public int logoId {
		set;
		get;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void setLogoId (int logoId){
		_logoId = logoId;
	}
}
