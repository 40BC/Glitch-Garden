using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public float levelTime;
	
	private Slider slider;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private LevelManager levelManager;
	private GameObject winLabel;
	
	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		FindYouWin();
	}
	
	void FindYouWin(){
		winLabel = GameObject.Find("You Win");
		if(!winLabel){
			Debug.LogWarning("Add You Win Object");
		}
		winLabel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		DecrementLevelTime();
		WinScenario();
	}
	
	void LoadNextLevel(){
		levelManager.LoadNextLevel();
	}
	
	void DecrementLevelTime(){
		slider.value = Time.timeSinceLevelLoad / levelTime;
	}
	
	void WinScenario(){
		if(Time.timeSinceLevelLoad >= levelTime && !isEndOfLevel){
			DestroyAllTaggedObjects();
			audioSource.Play();
			winLabel.SetActive(true);
			Invoke ("LoadNextLevel", audioSource.clip.length);
			isEndOfLevel = true;
		}
	}
	
	void DestroyAllTaggedObjects(){
		GameObject[] destroyableObjectArray = GameObject.FindGameObjectsWithTag("destroyable");
		foreach(GameObject taggedObject in destroyableObjectArray){
			Destroy(taggedObject);
		}
	}
}
