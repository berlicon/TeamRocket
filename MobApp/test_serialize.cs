using myDebug;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class test_serialize : MonoBehaviour
{
	const string glyphs = "abcdefghijklmnopqrstuvwxyz0123456789";
	int minCharAmount = 5;
	int maxCharAmount = 15;

	public int A, B, C;
	Painting Sample = new Painting();
	Painting[] paintings = new Painting[10];
	public int currentNum = 0;
	debug_script debugIn;


	private void Start()
	{
		Sample.name = "коля";

		for (int i = 0; i < paintings.Length; i++)
			paintings[i] = Sample;
		InvokeRepeating("AddPainting_Button", 2, 4);

	}




	public void AddPainting_Button()
	{
		if (currentNum > paintings.Length)
			currentNum = 0;

		paintings[currentNum].name = randomString();
		paintings[currentNum].author = randomString();

	}


	public string randomString()
	{
		string myString = "";
		
		int charAmount = UnityEngine.Random.Range(minCharAmount, maxCharAmount);
		for (int i = 0; i < charAmount; i++)
		{
			myString += glyphs[UnityEngine.Random.Range(0, glyphs.Length)];
		}

		return myString;
	}

	void debugPainting(int myInt)
	{
		debugIn.SaveLog(paintings[myInt].name.ToString());
		debugIn.SaveLog(paintings[myInt].author.ToString());
		debugIn.SaveLog(paintings[myInt].yearDate.ToString());
		debugIn.SaveLog(paintings[myInt].duration.ToString());
		debugIn.SaveLog(paintings[myInt].age.ToString());

	}

}

[Serializable]
class Painting
{
	public string name;
	public string author;
	public int yearDate;
	public float duration;
	public int age;
}
