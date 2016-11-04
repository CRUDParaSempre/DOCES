using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class ChangeSpriteColor : MonoBehaviour {
	private SpriteRenderer renderer;
	private Color color;

	private bool _canChangeColor = false;
	public bool canChangeColor{ set; get; }


	void Start() {
		renderer = GetComponent<SpriteRenderer> ();
		_canChangeColor = false;
	}

	void OnColorChange(HSBColor color) {
		if (_canChangeColor) {
			renderer.color = color.ToColor ();
		}
	}

	public void isAbleToChangeColor(bool value) {
		_canChangeColor = value;
	}

	public Color getColor() {
		return renderer.color;
	}
}
