using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class debug_script
{
	Text debug_Text;
	string path = "Assets/Resources/test.txt";

	void start()
	{
		debug_Text = GameObject.Find("Debug_Text").GetComponent<Text>();
	}
	public void saveLog(string myString)
	{
		Debug.Log(myString);
		debug_Text.text += myString;

		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine(myString + "/n");
		writer.Close();
	}
}
