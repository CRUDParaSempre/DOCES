using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ObjectBoardScript))]
[RequireComponent(typeof(EmployeeBoardScript))]
public class BoardScript : MonoBehaviour {
	ObjectBoardScript objectsScript;
	EmployeeBoardScript peopleScript;

	public bool people;

	// Use this for initialization
	void Start () {
		people = false;
		objectsScript = GetComponent<ObjectBoardScript> ();
		peopleScript = GetComponent<EmployeeBoardScript> ();
		objectsScript.updateItens ();
	}

	// Update is called once per frame
	void Update () {}

	public void incrementIndex(){
		if (people)
			peopleScript.incrementIndex ();
		else
			objectsScript.incrementIndex ();
	}

	public void decrementIndex(){
		if (people)
			peopleScript.decrementIndex();
		else
			objectsScript.decrementIndex();
	}

	public void selecionaItem(int index){
		if (people)
			peopleScript.selecionaItem(index);
		else
			objectsScript.selecionaItem(index);
	}

	public void compraItem(){
		if (people)
			peopleScript.compraItem();
		else
			objectsScript.compraItem();
	}

	public void changeToPeople(){
        Debug.Log("botao pessoas");
		if (!people) {
			people = true;
			peopleScript.enabled = true;
			peopleScript.updateItens ();
			objectsScript.enabled = false;
		}
	}

    public void changeToObjects() {
        Debug.Log("botao objetos");
        if (people) {
            people = false;
            objectsScript.enabled = true;
            objectsScript.updateItens();
            peopleScript.enabled = false;
        }
    }
}
