using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Transform))]
public class ButtonScript : MonoBehaviour {

	public int offset;
	public Transform m_Transform;
	public Transform tm_Transform;

	private MeterScript m_Script;
	private TotalMeterScript tm_Script;

	// Use this for initialization
	void Start () {
		m_Script = m_Transform.gameObject.GetComponent<MeterScript> ();
		tm_Script = tm_Transform.gameObject.GetComponent<TotalMeterScript> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseDown(){
		int new_val = m_Script.value + offset;
		int new_val_total = tm_Script.value - offset;
		if (new_val <= 9 && new_val >= 0 && new_val_total <= 15 && new_val_total >= 0) {
			m_Script.value = new_val;
			tm_Script.value = new_val_total;
		}
	}
}
