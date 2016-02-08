using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {

	private AudioSource musicSpeaker;
	private AudioSource buttonSpeaker;

	private List<AudioClip> musicTracks;
	private List<AudioClip> buttonSounds;
	private AudioClip pause;
	private AudioClip select;

	void Start () {

		musicTracks = new List<AudioClip>();
		buttonSounds = new List<AudioClip>();


		musicSpeaker = transform.GetChild(0).gameObject.GetComponent<AudioSource>();
		buttonSpeaker = transform.GetChild(1).gameObject.GetComponent<AudioSource>();

		foreach(object t in Resources.LoadAll("Audio/Music"))
		{
			

			musicTracks.Add(t as AudioClip);
		}
		foreach(object t in Resources.LoadAll("Audio/Sounds/Buttons/JoyStick"))
		{
				buttonSounds.Add(t as AudioClip);			
		}

		pause = Resources.Load("Audio/Sounds/Buttons/Pause_01") as AudioClip;
		select = Resources.Load("Audio/Sounds/Buttons/Select_01") as AudioClip;
	}
	public void PlaySong (string o)
	{
		foreach(AudioClip t in musicTracks)
		{
			
			if(t.name == o)
			{
				musicSpeaker.clip = t;
				break;
			}
				
		}
		musicSpeaker.Stop();
		musicSpeaker.Play();
	}
	public void PlayMoveJoyStickSound()
	{
		buttonSpeaker.clip = buttonSounds[Random.Range(0, buttonSounds.Count)];

		buttonSpeaker.Play();
	}
	public void PlaySelect()
	{
		buttonSpeaker.PlayOneShot(select);
	}
	public void PlayPause()
	{
		buttonSpeaker.PlayOneShot(pause);
	}
	public void PauseMusic()
	{
		musicSpeaker.Pause();
	}
	public void StopMusic()
	{
		musicSpeaker.Stop();
	}
}
