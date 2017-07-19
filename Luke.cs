using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Luke : MonoBehaviour {
	
	private Animator animator;
	private Attacker attacker;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		GameObject defender = collider.gameObject;
		if(defender.GetComponent<Defender>()){
			animator.SetBool("isAttacking", true);
			attacker.Attack(defender);
		}
	}
}
