using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private float loseAmount;
	private LevelManager levelManager;
	private LifeDisplay lifeDisplay;
	private int collisionCount;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		lifeDisplay = GameObject.FindObjectOfType<LifeDisplay>();
		loseAmount = PlayerPrefsManager.GetDifficulty();
		print(loseAmount);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.GetComponent<Attacker>()){
			IncrementCollisionCount();
			LoseScenario(collisionCount);
		}
	}
	
	void IncrementCollisionCount(){
		collisionCount++;
		lifeDisplay.decrementLives();
		print(collisionCount);
	}
	
	void LoseScenario(int count){
		if(count >= loseAmount){
			levelManager.LoadLevel("03b_Lose");
		}
	}
}
