using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class test_serialize : MonoBehaviour
{
	public int A, B, C;
	Animal dog;
	Animal cat;



	void Start()
    {
		dog.age = 1;
		cat.age = 2;
		A = dog.age + cat.age;
	}



}

[Serializable]
class Animal
{
	public Animal t1;
	public Animal t2;
	public Animal t3;
	public int age;
}
