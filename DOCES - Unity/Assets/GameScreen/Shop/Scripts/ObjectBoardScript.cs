using UnityEngine;
using UnityEngine.UI;
using System;
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
    private int selectedItem;
    private int curr_pc_idx = -1;
    private int curr_cadeira_idx = -1;
    private int curr_mesa_idx = -1;

    GameStateManager gsm;

    // Use this for initialization
    void Start() {
        GameObject obj = GameObject.Find("GameStateManager");
        gsm = obj.GetComponent<GameStateManager>();
        _nb_itens = _nomes.Count;

        selectedItem = -1;
        updateItens();
    }

    // Update is called once per frame
    void Update() { }

    public void updateItens() {
        for (var i = 0; i < 4; ++i) {
            var idx = _idx + i;
            idx = idx % _nb_itens;
            _sprites[i].sprite = _thumbnails[idx];
        }
        preco1.text = _precos[_idx].ToString();
        preco2.text = _precos[(_idx + 1)%_nb_itens].ToString();
        preco3.text = _precos[(_idx + 2)%_nb_itens].ToString();
        preco4.text = _precos[(_idx + 3)%_nb_itens].ToString();
    }

    public void incrementIndex() {
        _idx += 1;
        _idx = _idx % _nb_itens;
        updateItens();
        deselectItem();
    }

    public void decrementIndex() {
        _idx -= 1;
        _idx = (_idx % _nb_itens + _nb_itens) % _nb_itens;
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
        var tipo = _tipos[index];
        if (dinheiro - preco > 0) {
            if (tipo == 0) {
                // pc
                if (curr_pc_idx > -1) {
                    var org = _organizacoes[curr_pc_idx];
                    var logi = _logicas[curr_pc_idx];
                    var cri = _criatividades[curr_pc_idx];

                    gsm.frascoO -= org;
                    gsm.frascoL -= logi;
                    gsm.frascoC -= cri;
                }
                notebook.sprite = _renderers[index];
                curr_pc_idx = index;
            } else if (tipo == 1) {
                // cadeira
                if (curr_cadeira_idx > -1) {
                    var org = _organizacoes[curr_cadeira_idx];
                    var logi = _logicas[curr_cadeira_idx];
                    var cri = _criatividades[curr_cadeira_idx];

                    gsm.frascoO -= org;
                    gsm.frascoL -= logi;
                    gsm.frascoC -= cri;
                }
                cadeira.sprite = _renderers[index];
                curr_cadeira_idx = index;
            } else if (tipo == 2) {
                // mesa
                if (curr_mesa_idx > -1) {
                    var org = _organizacoes[curr_mesa_idx];
                    var logi = _logicas[curr_mesa_idx];
                    var cri = _criatividades[curr_mesa_idx];

                    gsm.frascoO -= org;
                    gsm.frascoL -= logi;
                    gsm.frascoC -= cri;
                }
                mesa.sprite = _renderers[index];
                curr_mesa_idx = index;
            }
            deselectItem();
            gsm.frascoO += _organizacoes[index];
            gsm.frascoL += _logicas[index];
            gsm.frascoC += _criatividades[index];
        }
    }
}