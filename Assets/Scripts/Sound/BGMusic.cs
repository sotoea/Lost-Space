using UnityEngine;
using System.Collections;

public class BGMusic : MonoBehaviour {

	public string[] _clipNames;     //Keep all audio files inside resources folder  and give the value of path alone in this varible through editor.
	int i=0;

	void Start()
	{
		StartAudio(); 
	}
	void Update(){
		if(!audio.isPlaying) StartAudio();
	}
	void StartAudio()
	{

		audio.clip = Resources.Load (_clipNames[i]) as AudioClip;
		if(!audio.isPlaying)
			audio.Play();
	
		i++;
		if(i>=_clipNames.Length)
			i=0;
		//Invoke("StartAudio",audio.clip.length+0.5f);    //0.5f is the delay given after a song is over.
		
	}
}