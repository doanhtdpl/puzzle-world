using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CircleManager : MonoBehaviour
{
	public Material material;

	Circle[] circles;

	void Start()
	{
		circles = FindObjectsOfType<Circle>();
	}
	
	void Update()
	{
		
	}
}
