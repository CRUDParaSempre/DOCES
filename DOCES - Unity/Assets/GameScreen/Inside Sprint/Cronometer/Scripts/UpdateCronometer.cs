using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateCronometer : MonoBehaviour {
	private int currentWeek;
	private int projectDeadline;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnEnable() {
		currentWeek = GameStateManager.Instance.currentWeek;
		projectDeadline = GameStateManager.Instance.projectDeadline;

		GameObject fillBar = transform.GetChild (2).gameObject;
		Text text = GetComponentInChildren<Text> ();

		fillBar.GetComponent<Image> ().fillAmount = ((float)(currentWeek)/(float)(projectDeadline-1));
		text.text = "Faltam " + ((projectDeadline-currentWeek)-1).ToString() + " corridas para a entrega";

	}
}
