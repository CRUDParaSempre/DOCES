using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardScript : MonoBehaviour {
	public SpriteRenderer notebook_base;
	public SpriteRenderer notebook_topo;
	public SpriteRenderer mesa;
	public SpriteRenderer cadeira;

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

	// Use this for initialization
	void Start () {
		_nb_itens = _nomes.Count;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void incrementIndex(){
		_idx += 1;
		_idx = _idx % _nb_itens;

		for(var i = 0; i < 4; ++i){
			var idx = _idx + i;
			idx = idx % _nb_itens;
			_sprites [i].sprite = _renderers [idx];
		}
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
}
