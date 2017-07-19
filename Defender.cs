﻿using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

	public int starCost;

	private StarDisplay starDisplay;
	
	void Start(){
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}

	public void AddStars(int amountOfStars){
		starDisplay.AddStars(amountOfStars);
	}
}
