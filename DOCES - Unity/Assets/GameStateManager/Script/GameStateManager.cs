using UnityEngine;
using System.Collections;

public class GameStateManager : MonoBehaviour {
	private string _playerName;
	private string _companyName;
	private int _logoId;
	private int _hairId;
	private int _shirtId;
	private int _shoesId;
	private int _pantsId;
	private int _frascoT;
	private int _frascoO;
	private int _frascoL;
	private int _frascoC;

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

	public int hairId { set; get; }
	public int shirtId { set; get; }
	public int pantsId { set; get; }
	public int shoesId { set; get; }
	public int frascoT { set; get; }
	public int frascoO { set; get; }
	public int frascoL { set; get; }
	public int frascoC { set; get; }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void setLogoId (int logoId){
		Debug.Log ("Salvando logo Id " + logoId);
		_logoId = logoId;
	}

	public void setHairId (int hairId){
		Debug.Log ("Salvando hair Id " + hairId);
		_hairId = hairId;
	}

	public void setShirtId (int shirtId){
		Debug.Log ("Salvando shirt Id " + shirtId);
		_shirtId = shirtId;
	}

	public void setPantsId (int pantsId){
		Debug.Log ("Salvando pants Id " + pantsId);
		_pantsId = pantsId;
	}

	public void setShoesId (int shoesId){
		Debug.Log ("Salvando shoes Id " + shoesId);
		_shoesId = shoesId;
	}

	public void setFrascoT (int frascoT){
		Debug.Log ("Salvando Frasco T " + frascoT);
		_frascoT = frascoT;
	}

	public void setFrascoL (int frascoL){
		Debug.Log ("Salvando Frasco L " + frascoL);
		_frascoL = frascoL;
	}

	public void setFrascoO (int frascoO){
		Debug.Log ("Salvando Frasco O " + frascoO);
		_frascoO = frascoO;
	}

	public void setFrascoC (int frascoC){
		Debug.Log ("Salvando Frasco C " + frascoC);
		_frascoC = frascoC;
	}
}
