using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;



namespace myDebug
{
	public class debug_script :MonoBehaviour
	{
		private Text debug_Text;
		private  string path = Application.persistentDataPath + "/test.txt";

		void Start()
		{
			debug_Text = GameObject.Find("Debug_Text").GetComponent<Text>();
			SaveLog("debug is working");
		}
		public void SaveLog(string myString)
		{
			Debug.Log(myString);
			debug_Text.text += myString;

			StreamWriter writer = new StreamWriter(path, true);
			writer.WriteLine(myString + "/n");
			writer.Close();
		}
	}
}
