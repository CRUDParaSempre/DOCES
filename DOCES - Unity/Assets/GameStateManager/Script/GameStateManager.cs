﻿//Created by Marcelo Gomes  (06/11/16) | Revised by: ?

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Fungus;

public class GameStateManager : MonoBehaviour {
	private static GameStateManager instance;

	public enum GameState { Menu, Selection, GameClient, GameOffice, GameQuiz, GameCards, ProjectResults, Tutorial, GameOver }
	private GameState previousState = GameState.Menu;
	[SerializeField]private GameState _gameState = GameState.Menu;
	public GameState gameState {
		get { return _gameState; }
	}

	private int _credibility = 10;
	public int credibility {
		get { return _credibility; }
	}

	[SerializeField] private WarningManager warning;
	[SerializeField] private TutorialManager tutorial;

	[SerializeField] private Flowchart cameraFlowchart;
	[SerializeField] private string shakeScreenBlock;

	private int weeksWithoutClient = 0;
	private int clientWeek = 0;
	public int projectStartWeek {
		get { return clientWeek; }
	}

	private string _clientName;
	public string clientName {
		get { return _clientName; }
	}

	[SerializeField] private List<bool> tutorialMessages;

	public bool hasClient = false;
	[SerializeField] private GameObject clientCanvas;
	[SerializeField] private GameObject sprintCanvas;
	[SerializeField] private GameObject doorButton;
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
	private int _golpinhos = 1000;

	private List<Color> _colorIds = new List<Color> (){Color.white,Color.white,Color.white,Color.white,Color.white,Color.white}; //0 = skin, 1 = eyes, 2 = hair, 3 = shirt, 4 = pants, 5 = shoes
	[SerializeField] private CardsManager cardsManager;

	[SerializeField] private int _projectPayment = 0;
	public int projectPayment {
		get{ return _projectPayment; }
	}

	[SerializeField] private string _projectDifficulty = null;
	public string projectDifficulty {
		get{ return _projectDifficulty; }
	}

	[SerializeField] private int _projectDeadline = 0;
	public int projectDeadline {
		set { _projectDeadline = value; }
		get { return _projectDeadline; }
	}

	[SerializeField] private List< List<int> > _projectScores;
	public List< List<int> > projectScores {
		get { return _projectScores; }
	}

	[SerializeField] private List<int> _projectGoals;
	public List<int> projectGoals {
		get { return _projectGoals; }
	}

	[SerializeField] private List<int> _projectMaxGoals;
	public List<int> projectMaxGoals {
		get { return _projectMaxGoals; }
	}

	[SerializeField] private List<float> _difficultyRatio;

	[SerializeField] private float timeSpeed = 1f;
	[SerializeField] private float timePerWeek = 60f;
	private float lastWeekAdvance = 0f;
	[SerializeField] private int _currentWeek = 0 ;
	[SerializeField] private GameObject quizCanvas;
	[SerializeField] private int quizQuestions=0;
	public int currentWeek {
		get { return _currentWeek; }
	}

	[SerializeField] private GameObject resultsCanvas;
	[SerializeField] private GameObject gameOverCanvas;
	[SerializeField] public Text gameOverText;

