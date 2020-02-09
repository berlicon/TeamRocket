using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using myDebug;

public class MicInput : MonoBehaviour
{
	AudioClip clip;
	string savedPath;
	public float scale;
	float width, height;

	AudioSource audioSource;

	public debug_script debugIn;


	void Start()
	{
		width = Screen.width * scale;
		height = Screen.height * scale;

		// Output the device details available in the system, helpful when want to check capability of each device.
		foreach (string device in Microphone.devices)
		{
			debugIn.SaveLog("Name: " + device);
			int minFreq = 0;
			int maxFreq = 0;
			Microphone.GetDeviceCaps(device, out minFreq, out maxFreq);
			debugIn.SaveLog("Min Freq = " + minFreq);
			debugIn.SaveLog("Max Freq = " + maxFreq);
		}

		audioSource = GetComponent<AudioSource>();
	}

	void OnGUI()
	{
		if (GUI.Button(new Rect(10, 10, width, height), "Record"))
		{
			Record_Button();
		}
		if (GUI.Button(new Rect(10, 70 + height, width, height), "Save"))
		{
			Save_Button();
		}
		if (GUI.Button(new Rect(10, 140 + 2*height, width, height), "Play_Button()"))
		{
			Play_Button();
		}
	}

	public void Record_Button()
	{
		debugIn.SaveLog("Record_Button()");
		clip = Microphone.Start("Built-in Microphone", true, 5, 16000);
	}

	public void Play_Button()
	{
		debugIn.SaveLog("Play_Button()");

		if (clip != null)
		{
			debugIn.SaveLog(clip.length.ToString());
			audioSource.PlayOneShot(clip, 0.7F);
		}
		else
			debugIn.SaveLog("clip = null()");
	}

	public void Save_Button()
	{
		debugIn.SaveLog("Save_Button()");
		Microphone.End("Built-in Microphone");
		SavWav.Save("myfile", clip);
		savedPath = Path.Combine(Application.persistentDataPath, "myfile.wav");
	}

}
