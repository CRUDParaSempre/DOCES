using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class GameStateManager : MonoBehaviour {

	private string _playerName = null;
	private string _companyName = null;
	private int _logoId = 0;
	private int _hairId = 0;
	private int _shirtId = 0;
	private int _shoesId = 0;
	private int _pantsId = 0;
	private int _frascoT = 0;
	private int _frascoO = 0;
	private int _frascoL = 0;
	private int _frascoC = 0;
	private int _gender = 0;

	private static GameStateManager instance;

	private GameStateManager() {}

	public static GameStateManager Instance{
		get{
			if (instance == null){
				instance = (GameObject.Find("Managers").GetComponentInChildren<GameStateManager>());
			}
			return instance;
		}
	}

	public enum Colorable {
		Skin, Eyes, Hair, Shirt, Pants, Shoes
	}

	private List<Color> _colorIds = new List<Color> (){Color.white,Color.white,Color.white,Color.white,Color.white,Color.white}; //0 = skin, 1 = eyes, 2 = hair, 3 = shirt, 4 = pants, 5 = shoes

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

	public int hairId { 
		set{ _hairId = value; }
		get{ return _hairId; }
	}

	public int shirtId { 
		set{ _shirtId = value; }
		get{ return _shirtId; }
	}

	public int pantsId { 
		set{ _pantsId = value; }
		get{ return _pantsId; }
	}

	public int shoesId { 
		set{ _shoesId = value; }
		get{ return _shoesId; }
	}

	public int frascoT { 
		set{ _frascoT = value; }
		get{ return _frascoT; }
	}

	public int frascoO { 
		set{ _frascoO = value; }
		get{ return _frascoO; }
	}

	public int frascoL { 
		set{ _frascoL = value; }
		get{ return _frascoL; }
	}

	public int frascoC { 
		set{ _frascoC = value; }
		get{ return _frascoC; }
	}

	public int gender { 
		set{ _gender = value; }
		get{ return _gender; }
	} 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void setLogoId (int logoId){
		//Debug.Log ("Salvando logo Id " + logoId);
		this._logoId = logoId;
	}

	public int getLogoId (){
		return _logoId;
	}

	public void setHairId (int hairId){
		Debug.Log ("Salvando hair Id " + hairId);
		this._hairId = hairId;
	}

	public int getHairId(){
		return _hairId;
	}

	public void setShirtId (int shirtId){
		Debug.Log ("Salvando shirt Id " + shirtId);
		this._shirtId = shirtId;
	}

	public int getShirtId(){
		return _shirtId;
	}

	public void setPantsId (int pantsId){
		Debug.Log ("Salvando pants Id " + pantsId);
		this._pantsId = pantsId;
	}

	public int getPantsId(){
		return _pantsId;
	}

	public void setShoesId (int shoesId){
		Debug.Log ("Salvando shoes Id " + shoesId);
		this._shoesId = shoesId;
	}

	public int getShoesId(){
		return _shoesId;
	}

	public void setFrascoT (int frascoT){
		Debug.Log ("Salvando Frasco T " + frascoT);
		this._frascoT = frascoT;
	}

	public void setFrascoL (int frascoL){
		Debug.Log ("Salvando Frasco L " + frascoL);
		this._frascoL = frascoL;
	}

	public void setFrascoO (int frascoO){
		Debug.Log ("Salvando Frasco O " + frascoO);
		this._frascoO = frascoO;
	}

	public void setFrascoC (int frascoC){
		Debug.Log ("Salvando Frasco C " + frascoC);
		this._frascoC = frascoC;
	}

	public void addItemColor(Colorable item, Color c) {
		_colorIds [colorableToId (item)] = c;
	}

	public Color getItemColor (Colorable item) {
		return _colorIds [colorableToId (item)];
	}

	private int colorableToId(Colorable c) {
		if (c == Colorable.Skin) {
			return 0;
		
		} else if (c == Colorable.Eyes) {
			return 1;

		} else if (c == Colorable.Hair) {
			return 2;

		} else if (c == Colorable.Shirt) {
			return 3;
		
		} else if (c == Colorable.Pants) {
			return 4;

		} else if (c == Colorable.Shoes) {
			return 5;

		}

		Debug.LogError ("GameStateManager: colorable not found");

		return -1;
	}

	public void setGender (int item){
		// 0 para mulher
		// 1 para homem
		this._gender = item;
		Debug.Log ("setando sexo para " + _gender);
	}

	public int getGender (){
		return gender;
	}
}
