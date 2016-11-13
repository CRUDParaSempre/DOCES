using UnityEngine;
using System.Collections;

public class employeeScript : MonoBehaviour {

	private string _nome;
	private int _logica;
	private int _organizacao;
	private int _criatividade;
	private float _salario;

	public employeeScript(string nome = "DefaultNome", int logica = 0, int organizacao = 0, int criatividade = 0, float salario = 0.0F){
		this._nome = nome;
		this._logica = logica;
		this._organizacao = organizacao;
		this._criatividade = criatividade;
		this._salario = salario;
	}

	public string nome { 
		set{ _nome = value; }
		get{ return _nome; }
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

	public float salario { 
		set{ _salario = value; }
		get{ return _salario; }
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
