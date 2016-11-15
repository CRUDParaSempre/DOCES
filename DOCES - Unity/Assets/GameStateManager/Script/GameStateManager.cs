//Created by Marcelo Gomes  (06/11/16) | Revised by: ?

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Fungus;

public class GameStateManager : MonoBehaviour {
	private static GameStateManager instance;

	public enum GameState { Menu, Selection, GameClient, GameOffice, GameQuiz, GameCards, ProjectResults }
	[SerializeField]private GameState _gameState = GameState.Menu;
	public GameState gameState {
		get { return _gameState; }
	}

	private int _credibility = 10;
	public int credibility {
		get { return _credibility; }
	}

	[SerializeField] private Flowchart cameraFlowchart;
	[SerializeField] private string shakeScreenBlock;

	private int weeksWithoutClient = 0;
	private int clientWeek = 0;
	public string tempClient;
	[SerializeField] private GameObject sprintCanvas;
	[SerializeField] private string _playerName = "";
	[SerializeField] private string _companyName = "";
	private int _logoId = 0;
	private int _hairId = 0;
	private int _shirtId = 0;
	private int _shoesId = 0;
	private int _pantsId = 0;
	private int _frascoT = 0;
	[SerializeField] private int _frascoO = 0;
	[SerializeField] private int _frascoL = 0;
	[SerializeField] private int _frascoC = 0;
	[SerializeField] private int _bonusCre = 0;
	[SerializeField] private int _bonusLog = 0;
	[SerializeField] private int _bonusOrg = 0;

	private int _gender = 0;
	private int _golpinhos = 0;

	private List<Color> _colorIds = new List<Color> (){Color.white,Color.white,Color.white,Color.white,Color.white,Color.white}; //0 = skin, 1 = eyes, 2 = hair, 3 = shirt, 4 = pants, 5 = shoes
	[SerializeField] private CardsManager cardsManager;

	[SerializeField] private int _projectPayment = 0;
	public int projectPayment {
		get{ return _projectPayment; }
	}

	[SerializeField] private int _projectDeadline = 0;
	public int projectDeadline {
		set { _projectDeadline = value; }
		get { return _projectDeadline; }
	}

	[SerializeField] private List<int> _projectScores;
	public List<int> projectScores {
		get { return _projectScores; }
	}

	[SerializeField] private List<int> _projectGoals;
	public List<int> projectGoals {
		get { return _projectGoals; }
	}

