using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class LifeDisplay : MonoBehaviour {

	private Text lifeText;
	private float lives;
	
	void Start(){
		lifeText = GetComponent<Text>();
		lives = PlayerPrefsManager.GetDifficulty();
		DisplayLives();
	}
	
	void DisplayLives(){
		lifeText.text = "Lives: " + lives.ToString();
	}
	
	public void decrementLives(){
		lives--;
		DisplayLives();
	}
}
