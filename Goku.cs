using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Defender))]
public class Goku : MonoBehaviour {

	private Animator animator;
	private Health health;
	private GameObject currentTarget;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		GameObject attacker = collider.gameObject;
		if(attacker.GetComponent<Attacker>()){
			animator.SetBool("isAttacking", true);
			Attack(attacker);
		}
	}
	
	public void Attack(GameObject target){
		currentTarget = target;
	}
	
	// Performed by animator at attack time
	public void StrikeCurrentTarget(float damage){
		if(currentTarget){
			health = currentTarget.GetComponent<Health>();
			if(health){
				health.TakeDamage(damage);
			}
		}
	}
}
