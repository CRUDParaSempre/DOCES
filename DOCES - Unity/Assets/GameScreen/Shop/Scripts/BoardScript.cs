using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class BoardScript : MonoBehaviour {
	public SpriteRenderer notebook_base;
	public SpriteRenderer notebook_topo;
	public SpriteRenderer mesa;
	public SpriteRenderer cadeira;

	public Text preco1;
	public Text preco2;
	public Text preco3;
	public Text preco4;

	public List<Sprite> _renderers;
	public List<string> _nomes;
	public List<int> _tipos; 
	public List<int> _logicas;
	public List<int> _organizacoes;
	public List<int> _criatividades;
	public List<float> _precos;

	List<string> _items;
	public List<SpriteRenderer> _sprites;

	private int _idx = 0;
	private int _nb_itens;
	private int selectedItem;
	private int old_selected;

	// Use this for initialization
	void Start () {
		_nb_itens = _nomes.Count;

		updateItens ();
		selectedItem = -1;
		old_selected = -1;
	}
	
	// Update is called once per frame
	void Update () {
		if (selectedItem > -1) {
			if (selectedItem != old_selected) {
				if (old_selected > -1) {
					var old_color = _sprites [old_selected].color;
					_sprites [old_selected].color = new Color (old_color.r, old_color.g, old_color.b, 1.0f);
				}
				var color = _sprites [selectedItem].color;
				_sprites [selectedItem].color = new Color (color.r, color.g, color.b, 0.5f);
				old_selected = selectedItem;
			}
		}
	}

	void updateItens(){
		for(var i = 0; i < 4; ++i){
			var idx = _idx + i;
			idx = idx % _nb_itens;
			_sprites [i].sprite = _renderers [idx];
		}
		preco1.text = _precos [_idx].ToString();
		preco2.text = _precos [_idx+1].ToString();
		preco3.text = _precos [_idx+2].ToString();
		preco4.text = _precos [_idx+3].ToString();
	}

	public void incrementIndex(){
		_idx += 1;
		_idx = _idx % _nb_itens;
		updateItens();
	}

	public void decrementIndex(){
		_idx -= 1;
		_idx = _idx % _nb_itens;

		for(var i = 0; i < 4; ++i){
			var idx = _idx + i;
			idx = idx % _nb_itens;
			_sprites [i].sprite = _renderers [idx];
		}
	}

	public void selecionaItem(int index) {
		selectedItem = index;
	}

	public void compraItem(){
		// TODO
	}
}
