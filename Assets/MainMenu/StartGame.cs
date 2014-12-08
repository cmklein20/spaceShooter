using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour 
{
	public void Start(int level)
	{
		Application.LoadLevel (level);
	}
}
