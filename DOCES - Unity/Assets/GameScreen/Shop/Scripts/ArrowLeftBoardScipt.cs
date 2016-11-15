using UnityEngine;
using System.Collections;

public class ArrowLeftBoardScipt : MonoBehaviour {

    public BoardScript _boardScript;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void OnMouseDown() {
        _boardScript.decrementIndex();
    }
}
