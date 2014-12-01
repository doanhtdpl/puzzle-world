using UnityEngine;
using System.Collections;

public class MonoBehaviourSceneSingleton <T> : MonoBehaviour where T : MonoBehaviour
{
	static T _Instance = null;
	
	public static T Instance
	{
		get
		{
			if(!_Instance)
			{
				_Instance = FindObjectOfType<T>();
			}
			return _Instance;
		}
	}

	void Awake()
	{
		//If there is one already loaded, destroy myself
		if(_Instance)
		{
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
		}
	}
}
