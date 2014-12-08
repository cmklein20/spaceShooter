using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public void StartGame(int level)
	{
		Application.LoadLevel(level);
	}

	public void QuitGame(bool isDone)
	{
		if (isDone) 
		{
			Application.Quit();
		}
	}
}
