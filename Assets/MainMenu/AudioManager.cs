using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour 
{
	public AudioClip buttonClick;

	private AudioSource source;

	void Awake()
	{
		if (source == null)
		{
			source = GetComponent<AudioSource>();
		}
	}

	public void OnMouseEnter()
	{
		if (source != null)
		{
			Debug.Log ("Source");
		}

		source.PlayOneShot(buttonClick);
	}
}
