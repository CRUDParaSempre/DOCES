using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class EmployeeBoardScript : MonoBehaviour {
    public List<Transform> funcionario;

    public Text preco1;
    public Text preco2;
    public Text preco3;
    public Text preco4;

    public List<Sprite> _renderers;
    public List<string> _nomes;
    public List<int> _logicas;
    public List<int> _organizacoes;
    public List<int> _criatividades;
    public List<float> _precos;

    List<string> _items;
    public List<SpriteRenderer> _sprites;

    private int _idx = 0;
    private int _nb_itens;

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

        for (var i = 0; i < funcionario.Count; ++i) {
            funcionario[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update() { }

    public void updateItens() {
        for (var i = 0; i < 4; ++i) {
            var idx = _idx + i;
            idx = idx % _nb_itens;
            _sprites[i].sprite = _renderers[idx];
        }
        preco1.text = _precos[_idx].ToString();
        preco2.text = _precos[(_idx + 1) % _nb_itens].ToString();
        preco3.text = _precos[(_idx + 2) % _nb_itens].ToString();
        preco4.text = _precos[(_idx + 3) % _nb_itens].ToString();
    }

    public KeyValuePair<bool, int> insideWindow(int index) {
        for (int i = 0; i < 4; i++) {
            if (index == ((_idx + i + _nb_itens) % _nb_itens))
                return new KeyValuePair<bool, int>(true, i);
        }

        return new KeyValuePair<bool, int>(false, -1);
    }

    public void incrementIndex() {
        _idx += 1;
        _idx = (_idx + _nb_itens) % _nb_itens;

        updateItens();

        if (selected == true && isSelectedItemVisible == true) {
            deselectItem();
            selectedItemWindow -= 1;
            if (selectedItemWindow >= 0) {
                selecionaItem(selectedItemWindow);
            } else {
                isSelectedItemVisible = false;
                selectedItemWindow = -1;
            }
        } else if (isSelectedItemVisible == false && insideWindow(selectedItem).Key) {
            isSelectedItemVisible = true;
            selectedItemWindow = insideWindow(selectedItem).Value;
            selecionaItem(selectedItemWindow);
        }
    }

    public void decrementIndex() {
        _idx -= 1;
        _idx = (_idx + _nb_itens) % _nb_itens;

        updateItens();

        if (selected == true && isSelectedItemVisible == true) {
            deselectItem();
            selectedItemWindow += 1;
            if (selectedItemWindow < windowSize) {
                selecionaItem(selectedItemWindow);
            } else {
                isSelectedItemVisible = false;
                selectedItemWindow = -1;
            }
        } else if (isSelectedItemVisible == false && insideWindow(selectedItem).Key) {
            isSelectedItemVisible = true;
            selectedItemWindow = insideWindow(selectedItem).Value;
            selecionaItem(selectedItemWindow);
        }
    }

    public void selecionaItem(int index) {
        if (selected == true && index == selectedItemWindow) {
            deselectItem();
            selected = false;
            return;
        } else if (selected == true && index != selectedItemWindow) {
            deselectItem();
        }
        
        selected = true;
        isSelectedItemVisible = true;

        selectedItem = (index + _idx + _nb_itens) % _nb_itens;
        selectedItemWindow = index;
        var color = _sprites[selectedItemWindow].color;
        _sprites[selectedItemWindow].color = new Color(color.r, color.g, color.b, 0.5f);
    }

    void deselectItem() {
        var color = _sprites[selectedItemWindow].color;
        _sprites[selectedItemWindow].color = new Color(color.r, color.g, color.b, 1.0f);
        selected = false;
    }

    public void compraItem() {
        var index = selectedItem;
        var preco = _precos[index];
        var dinheiro = 1000;
        if (dinheiro - preco > 0) {
            funcionario[index].gameObject.SetActive(true);
            deselectItem();
            gsm.frascoO += _organizacoes[index];
            gsm.frascoL += _logicas[index];
            gsm.frascoC += _criatividades[index];
        }
    }
}