	[SerializeField] private float timeSpeed = 1f;
	[SerializeField] private float timePerWeek = 60f;
	private float lastWeekAdvance = 0f;
	[SerializeField] private int _currentWeek = 0 ;
	[SerializeField] private GameObject quizCanvas;
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
		set { _playerName = value;} 
		get { return _playerName; }
	}

	public string companyName {
		set { _companyName = value; }
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

	public int bonusCre { 
		set{ _bonusCre= value; }
		get{ return _bonusCre; }
	}

	public int bonusLog { 
		set{ _bonusLog = value; }
		get{ return _bonusLog; }
	}

	public int bonusOrg { 
		set{ _bonusOrg= value; }
		get{ return _bonusOrg; }
	}

	public int organization { 
		get{ return _frascoO + _bonusOrg; }
	}

	public int frascoL { 
		set{ _frascoL = value; }
		get{ return _frascoL; }
	}

	public int logic { 
		get{ return _frascoL + _bonusLog; }
	}

	public int frascoC { 
		set{ _frascoC = value; }
		get{ return _frascoC; }
	}

	public int creativity { 
		get{ return _frascoC + _bonusCre; }
	}

	public int golpinhos { 
		get{ return _golpinhos; }
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
		if (gameState == GameState.GameOffice) { 
			if (canCreateClient ()) {
				newClient ();
			}

		} else if (gameState == GameState.GameClient && currentWeek > clientWeek) {
			removeClientProposal ();
		}

		if(gameState == GameState.GameOffice || gameState == GameState.GameClient) {
			if(Time.time - lastWeekAdvance > timePerWeek) {
				advanceTimeBy (1);
			}
		}
	}

	public void setLogoId (int logoId){
		//Debug.Log ("Salvando logo Id " + logoId);
		this._logoId = logoId;
	}

	public int getLogoId (){
		return _logoId;
	}

	public void setHairId (int hairId){
		//Debug.Log ("Salvando hair Id " + hairId);
		this._hairId = hairId;
	}

	public int getHairId(){
		return _hairId;
	}

	public void setShirtId (int shirtId){
		//Debug.Log ("Salvando shirt Id " + shirtId);
		this._shirtId = shirtId;
	}

	public int getShirtId(){
		return _shirtId;
	}

	public void setPantsId (int pantsId){
//		Debug.Log ("Salvando pants Id " + pantsId);
		this._pantsId = pantsId;
	}

	public int getPantsId(){
		return _pantsId;
	}

	public void setShoesId (int shoesId){
//		Debug.Log ("Salvando shoes Id " + shoesId);
		this._shoesId = shoesId;
	}

	public int getShoesId(){
		return _shoesId;
	}

	public void setFrascoT (int frascoT){
//		Debug.Log ("Salvando Frasco T " + frascoT);
		this._frascoT = frascoT;
	}

	public void setFrascoL (int frascoL){
//		Debug.Log ("Salvando Frasco L " + frascoL);
		this._frascoL = frascoL;
	}

	public void setFrascoO (int frascoO){
//		Debug.Log ("Salvando Frasco O " + frascoO);
		this._frascoO = frascoO;
	}

	public void setFrascoC (int frascoC){
//		Debug.Log ("Salvando Frasco C " + frascoC);
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
//		Debug.Log ("setando sexo para " + _gender);
	}

	public int getGender (){
		return gender;
	}

	public void advanceTimeBy ( int weeks ) {
		_currentWeek += (int)(Mathf.Round((weeks * timeSpeed)));
		lastWeekAdvance = Time.time;
		weekToDate ();

		if(gameState == GameState.GameOffice || gameState == GameState.GameClient) {
			weeksWithoutClient++;
		}
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

	public void startSprint() {
		if (gameState == GameState.GameQuiz) {
			_gameState = GameState.GameCards;
			sprintCanvas.SetActive (true);
		}
	}

	//oferece novo cliente para o player
	private void newClient() {
		_gameState = GameState.GameClient;
		cameraFlowchart.ExecuteBlock (shakeScreenBlock);

		tempClient = "Ola sou um novo cliente!";
		clientWeek = currentWeek;
	}

	//verifica se é possivel criar um novo cliente para o player
	private bool canCreateClient() {
		float chanceOfClient = (Mathf.Min((weeksWithoutClient * 10f) + credibility, 100f))/ 100f;
		float rand = Random.value;
			
			
		if(gameState == GameState.GameOffice && rand < chanceOfClient ) {
			return true;
		}

		return false;
	}

	public void removeClientProposal () {
		_gameState = GameState.GameOffice;
		tempClient = "";
	}

	public void startGame() {
		_gameState = GameState.GameOffice;
		lastWeekAdvance = Time.time;
		_currentWeek = 1;
	}

	public void setGameState(GameState state) {
		Debug.Log ("Estado atual: " + _gameState + " Proximo estado: " + state );
		if (_gameState == GameState.Menu && state == GameState.Selection) {
			_gameState = state;
		
		} else if((_gameState == GameState.Selection && state == GameState.Menu) || (_gameState == GameState.Selection && state == GameState.GameOffice)  ) {
			_gameState = state;

		} else if((_gameState == GameState.GameOffice && state == GameState.Menu) || (_gameState == GameState.GameOffice && state == GameState.GameClient)  ) {
			_gameState = state;

		} else if((_gameState == GameState.GameClient && state == GameState.Menu) || (_gameState == GameState.GameClient && state == GameState.GameOffice) || (_gameState == GameState.GameClient && state == GameState.GameQuiz)  ) {
			_gameState = state;

		} else if((_gameState == GameState.GameQuiz && state == GameState.Menu) || (_gameState == GameState.GameQuiz && state == GameState.GameCards) ) {
			_gameState = state;

		} else if((_gameState == GameState.GameCards && state == GameState.Menu) || (_gameState == GameState.GameCards && state == GameState.ProjectResults) || (_gameState == GameState.GameCards && state == GameState.GameQuiz) ) {
			_gameState = state;

		} else if((_gameState == GameState.ProjectResults && state == GameState.Menu) || (_gameState == GameState.ProjectResults && state == GameState.GameOffice) ) {
			_gameState = state;

		}
	}

	public void addProjectScores(List<int> scores) {
		for (int i = 0; i < scores.Count; i++) {
			_projectScores [i] += scores [i];
		}
	}

	public void addProjectScores(int score, int id) {
		Debug.Log ("Adding " + score + " points to " + id);
		_projectScores [id] += score;
	}

	public void addProjectScores(int score, string id) {
		int intId = 0;

		if (id.ToLower ().CompareTo ("requisitos") == 0) {
			intId = 0;
		} else if (id.ToLower ().CompareTo ("análise") == 0) {
			intId = 1;
		} else if (id.ToLower ().CompareTo ("desenho") == 0) {
			intId = 2;
		} else if (id.ToLower ().CompareTo ("desenvolvimento") == 0) {
			intId = 3;
		} else if (id.ToLower ().CompareTo ("testes") == 0) {
			intId = 4;
		} else {
			Debug.LogError ("ID do score( " + id + " ) é inválido!");
		}

		addProjectScores(score,intId);
	}

	public void initializeQuiz() {
		setGameState (GameState.GameQuiz);

		if (_gameState == GameState.GameQuiz) {
			quizCanvas.gameObject.SetActive (true);
		}
	}

	public void newClientAccepted(int deadline, int payment, List<int> goals) {
		_projectDeadline = deadline + currentWeek;
		_projectGoals = goals;
		_projectPayment = payment;

		initializeQuiz ();
	}

	public void newClientRejected() {
		_gameState = GameState.GameOffice;
	}
}


//gameoffice
// cri = 5, org = 5, log = 5, gol = 100
//gamequizz (cri + 1 , log + 1 , org + 0, gol + 10)
//gamecards (cri = 6, log = 6, org = 5, gol = 110) [nao gastou golpinhos]
//gamequiz (cri=log-org=gol=0)
//gamecards (cri = 5, log = 5, org = 5, gol = 100
