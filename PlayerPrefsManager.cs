using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";

	public static void SetMasterVolume(float volume){
		if(volume >= 0f && volume <= 1f){
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);	
		} else {
			Debug.LogError("Master volume out of range");
		}
	}
	
	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}
	
	public static void UnlockLevel(int level){
		if(level >= Application.levelCount - 1){
			Debug.LogError("level load error");
		} else {
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); // Use 1 for true
		}
	}
	
	public static bool IsUnlockedLevel(int level){
		int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
		bool isLevelUnlocked = (levelValue == 1);
		if(level <= Application.levelCount - 1){
			return isLevelUnlocked;
		} else {
			Debug.LogError("level load error");
			return false;
		}
	}
	
	public static void SetDifficulty(float difficulty){
		if(difficulty >= 1 && difficulty <= 10){
			PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError("Difficulty is outside of range!");
		}
	}
	
	public static float GetDifficulty(){
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}	
}
