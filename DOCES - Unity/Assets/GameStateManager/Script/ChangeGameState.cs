using UnityEngine;
using System.Collections;

public class ChangeGameState : MonoBehaviour {
	[SerializeField] private GameStateManager.GameState onEnableState;
	[SerializeField] private bool changeStateOnEnable = false;
	[SerializeField] private GameStateManager.GameState onDisableState;
	[SerializeField] private bool changeStateOnDisable = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnEnable() {
		if (changeStateOnEnable) {
			GameStateManager.Instance.setGameState (onEnableState);
		}
	}

	public void OnDisable() {
		if (changeStateOnDisable) {
			GameStateManager.Instance.setGameState (onDisableState);
		}
	}


}
