using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	private GameObject defenderParent;
	private StarDisplay starDisplay;
	
	
	// Use this for initialization
	void Start () {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		defenderParent = GameObject.Find("Defender Parent");
		
		if(!defenderParent){
			defenderParent = new GameObject("Defender Parent");
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnMouseDown(){
		GameObject selectedDefender = Button.selectedDefender;
		if(selectedDefender){
			SpawnDefender(selectedDefender);
		}
	}
	
	void SpawnDefender(GameObject defender){
		int defenderCost = defender.GetComponent<Defender>().starCost;
		
		if(starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS){
			GameObject newDefender = Instantiate(defender, (SnapToGrid(CalculateWorldPointOfMouseClick())), Quaternion.identity) as GameObject;
			newDefender.transform.parent = defenderParent.transform;
		} else {
			Debug.Log ("Not Enough Stars");
		}
	}
	
	Vector2 CalculateWorldPointOfMouseClick(){
		Camera camera = GameObject.Find("Game Camera").GetComponent<Camera>();
		return camera.ScreenToWorldPoint(Input.mousePosition);
	}
	
	Vector2 SnapToGrid(Vector2 rawWorldPosition){
		// Round the values from CalculateWorldPointOfMouseClick
		int newX = Mathf.RoundToInt(rawWorldPosition.x);
		int newY = Mathf.RoundToInt(rawWorldPosition.y);
		
		return new Vector2(newX, newY);
	}
}
