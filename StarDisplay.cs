using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

	public enum Status {SUCCESS, FAILURE};
	
	private Text textDisplay;
	private int starCount = 100;
	
	// Use this for initialization
	void Start () {
		textDisplay = GetComponent<Text>();
		UpdateDisplay();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void UpdateDisplay(){
		textDisplay.text = "Stars: " + starCount.ToString();
	}
	
	public void AddStars(int amountOfStars){
		starCount += amountOfStars;
		UpdateDisplay();
	}
	
	public Status UseStars(int starCost){
		if(starCost <= starCount){
			starCount -= starCost;
			UpdateDisplay();
			return Status.SUCCESS;
		} else {
			//Not Enough Stars
			return Status.FAILURE;
		}
	}
}
