using UnityEngine;
using System.Collections;

public class laserBullet : MonoBehaviour 
{
	private GameObject levelGUI;

	void Awake ()
	{
		if (levelGUI == null)
		{
			levelGUI = GameObject.FindGameObjectWithTag("LevelGUI");
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "FuelRefill")
		{
			levelGUI.SendMessage ("RefillFuel");
		}
		levelGUI.SendMessage ("UpdateScore");
		Destroy(gameObject);
		Destroy (col.gameObject);
	}
}