	public Text weekUI;
	public Text monthYearUI;
	public Text golpinhosUI;
	public Text credibilidadeUI;


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
		set{ _golpinhos = value; }
		get{ return _golpinhos; }
	}

	public int gender { 
		set{ _gender = value; }
		get{ return _gender; }
	} 

	// Use this for initialization
	void Start () {
		_projectScores = new List<List<int>> ();
		for (int i = 0; i < 5; i++) {
			_projectScores.Add (new List<int> ());
		}

		golpinhosUI.text = "G$ " + moneyToString(_golpinhos);
		credibilidadeUI.text = _credibility.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		golpinhosUI.text = "G$ " + moneyToString(_golpinhos);
		if (gameState == GameState.Selection) {
		
			if (!tutorialMessages[6]) {
				tutorialMessages[6] = true;

				List<string> l = new List<string> ();
				l.Add ("Bem vindo ao Minha Empresa!");
				l.Add ("Nessa tela você poderá personalizar seu persongem e, logo em seguida, sua empresa.");
				l.Add ("Os pontos de habilidade irão impactar na sua capacidade de realizar ações dentro do jogo...");
				l.Add ("DICA: distribua os pontos sabiamente!!");
				tutorial.showTutorialAtPosition (l,26f,261f,977f,491f,true,0.5f); 

			}
		
		} else if (gameState == GameState.GameOffice) {
			
			if (_credibility < 0) {
				Camera.main.backgroundColor = Color.black;
				Camera.main.GetComponent<SetCameraPosition> ().setCameraPosition(0,0,0);

				setGameState (GameState.GameOver);
				gameOverCanvas.SetActive (true);
				gameOverText.text = _companyName + " faliu!";
			
			} else if (_credibility >= 100) {
				Camera.main.backgroundColor = Color.black;
				Camera.main.GetComponent<SetCameraPosition> ().setCameraPosition(0,0,0);

				setGameState (GameState.GameOver);
				gameOverCanvas.SetActive (true);
				gameOverText.color = Color.green;
				gameOverText.text = _companyName + " é uma empresa de sucesso!";
			
			}
						
			
			if (currentWeek == 0 && !tutorialMessages[0]) {
				tutorialMessages[0] = true;
		
				List<string> l = new List<string> ();
				l.Add ("Olá " + _playerName + "! Agora que você já criou a "+ _companyName+", está na hora de fazer ela bombar!");
				l.Add ("Nessa parte da tela, é possível ver seus status...");
				l.Add ("À esquerda, você pode ver a quantidade de Golpinhos (G$) que sua empresa possui...");
				l.Add ("No centro está a credibilidade da " + _companyName + ". O objetivo do jogo é atingir 100 pontos de credibilidade...");
				l.Add ("CUIDADO! Se a sua credibilidade ficar menor que 0, nenhum cliente procurará a " + _companyName + " ...");
				l.Add ("À direita está o calendário. Nele você pode ver a semana em que você está.");
				tutorial.showTutorialAtPosition (l,133.5f,17f,831f,85f,false,0.5f); 

			} else if (currentWeek == 0 && !tutorialMessages[1]) {
				tutorialMessages[1] = true;

				List<string> l = new List<string> ();
				l.Add ("Quando a " + _companyName + " receber um novo cliente, ele irá tocar a campainha...");
				l.Add ("Quanto mais credibilidade você tiver, mais rápido os clientes vão aparecer...");
				l.Add ("A "+ _companyName +" é a mais nova startup da área. Então, não se preocupe se o primeiro cliente demorar para chegar...");
				l.Add ("LEMBRE-SE: Assim que a campainha tocar, você deve clicar na porta para recebê-lo, ou o cliente irá embora!");
				tutorial.showTutorialAtPosition (l,0f,273f,263f,324f,true,1f);

			} 

			if (canCreateClient ()) {
				newClient ();
			}
				
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
	public void newClient() {

		cameraFlowchart.ExecuteBlock (shakeScreenBlock);

		if (!tutorialMessages [2]) {
			tutorialMessages[2] = true;

			List<string> l = new List<string> ();
			l.Add ("Olha! Um novo cliente chegou! Clique na porta para recebê-lo.");
			tutorial.showTutorialAtPosition (l,0f,273f,263f,324f,true,1f);
		}

		clientWeek = currentWeek;
		hasClient = true;
		doorButton.GetComponent<DoorManager> ().activateDoor ();

	}

	public void playerReceivedClient() {

		if (hasClient) {
			clientCanvas.SetActive (true);

			if (!tutorialMessages [3]) {
				tutorialMessages[3] = true;

				List<string> l = new List<string> ();
				l.Add ("Antes de aceitar o cliente, lembre-se de ler todo o contrado!");
				l.Add ("Afinal, podem ter projetos muito complexos para uma startup tão nova.");
				tutorial.showTutorialAtPosition (l,21f,71f,813f,555,false,0.5f);
			}
		
		} else {
			warning.showWarning ("Não há propostas de cliente!");
		}
	}

	public string newClientDifficulty {
		get{
			List<float> difProbs = new List<float> ();
			float sum = 0f;

			difProbs.Add (((_credibility < 50) ? (-1f / 50f * _credibility) + 1 : 0f));
			sum += difProbs [0];

			difProbs.Add (((_credibility < 50) ? (9f / 500f * _credibility) + 1f / 10f : (-9f / 500f * _credibility) + 19f / 10f));
			sum += difProbs [1];

			difProbs.Add (((_credibility > 50) ? (1f / 50f * _credibility) - 1 : 0f));
			sum += difProbs [2];

			for (int i = 0; i < difProbs.Count; i++) {
				difProbs [i] = normalize (sum, difProbs [i]);
			}

			float random = Random.value;

			if (random >= 0 && random < difProbs [0]) {
				return "Baixa";			
			} else if (random >= difProbs [0] && random < difProbs [0] + difProbs [1]) { 
				return "Média";			
			} else if (random >= difProbs [0] + difProbs [1] && random < difProbs [0] + difProbs [1] + difProbs [2]) {
				return "Alta";			
			}

			Debug.LogError ("Erro ao determinar dificuldade do cliente!");
			return "Baixa";
		}
	}

	public string newQuestionDifficulty {
		get{
			List<float> difProbs = new List<float> ();
			float sum = 0f;

			difProbs.Add ( (-9f / 1000f * _credibility) + 1 );
			sum += difProbs [0];

			difProbs.Add (.7f);
			sum += difProbs [1];

			difProbs.Add ( (9f / 1000f * _credibility) + 1f/10f );
			sum += difProbs [2];

			for (int i = 0; i < difProbs.Count; i++) {
				difProbs [i] = normalize (sum, difProbs [i]);
			}

			float random = Random.value;

			if (random >= 0 && random < difProbs [0]) {
				return "Fácil";			
			} else if (random >= difProbs [0] && random < difProbs [0] + difProbs [1]) { 
				return "Média";			
			} else if (random >= difProbs [0] + difProbs [1] && random < difProbs [0] + difProbs [1] + difProbs [2]) {
				return "Difícil";			
			}

			Debug.LogError ("Erro ao determinar dificuldade do cliente!");
			return "Baixa";
		}
	}

	private float normalize(float a, float b){
		return b / a;
	}

	//verifica se é possivel criar um novo cliente para o player
	private bool canCreateClient() {
		float chanceOfClient = (Mathf.Min((weeksWithoutClient * 10f) + credibility, 100f))/ 100f;
		float rand = Random.value;
			
			
		if(!hasClient && currentWeek > 1 && clientWeek < currentWeek && gameState == GameState.GameOffice && rand < chanceOfClient ) {
			return true;
		}

		return false;
	}

	public void removeClientProposal () {
		hasClient = false;
		doorButton.GetComponent<DoorManager> ().desactivateDoor ();
		weeksWithoutClient = 0;
	}

	public void startGame() {
		_gameState = GameState.GameOffice;
		lastWeekAdvance = Time.time;
		_currentWeek = 0;
	}

	public void setGameState(GameState state) {
		//Debug.Log ("Estado atual: " + _gameState + " Proximo estado: " + state );
		GameState temp = _gameState;

		if (_gameState == GameState.Menu && state == GameState.Selection) {
			_gameState = state;
		
		} else if((_gameState == GameState.Selection && state == GameState.Menu) || (_gameState == GameState.Selection && state == GameState.GameOffice)  ) {
			_gameState = state;

		} else if((_gameState == GameState.GameOffice && state == GameState.Menu) || (_gameState == GameState.GameOffice && state == GameState.GameClient) || (_gameState == GameState.GameOffice && state == GameState.GameOver)  ) {
			_gameState = state;

		} else if((_gameState == GameState.GameClient && state == GameState.Menu) || (_gameState == GameState.GameClient && state == GameState.GameOffice) || (_gameState == GameState.GameClient && state == GameState.GameQuiz)  ) {
			_gameState = state;

		} else if((_gameState == GameState.GameQuiz && state == GameState.Menu) || (_gameState == GameState.GameQuiz && state == GameState.GameCards) ) {
			_gameState = state;

		} else if((_gameState == GameState.GameCards && state == GameState.Menu) || (_gameState == GameState.GameCards && state == GameState.ProjectResults) || (_gameState == GameState.GameCards && state == GameState.GameQuiz) ) {
			_gameState = state;

		} else if((_gameState == GameState.ProjectResults && state == GameState.Menu) || (_gameState == GameState.ProjectResults && state == GameState.GameOffice) ) {
			_gameState = state;

		} else if(state == GameState.Tutorial) {
			_gameState = state;

		} else if((_gameState == GameState.Tutorial && state == previousState) ) {
			_gameState = state;

		} 

		previousState = temp;

	}

//	public void addProjectScores(List<int> scores) {
//		for (int i = 0; i < scores.Count; i++) {
//			_projectScores [i] += scores [i];
//		}
//	}

	public void addProjectScores(int score, int id) {
		//Debug.Log ("Adding " + score + " points to " + id);
		_projectScores [id].Add(score);
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

		quizQuestions = Random.Range (1,3);

		_bonusCre = 0;
		_bonusLog = 0;
		_bonusOrg = 0;

		if (_gameState == GameState.GameQuiz) {
			quizCanvas.GetComponent<QuizManager> ().newQuestion ();
		}

		if (!tutorialMessages [4]) {
			tutorialMessages[4] = true;

			List<string> l = new List<string> ();
			l.Add ("Vamos começar o nosso primeiro projeto!");
			l.Add ("Para desenvolver um projeto, você deve passar por etapas (corridas)...");
			l.Add ("No início de cada corrida, você terá a oportunidade de ganhar prêmios...");
			l.Add ("Mas, para isso, você terá que acertar as perguntas do quiz!");
			l.Add ("LEMBRE-SE: os pontos só valerão para a corrida atual, porém os golpinhos serão adicionados diretamente ao caixa da empresa.");
			tutorial.showTutorialAtPosition (l,56f,236f,931f,480f,true,0.5f);
		}
	}

	public void newClientAccepted(string clientName, int deadline, int payment, string difficulty) {
		_clientName = clientName;
		_projectDeadline = deadline + currentWeek;
		_projectDifficulty = difficulty;
		_projectPayment = payment;

		for (int i = 0; i < _projectMaxGoals.Count; i++) {
			_projectMaxGoals [i] = 0;
		}

		removeClientProposal ();

		initializeQuiz ();
	}

	public void newClientRejected() {
		removeClientProposal ();
		setGameState (GameState.GameOffice);
	}

	public void playerAnswered(List<int> bonus, bool isPlayerRight) {
	//	Debug.Log ("Respondi uma pergunta!");

		if (isPlayerRight) {
			_bonusCre += bonus [0];
			_bonusLog += bonus [1];
			_bonusOrg += bonus [2];
			_golpinhos += bonus [3];
		}

		//ainda ha questões para perguntar
		if ( --quizQuestions > 0) {
			if (_gameState == GameState.GameQuiz) {
				quizCanvas.GetComponent<QuizManager> ().newQuestion ();
			}

		//não há mais questoes, mova para o sprint
		} else {
			quizCanvas.gameObject.SetActive (false);
			setGameState (GameState.GameCards);

			if (_gameState == GameState.GameCards) {
				sprintCanvas.gameObject.SetActive (true);

				if (!tutorialMessages [5]) {
					tutorialMessages[5] = true;

					List<string> l = new List<string> ();
					l.Add ("É nesta tela que a ação realmente acontece...");
					l.Add ("Nela, você deve escolher o que você e/ou sua equipe fará...");
					l.Add ("Para realizar uma ação, você precisar selecionar uma carta...");
					l.Add ("Para isso, basta clicar duas vezes em cima dela....");
					l.Add ("Você pode aumentar o tamanho da carta clicando uma vez sobre ela.");
					l.Add ("Depois que você selecionar todas as cartas desejadas para essa corrida, clique no botão \"Pronto\".");
					l.Add ("LEMBRE-SE: seu projeto será avaliado em cada área (Requisitos, Análise, Desenho, Implementação e Testes). Tente atingir o maior número de pontos possíveis em cada área.");
					tutorial.showTutorialAtPosition (l,87f,181f,855f,500f,true,0.5f);
				}


			} else {
				Debug.LogError ("Não foi possivel entrar no estado da corrida!");
			}
		}
	}

	public void sprintFinished() {

		//não terminei o projeto
		if (++_currentWeek < _projectDeadline) {
			initializeQuiz ();

		//terminei o projeto
		} else {
			//inicializar a tela de resultados
			setGameState(GameState.ProjectResults);

			if (_gameState == GameState.ProjectResults) {
				resultsCanvas.GetComponent<ResultsManager> ().showProjectResults ();
			}
		}
	}

	public void calculateProjectGoals() {
		for (int i = 0; i < _projectGoals.Count; i++) {
			_projectGoals [i] = (int)Mathf.Round( _projectMaxGoals [i] * _difficultyRatio [difficultyToId (_projectDifficulty)]);
		}
	}

	private int difficultyToId(string difficulty) {
		if (difficulty.ToLower ().CompareTo ("baixa") == 0) {
			return 0;
		
		} else if (difficulty.ToLower ().CompareTo ("média") == 0) {
			return 1;

		} else if (difficulty.ToLower ().CompareTo ("alta") == 0) {
			return 2;

		}

		Debug.LogError ("Dificuldade inválida (" + difficulty + ") !");
		return 0;
	}

	public void finalResults(int golpinhos, int credibility) {
		_golpinhos += golpinhos;
		golpinhosUI.text = "G$ " + moneyToString(_golpinhos);
		_credibility += credibility;
		credibilidadeUI.text = _credibility.ToString();

		setGameState (GameState.GameOffice);
		resultsCanvas.SetActive (false);
	}

	public string moneyToString(int payment) {
		string parsing = payment.ToString ();
		string reverseResult = "00,";
		int count = 0;
		//3210
		//2000
		for (int i = parsing.Length-1 ; i >= 0 ; i--) {
			if (count++ % 3 == 0 && i !=parsing.Length-1 ) {
				reverseResult += ("." + parsing [i]);
			} else {
				reverseResult += parsing [i];
			}
		}

		string result = "";
		for (int i = reverseResult.Length - 1; i >= 0; i--) {
			result += reverseResult [i];
		}

		return result;
	}

	public void tutorialFinished(){

		setGameState (previousState);

	}


	public void subtractMoney(int value){
	
		_golpinhos -= value;

		golpinhosUI.text = "G$ " + moneyToString(_golpinhos);
	}


	public void enableTutorial(){
	
		for(int i = 0; i < tutorialMessages.Count; i++){

			tutorialMessages [i] = false;

		}
	
	}

}


//gameoffice
// cri = 5, org = 5, log = 5, gol = 100
//gamequizz (cri + 1 , log + 1 , org + 0, gol + 10)
//gamecards (cri = 6, log = 6, org = 5, gol = 110) [nao gastou golpinhos]
//gamequiz (cri=log-org=gol=0)
//gamecards (cri = 5, log = 5, org = 5, gol = 100
