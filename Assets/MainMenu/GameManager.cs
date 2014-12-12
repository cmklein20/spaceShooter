using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public bool isPaused = false;

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space))
		{
			if (!isPaused)
			{
				PauseGame();
			}
			else
			{
				ResumeGame();
			}
		}
	}

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

	public void PauseGame()
	{
		Debug.Log("Pause");
		Time.timeScale = 0;
		AudioListener.pause = true;
		isPaused = true;
	}
	
	public void ResumeGame()
	{
		Debug.Log("Resume");
		Time.timeScale = 1;
		AudioListener.pause = false;
		isPaused = false;
	}
	
	public void OnMouseUp()
	{
		if (!isPaused)
		{
			PauseGame();
		}
		else
		{
			ResumeGame();
		}
	}
}
