using myDebug;
using  System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class like_script : MonoBehaviour
{
	debug_script debugIn;

	TextMesh textMesh;
	public int likeCount;
    void Start()
    {
		textMesh = GetComponent<TextMesh>();
		InvokeRepeating("changeCount", 0, 1f);

	}

    void changeCount()
    {
		likeCount += Random.Range(-1, 2);
		textMesh.text = likeCount.ToString();
		//debugIn.SaveLog(likeCount.ToString());
	}
}
