using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviourSceneSingleton<InputManager> 
{
	public bool JustPressed = false;
	public bool JustReleased = false;
	public Vector3 TouchPosition;
	
	void Update () 
	{
		JustPressed = false;
		JustReleased = false;
		foreach(Touch touch in Input.touches)
		{
			JustPressed = touch.phase == TouchPhase.Began;
			JustReleased = touch.phase == TouchPhase.Ended;
			TouchPosition = Camera.main.ScreenToWorldPoint(touch.position);
		}
		
		if(Input.GetMouseButtonDown(0))
		{
			JustPressed = true;
			TouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
		else if(Input.GetMouseButtonUp(0))
		{
			JustReleased = true;
			TouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
	}
}
