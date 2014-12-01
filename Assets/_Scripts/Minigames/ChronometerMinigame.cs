using UnityEngine;
using System.Collections;

public class ChronometerMinigame : Minigame
{
	protected override void UpdateGameplay ()
	{
	
	}

	protected override bool IsGameplayFinished ()
	{
		return true;
	}

	protected override void ShowInit()
	{
	}

	protected override int GetTutorialPagesCount()
	{
		return 1;
	}

	protected override void ShowTutorial(int _page)
	{
	}

	protected override void HideTutorial()	
	{
	}

	protected override void PrepareGameplay()
	{
	}
}
