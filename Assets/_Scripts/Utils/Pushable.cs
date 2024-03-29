﻿using UnityEngine;
using System.Collections;

public class Pushable : MonoBehaviour 
{
	BoxCollider2D box;
	
	void Awake()
	{
		box = GetComponent<BoxCollider2D>();
	}
	
	public bool IsJustPressed()
	{
		if(InputManager.Instance && InputManager.Instance.JustPressed)
		{
			Vector3 touch = InputManager.Instance.TouchPosition;
			touch.z = box.bounds.center.z;
			if(box.bounds.Contains(touch))
			{
				return true;
			}
		}
		return false;
	}
}
