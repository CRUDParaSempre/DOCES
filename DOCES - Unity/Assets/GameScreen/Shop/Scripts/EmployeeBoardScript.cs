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
    private int selectedItem;

    GameStateManager gsm;

    // Use this for initialization
    void Start() {
        GameObject obj = GameObject.Find("GameStateManager");
        gsm = obj.GetComponent<GameStateManager>();
        _nb_itens = _nomes.Count;

        selectedItem = -1;
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
        preco2.text = _precos[_idx + 1].ToString();
        preco3.text = _precos[_idx + 2].ToString();
        preco4.text = _precos[_idx + 3].ToString();
    }

    public void incrementIndex() {
        _idx += 1;
        _idx = _idx % _nb_itens;
        updateItens();
        deselectItem();
    }

    public void decrementIndex() {
        _idx -= 1;
        _idx = _idx % _nb_itens;
        updateItens();
        deselectItem();
    }

    public void selecionaItem(int index) {
        selectedItem = index;
        var color = _sprites[selectedItem].color;
        _sprites[selectedItem].color = new Color(color.r, color.g, color.b, 0.5f);
    }

    void deselectItem() {
        var color = _sprites[selectedItem].color;
        _sprites[selectedItem].color = new Color(color.r, color.g, color.b, 1.0f);
        selectedItem = -1;
    }

    public void compraItem() {
        var index = _idx + selectedItem;
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
