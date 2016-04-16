﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SoundManager : MonoBehaviour {

	private AudioSource source;

	public enum soundclip {PointEnter,Dash,Jump,Goal,Cursor,ForceWalk,Warp,Star};
	public AudioClip jump,Dash,Cursor,ForceWalk,PointEnter,Goal,Warp,Star;
	private Dictionary<soundclip, AudioClip> audioClipMapper = new Dictionary<soundclip, AudioClip>();

	// Use this for initialization
	void Awake() {
		source = GetComponent<AudioSource>();

	}

	void Start()
	{
		audioClipMapper.Add (soundclip.Jump, jump);
		audioClipMapper.Add (soundclip.Dash, Dash);
		audioClipMapper.Add (soundclip.PointEnter,PointEnter);
		audioClipMapper.Add (soundclip.Cursor,Cursor);
		audioClipMapper.Add (soundclip.ForceWalk,ForceWalk);
		audioClipMapper.Add (soundclip.Goal,Goal);
		audioClipMapper.Add (soundclip.Warp,Warp);
		audioClipMapper.Add (soundclip.Star,Star);


	}

	public void playSound (soundclip sc)
	{
		AudioClip ac = audioClipMapper [sc];
		source.PlayOneShot (ac,0.5f);
		//Debug.Log("Playsound eiei");

	}
	public void playSound (soundclip sc, float volumn)
	{
		Debug.Log (sc + " " + volumn);
		AudioClip ac = audioClipMapper [sc];
		source.PlayOneShot (ac,volumn);
		//Debug.Log("Playsound eiei");

	}

	public void stopSound()
	{
		source.Stop ();
	}


}