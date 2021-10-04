﻿using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound {

	public string name;

	public AudioClip clip;

	[Range(.1f, 3f)]
	public float pitch = 1f;
	[Range(.05f, 1f)]
	public float volume = 0.2f;

	public bool loop = false;

	//public AudioMixerGroup mixerGroup;

	[HideInInspector]
	public AudioSource source;

}
