using UnityEngine;
using System.Collections;

public abstract class Minigame : MonoBehaviour 
{
	enum eMinigameState
	{
		INIT,
		FADE_IN,
		TUTORIAL,
		PREPARE_GAMEPLAY,
		GAMEPLAY,
		RESULTS,
		FADE_OUT
	};

	eMinigameState state;
	float stateStartTime;

	void Start () 
	{
		SetState(eMinigameState.INIT);
	}
	
	void Update () 
	{
		SendMessage("Update_" + state);
	}

	void SetState(eMinigameState _state)
	{
		SendMessage("Exit_" + state);
		state = _state;
		stateStartTime = Time.time;
		SendMessage("Enter_" + state);
	}

	float GetStateTime()
	{
		return Time.time - stateStartTime;
	}

	protected abstract void ShowInit();
	protected abstract int GetTutorialPagesCount();
	protected abstract void ShowTutorial(int _page);
	protected abstract void HideTutorial();
	protected abstract void PrepareGameplay();
	protected abstract void UpdateGameplay();
	protected abstract bool IsGameplayFinished();
}
