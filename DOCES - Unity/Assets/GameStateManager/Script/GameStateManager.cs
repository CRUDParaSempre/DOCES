//Created by Marcelo Gomes  (06/11/16) | Revised by: ?

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;



public class GameStateManager : MonoBehaviour {
	private static GameStateManager instance;

	private string _playerName = "";
	private string _companyName = "";
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
	private List<Color> _colorIds = new List<Color> (){Color.white,Color.white,Color.white,Color.white,Color.white,Color.white}; //0 = skin, 1 = eyes, 2 = hair, 3 = shirt, 4 = pants, 5 = shoes


	[SerializeField] private float timeSpeed = 1f;
	private int _currentWeek = 0 ;
	public int currentWeek {
		get { return _currentWeek; }
	}

	public Text weekUI;
	public Text monthYearUI;


	public enum Colorable {
		Skin, Eyes, Hair, Shirt, Pants, Shoes
	}
		
	private GameStateManager() {}

	public static GameStateManager Instance{
		get{
			if (instance == null){
				instance = (GameObject.Find("Managers").GetComponentInChildren<GameStateManager>());
			}
			return instance;
		}
	}
		
	public string playerName {
		set { Debug.Log ("Salvando nome para " + value); _playerName = value;} 
		get { return _playerName; }
	}

	public string companyName {
		set { Debug.Log ("Salvando nome da empresa para " + value); _companyName = value; }
		get { return _companyName; }
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

	public void advanceTimeBy ( int weeks ) {
		_currentWeek += (int)(Mathf.Round((weeks * timeSpeed)));
		weekToDate ();
	}

	private void weekToDate () {
		weekUI.text = "Semana " + (((_currentWeek + 4) % 4) + 1).ToString();
		monthYearUI.text = monthIdToString((((_currentWeek/4) + 12) % 12) + 1) + " / Ano " + (((_currentWeek) / 48) + 1).ToString();
	}

	private string monthIdToString ( int id ) {
		if( id >= 1 && id < 13) {
			if(id == 1) {
				return "Janeiro";
			} else if (id == 2 ) {
				return "Fevereiro";
			} else if (id == 3 ) {
				return "Março";
			} else if (id == 4 ) {
				return "Abril";
			} else if (id == 5 ) {
				return "Maio";
			} else if (id == 6 ) {
				return "Junho";
			} else if (id == 7 ) {
				return "Julho";
			} else if (id == 8 ) {
				return "Agosto";
			} else if (id == 9 ) {
				return "Setembro";
			} else if (id == 10 ) {
				return "Outubro";
			} else if (id == 11 ) {
				return "Novembro";
			} else if (id == 12 ) {
				return "Dezembro";
			}
		}

		Debug.LogError("Invalid month id!");
		return null;
	}

	public string getPlayerName(){
		return _playerName;
	}

	public string getCompanyName(){
		return _companyName;
	}

	public bool validatePlayerName(){
		if (_playerName.Length == 0)
			return false;
		else
			return true;
	}

	public bool validateCompanyName(){
		if (_companyName.Length == 0)
			return false;
		else
			return true;
	}
}
