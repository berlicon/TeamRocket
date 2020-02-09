using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;



namespace myDebug
{
	public class debug_script :MonoBehaviour
	{
		public Text debug_Text;
		public string path;

		void Start()
		{
			path = Application.persistentDataPath + "/test.txt";
			debug_Text = GameObject.Find("Debug_Text").GetComponent<Text>();
			SaveLog("debug is working");
		}
		public void SaveLog(string myString)
		{
			Debug.Log(myString + "\n");
			debug_Text.text += myString + "\n"; 

			StreamWriter writer = new StreamWriter(path, true);
			writer.WriteLine(myString + "\n");
			writer.Close();
		}
	}
}
