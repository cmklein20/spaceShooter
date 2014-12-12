using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour 
{
	public AudioClip buttonClick;
	public bool audioMuted = false;

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
		source.PlayOneShot(buttonClick);
	}

	public void OnMouseUp()
	{
		if (!audioMuted)
		{
			AudioListener.pause = true;
			audioMuted = true;
		}
		else
		{
			AudioListener.pause = false;
			audioMuted = false;
		}
	}
}
