using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ObjectBoardScript : MonoBehaviour {

    public SpriteRenderer notebook;
    public SpriteRenderer mesa;
    public SpriteRenderer cadeira;

    public Text preco1;
    public Text preco2;
    public Text preco3;
    public Text preco4;

    public List<Sprite> _renderers;
    public List<Sprite> _thumbnails;
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
 
    private int curr_pc_idx = -1;
    private int curr_cadeira_idx = -1;
    private int curr_mesa_idx = -1;

	private bool call_start = false;

	[SerializeField] private WarningManager warning;

	// Tem algum item selecionado?
	private bool selected = false;
	// Se sim, ele está visivel?
	private bool isSelectedItemVisible = false;
	// Indice na janela de 4 itens
	private int selectedItemWindow;
	// Indice na lista
	private int selectedItem;
	// Tamanho da janela
	private int windowSize = 4;

    GameStateManager gsm;

    // Use this for initialization
    void Start() {
        GameObject obj = GameObject.Find("GameStateManager");
        gsm = obj.GetComponent<GameStateManager>();
		_nb_itens = _nomes.Count;

		selectedItemWindow = -1;
		selectedItem = 0;
        updateItens();
    }

    // Update is called once per frame
    void Update() { }

    public void updateItens() {

		if (call_start == false) {
			call_start = true;
			Start ();
		}

        for (var i = 0; i < 4; ++i) {
            var idx = _idx + i;
            idx = idx % _nb_itens;
//			Debug.Log ("[updateItems] nb_itens = " + _nb_itens);
            _sprites[i].sprite = _thumbnails[idx];
        }
        preco1.text = _precos[_idx].ToString();
        preco2.text = _precos[(_idx + 1)%_nb_itens].ToString();
        preco3.text = _precos[(_idx + 2)%_nb_itens].ToString();
        preco4.text = _precos[(_idx + 3)%_nb_itens].ToString();
    }

    public void incrementIndex() {
        _idx += 1;
		_idx = (_idx + _nb_itens) % _nb_itens;
//		Debug.Log ("incrementou _idx para " + _idx);

        updateItens();

		if (selected == true && isSelectedItemVisible == true) {
			deselectItem ();
			selectedItemWindow -= 1;
			//			Debug.Log ("Decrementou o selectedItemWindow para = " + selectedItemWindow);

			// verifica se o item selecionado previamente está na janela.
			if (selectedItemWindow >= 0) {
				selecionaItem (selectedItemWindow);
			} else {
				// fora da janela
				isSelectedItemVisible = false;
				selectedItemWindow = -1;
			}

		} else if (
			// Nao esta na janela de itens visiveis
			isSelectedItemVisible == false
			// E voltou para a janela
			&& insideWindow(selectedItem).Key) {

			isSelectedItemVisible = true;
			selectedItemWindow = insideWindow (selectedItem).Value;

			selecionaItem (selectedItemWindow);
		}

//        deselectItem();
//		selected = false;
    }

	public KeyValuePair<bool, int> insideWindow (int index){
		for (int i = 0; i < 4; i++) {
			if (index == ((_idx + i + _nb_itens) % _nb_itens))
				return new KeyValuePair<bool, int>(true, i);
		}

		return new KeyValuePair<bool, int>(false, -1);
	}

    public void decrementIndex() {
        _idx -= 1;
		_idx = (_idx + _nb_itens) % _nb_itens;


//		Debug.Log ("decrementou _idx para " + _idx);
//		Debug.Log ("selected = " + selected + "\nselectedItemWindow = " + selectedItemWindow + "\nselectedItem = " + selectedItem);
        updateItens();
 
		if (selected == true && isSelectedItemVisible == true) {
			deselectItem ();
			selectedItemWindow += 1;
//			Debug.Log ("Incrementou o selectedItemWindow para = " + selectedItemWindow);

			// verifica se o item selecionado previamente está na janela.
			if (selectedItemWindow < windowSize) {
				selecionaItem (selectedItemWindow);
			} else {
				// fora da janela
				isSelectedItemVisible = false;
				selectedItemWindow = -1;
			}

		} else if (
			// Nao esta na janela de itens visiveis
			isSelectedItemVisible == false
			// E voltou para a janela
			&& insideWindow(selectedItem).Key) {

			isSelectedItemVisible = true;
			selectedItemWindow = insideWindow (selectedItem).Value;

			selecionaItem (selectedItemWindow);
		}


    }

    public void selecionaItem(int index) {

		Debug.Log ("chamou o selecionaItem com index: " + index);

		if (selected == true && index == selectedItemWindow) {
			deselectItem ();
			selected = false;
			return;
		} else if (selected == true && index != selectedItemWindow) {
			deselectItem ();
		}

		// marca que item foi selecionado
		selected = true;
		// marca que item está visivel na janela de 4 itens
		isSelectedItemVisible = true;

		selectedItem = (index + _idx + _nb_itens) % _nb_itens;
        selectedItemWindow = index;
        var color = _sprites[selectedItemWindow].color;
        _sprites[selectedItemWindow].color = new Color(color.r, color.g, color.b, 0.5f);
    }

    void deselectItem() {

		Debug.Log ("chamou o deselectItem com selectedItem = " + selectedItemWindow);

		var color = _sprites[selectedItemWindow].color;
		_sprites[selectedItemWindow].color = new Color(color.r, color.g, color.b, 1.0f);
		selected = false;
//		selectedItemWindow = -1;
    }

    public void compraItem() {
//		var index = _idx + selectedItemWindow;
		var index = selectedItem;
        var preco = _precos[index];
		var dinheiro = gsm.golpinhos;
        var tipo = _tipos[index];
		if (dinheiro - preco > 0) {
			if (tipo == 0) {
				// pc
				if (curr_pc_idx > -1) {
					var org = _organizacoes [curr_pc_idx];
					var logi = _logicas [curr_pc_idx];
					var cri = _criatividades [curr_pc_idx];

					gsm.frascoO -= org;
					gsm.frascoL -= logi;
					gsm.frascoC -= cri;
				}
				notebook.sprite = _renderers [index];
				curr_pc_idx = index;
				gsm.golpinhos -= (int)preco;
			} else if (tipo == 1) {
				// cadeira
				if (curr_cadeira_idx > -1) {
					var org = _organizacoes [curr_cadeira_idx];
					var logi = _logicas [curr_cadeira_idx];
					var cri = _criatividades [curr_cadeira_idx];

					gsm.frascoO -= org;
					gsm.frascoL -= logi;
					gsm.frascoC -= cri;
				}
				cadeira.sprite = _renderers [index];
				curr_cadeira_idx = index;
				gsm.golpinhos -= (int)preco;
			} else if (tipo == 2) {
				// mesa
				if (curr_mesa_idx > -1) {
					var org = _organizacoes [curr_mesa_idx];
					var logi = _logicas [curr_mesa_idx];
					var cri = _criatividades [curr_mesa_idx];

					gsm.frascoO -= org;
					gsm.frascoL -= logi;
					gsm.frascoC -= cri;
				}
				mesa.sprite = _renderers [index];
				curr_mesa_idx = index;
				gsm.golpinhos -= (int)preco;
			}
			deselectItem ();

			gsm.frascoO += _organizacoes [index];
			gsm.frascoL += _logicas [index];
			gsm.frascoC += _criatividades [index];
		} else {

			warning.showWarning ("Você não tem golpinhos suficientes para comprar este objeto!\nTrabalhe mais para não continuar pobre!");
		}
    }
}