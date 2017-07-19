using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

	[Tooltip ("Average Number Of Seconds Attacker Is Seen")]
	public float seenEverySecs;
	public GameObject attacker;

	private float currentSpeed;
	private GameObject currentTarget;
	private Health health;
	private Animator animator;

	// Use this for initialization
	void Start () {
		Rigidbody2D attackerRigidBody = gameObject.AddComponent<Rigidbody2D>();
		attackerRigidBody.isKinematic = true;
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
		if(!currentTarget){
			animator.SetBool("isAttacking", false);
		}
	}
	
	public void SetCurrentSpeed(float speed){
		 currentSpeed = speed;
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