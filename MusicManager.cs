using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;
	
	private AudioSource audioSource;
	
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = PlayerPrefsManager.GetMasterVolume();
	}
	
	void Awake(){
		DontDestroyOnLoad(gameObject);
	}
	
	void OnLevelWasLoaded(int level){
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		if(thisLevelMusic){ // If there is any music attached
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}
	
	public void ChangeVolume(float volume){
		audioSource.volume = volume;
	}
}
