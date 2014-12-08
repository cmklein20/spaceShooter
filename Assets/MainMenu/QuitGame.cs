using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour 
{
	public void Quit(bool isDone)
	{
		if (isDone)
		{
			Application.Quit ();
		}
	}
}
