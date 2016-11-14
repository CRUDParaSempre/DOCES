using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ClientManager : MonoBehaviour {
	[SerializeField] private Text nameText=null;
	[SerializeField] private Text descriptionText=null;
	[SerializeField] private Image previousButton=null;
	[SerializeField] private Image nextButton=null;
	[SerializeField] private Image acceptButton=null;
	[SerializeField] private Image denyButton=null;

	private List<string> projectTexts = new List<string>();
	private int index=0;

	private Color halfTransparent = new Color(1f,1f,1f,.5f);
	private Color opaque = new Color(1f,1f,1f,1f);


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void showClient(string name, List<string> texts) {
		Vector3 newPos;
		projectTexts = texts;

		//initialize text
		descriptionText.text = texts [0];
		nameText.text = name;

		//make previous tip unavailable
		previousButton.color = halfTransparent;
		previousButton.gameObject.GetComponent<CircleCollider2D> ().enabled = false;

		//hide accept/deny buttons
		acceptButton.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
		acceptButton.gameObject.SetActive (false);

		denyButton.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
		denyButton.gameObject.SetActive (false);

		this.gameObject.SetActive (true);
	}

	public void showClient(string name, string text) {
		List<string> l = new List<string> ();
		l.Add (text);

		showClient (name,l);
	}

	public void nextPage() {
		// 0  , 1 , 2
		// pg1,pg2,pg2
		// index=1

		//there is more than one page to show
		if (++index < projectTexts.Count-1) {
			descriptionText.text = projectTexts [index];
			previousButton.color = opaque;
			previousButton.gameObject.GetComponent<CircleCollider2D> ().enabled = true;

		//showing last page
		} else {
			descriptionText.text = projectTexts [index];

			previousButton.color = opaque;
			previousButton.gameObject.GetComponent<CircleCollider2D> ().enabled = true;

			nextButton.color = halfTransparent;
			nextButton.gameObject.GetComponent<CircleCollider2D> ().enabled = false;

			acceptButton.gameObject.GetComponent<CircleCollider2D> ().enabled = true;
			acceptButton.gameObject.SetActive (true);
			denyButton.gameObject.GetComponent<CircleCollider2D> ().enabled = true;
			denyButton.gameObject.SetActive (true);
		}
	}

	public void previousPage() {

		//is showing last page, need to hide the buttons
		if( index-- == projectTexts.Count-1 ) {
			descriptionText.text = projectTexts [index];

			previousButton.color = opaque;
			previousButton.gameObject.GetComponent<CircleCollider2D> ().enabled = true;

			nextButton.color = opaque;
			nextButton.gameObject.GetComponent<CircleCollider2D> ().enabled = true;

			acceptButton.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
			acceptButton.gameObject.SetActive (false);

			denyButton.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
			denyButton.gameObject.SetActive (false);

		//there is a previous tip to show
		} else if (index > 0) {
				descriptionText.text = projectTexts [index];

		//we are at the first page
		} else {
			descriptionText.text = projectTexts [index];
			previousButton.color = halfTransparent;
			previousButton.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
		}
	}

	public void testClient() {
		List<string> l = new List<string> ();
		l.Add ("Tenho uma padaria chamada \"Cassetinho Fofo\" em Porto Alegre.");
		l.Add ("Meus clientes ADORAM TUDO, especialmente o pudim de passas.");
		l.Add ("Porém, ultimamente, os pudinzinhos andam acabando rápido demais!");
		l.Add ("Estou desconfiada do meu irmão, o Tonso, que é LOUCO por aqueles pudins de passas.");
		l.Add ("Produto:\nSoftware de controle de estoque e venda de produtos.\nExigência: Baixa.\nPrazo: 5 semanas.\nPagamento: G$ 2.000,00");

		showClient ("Margeret D'baguette",l);
	}

	public void acceptClient() {

	}

	public void refuseClient() {

	}
}

//currentWeek = 1
//projectDeadline = currentWeek + 5; (6)
//sprint1 semana1
//seprint2 semana2
//sprinte3 semana3
//sprint4 semana4
//sprint5 semana5
//semana 6 entrega