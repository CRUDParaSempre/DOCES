﻿// This code automatically generated by TableCodeGen
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cards_CSV : MonoBehaviour
{

	public TextAsset file;

	void Start()
	{
		Load(file);
	}

	public class Row
	{
		public string CardName;
		public string CardType;
		public string Description;
		public string DescriptionSize;
		public string Logic;
		public string Criatividade;
		public string Organization;
		public string Golpinhos;
		public string Efeito;

	}

	List<Row> rowList = new List<Row>();
	bool isLoaded = false;

	public bool IsLoaded()
	{
		return isLoaded;
	}

	public List<Row> GetRowList()
	{
		return rowList;
	}

	public void Load(TextAsset csv)
	{
		rowList.Clear();
		string[][] grid = Csv_Parser2.Parse(csv.text);
		for(int i = 1 ; i < grid.Length ; i++)
		{
			Row row = new Row();
			row.CardName = grid[i][0];
			row.CardType = grid[i][1];
			row.Description = grid[i][2];
			row.DescriptionSize = grid[i][3];
			row.Logic = grid[i][4];
			row.Criatividade = grid[i][5];
			row.Organization = grid[i][6];
			row.Golpinhos = grid[i][7];
			row.Efeito = grid[i][8];

			rowList.Add(row);
		}
		isLoaded = true;
	}

	public int NumRows()
	{
		return rowList.Count;
	}

	public Row GetAt(int i)
	{
		if(rowList.Count <= i)
			return null;
		return rowList[i];
	}

	public Row Find_CardName(string find)
	{
		return rowList.Find(x => x.CardName == find);
	}
	public List<Row> FindAll_CardName(string find)
	{
		return rowList.FindAll(x => x.CardName == find);
	}
	public Row Find_CardType(string find)
	{
		return rowList.Find(x => x.CardType == find);
	}
	public List<Row> FindAll_CardType(string find)
	{
		return rowList.FindAll(x => x.CardType == find);
	}
	public Row Find_Description(string find)
	{
		return rowList.Find(x => x.Description == find);
	}
	public List<Row> FindAll_Description(string find)
	{
		return rowList.FindAll(x => x.Description == find);
	}
	public Row Find_DescriptionSize(string find)
	{
		return rowList.Find(x => x.DescriptionSize == find);
	}
	public List<Row> FindAll_DescriptionSize(string find)
	{
		return rowList.FindAll(x => x.DescriptionSize == find);
	}
	public Row Find_Logic(string find)
	{
		return rowList.Find(x => x.Logic == find);
	}
	public List<Row> FindAll_Logic(string find)
	{
		return rowList.FindAll(x => x.Logic == find);
	}
	public Row Find_Criatividade(string find)
	{
		return rowList.Find(x => x.Criatividade == find);
	}
	public List<Row> FindAll_Criatividade(string find)
	{
		return rowList.FindAll(x => x.Criatividade == find);
	}
	public Row Find_Organization(string find)
	{
		return rowList.Find(x => x.Organization == find);
	}
	public List<Row> FindAll_Organization(string find)
	{
		return rowList.FindAll(x => x.Organization == find);
	}
	public Row Find_Golpinhos(string find)
	{
		return rowList.Find(x => x.Golpinhos == find);
	}
	public List<Row> FindAll_Golpinhos(string find)
	{
		return rowList.FindAll(x => x.Golpinhos == find);
	}
	public Row Find_Efeito(string find)
	{
		return rowList.Find(x => x.Efeito == find);
	}
	public List<Row> FindAll_Efeito(string find)
	{
		return rowList.FindAll(x => x.Efeito == find);
	}



	public string getName(string cardType, int id){

		return FindAll_CardType(cardType)[id].CardName;
	
	}

	public string getDescription(string cardType, int id){

		return FindAll_CardType(cardType)[id].Description;

	}

	public string getBonus(string cardType, int id){

		return FindAll_CardType(cardType)[id].Efeito;

	}

	public string getCreativity(string cardType, int id){

		return FindAll_CardType(cardType)[id].Criatividade;

	}

	public string getLogic(string cardType, int id){

		return FindAll_CardType(cardType)[id].Logic;

	}

	public string getOrganization(string cardType, int id){

		return FindAll_CardType(cardType)[id].Organization;

	}

	public string getMoney(string cardType, int id){

		return FindAll_CardType(cardType)[id].Golpinhos;

	}



}