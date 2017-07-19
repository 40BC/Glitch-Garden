using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {

	public GameObject defenderPrefab;
	public static GameObject selectedDefender;
	
	private Text costText;
	private Button[] buttonArray;

	// Use this for initialization
	void Start () {
		buttonArray = GameObject.FindObjectsOfType<Button>();
		DisplayCostText();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown(){
		foreach(Button thisButton in buttonArray){
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
			
		}
		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefab;
	}
	
	void DisplayCostText(){
		costText = GetComponentInChildren<Text>();
		if(!costText) {Debug.LogWarning(name + " has no cost text");}
		
		costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
	}
}
