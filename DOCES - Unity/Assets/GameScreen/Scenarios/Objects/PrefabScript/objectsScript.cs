using UnityEngine;
using System.Collections;

public class objectsScript : MonoBehaviour {
	
	private string _nome;
	private int _tipo; //0=notebook, 1=chair, 2=table
	private int _logica;
	private int _organizacao;
	private int _criatividade;
	private float _preco;

	public objectsScript(string nome = "DefaultNomeObjeto", int tipo=3, int logica = 0, int organizacao = 0, int criatividade = 0, float preco = 0.0F){
		this._nome = nome;
		this._tipo = tipo;
		this._logica = logica;
		this._organizacao = organizacao;
		this._criatividade = criatividade;
		this._preco = preco;
	}

	public string nome { 
		set{ _nome = value; }
		get{ return _nome; }
	}

	public int tipo { 
		set{ _tipo = value; }
		get{ return _tipo; }
	}

	public int logica { 
		set{ _logica = value; }
		get{ return _logica; }
	}

	public int organizacao { 
		set{ _organizacao = value; }
		get{ return _organizacao; }
	}

	public int criatividade { 
		set{ _criatividade = value; }
		get{ return _criatividade; }
	}

	public float preco { 
		set{ _preco = value; }
		get{ return _preco; }
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
