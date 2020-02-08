using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeUISquare : MonoBehaviour
{

	RectTransform rectTransform;
	public float A;
    void Start()
    {
		rectTransform = GetComponent<RectTransform>();
		A = rectTransform.sizeDelta.y;
		rectTransform.sizeDelta = new Vector2(A, 2*A);
	}

}
