using UnityEngine;
using System.Collections;

public class AttackerSpawner : MonoBehaviour {
	
	public GameObject[] attackerPrefabArray;
		
	// Update is called once per frame
	void Update () {
		foreach(GameObject spawnedAttacker in attackerPrefabArray){
			if(isTimeToSpawn(spawnedAttacker)){
				Spawn(spawnedAttacker);
			}
		}
	}
	
	bool isTimeToSpawn(GameObject attackerGameObject){
		Attacker attacker = attackerGameObject.GetComponent<Attacker>();
		float meanSpawnDelay = attacker.seenEverySecs;
		float spawnsPerSec = 1 / meanSpawnDelay;
		float threshold = spawnsPerSec * Time.deltaTime;
		
		if(Time.deltaTime > meanSpawnDelay){
			Debug.LogWarning("Spawn rate capped by frame rate");
		}
			
		// Remove if to return the bool value from the comparison
		return (Random.value < threshold);
	}
	
	void Spawn(GameObject spawnAttacker){
		GameObject myAttacker = Instantiate(spawnAttacker) as GameObject;
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;
	}
}
