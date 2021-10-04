using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public static AudioManager instance;

	public AudioMixerGroup mixerGroup;

	public Sound[] sounds;

	private AudioSource activeSong;
	private AudioSource stoppableTrack;

	void Awake()
	{
		if (instance != null)
		{
			Debug.Log("Destroying audiomanager, already present");
			Destroy(gameObject);
			return;
		} else
		{
			Debug.Log("Make an audiomanager");
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
		}
	}

	public void PlayMusic(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume;
		s.source.pitch = s.pitch;

		if (activeSong != null)
		{
			activeSong.Stop();
		}
		activeSong = s.source;
		s.source.Play();
	}

	public void PlayMusicIfNotPlaying(string sound)
	{
		if (activeSong != null) return;
		PlayMusic(sound);
	}

	// Play a track that can be stopped later with StopStoppableTrack.
	// Do not play more than one stoppable track at a time.
	public void PlayStoppableTrack(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume;
		s.source.pitch = s.pitch;

		stoppableTrack = s.source;
		//Debug.Log("Playing " + sound);
		s.source.Play();
	}

	public void StopStoppableTrack()
	{
		if (stoppableTrack == null) return;
		stoppableTrack.Stop();
		stoppableTrack = null;
	}


	public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume;
		s.source.pitch = s.pitch;

		s.source.Play();
	}

	public void PlayPitch(string sound, float pitchMod)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume;
		s.source.pitch = s.pitch * pitchMod;

		s.source.Play();
	}

}
