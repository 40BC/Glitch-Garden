using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;
	
	private GameObject projectileParent;
	private Animator animator;
	private AttackerSpawner myLaneSpawner;
	
	void Start(){
		animator = GameObject.FindObjectOfType<Animator>();
		projectileParent = GameObject.Find("Projectile Parent");
		
		if(!projectileParent){
			projectileParent = new GameObject("Projectile Parent");
		}
		
		SetMyLaneSpawner();
	}
	
	void Update(){
		// Shoot if attacker is ahead in lane otherwise stay out of attack state
		SetMyLaneSpawner();
		if(IsAttackerAheadInLane()){
			animator.SetBool("isAttacking", true);
		} else {
			animator.SetBool("isAttacking", false);
		}
	}
	
	void FireProjectile(){
		GameObject newProjectile = Instantiate(projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
	
	// Look through spawners and set myLaneSpawner
	void SetMyLaneSpawner(){
		AttackerSpawner[] spawnerArray = GameObject.FindObjectsOfType<AttackerSpawner>();
		foreach(AttackerSpawner spawner in spawnerArray){
			if(spawner.transform.position.y == this.transform.position.y){
				myLaneSpawner = spawner;
				return;
			}
		}
		Debug.LogError(name + " No Spawner in Lane");
	}
	
	bool IsAttackerAheadInLane(){
		// Exit if no attackers in lane
		if(myLaneSpawner.transform.childCount <= 0){
			return false;
		}
		
		// Check if attackers are ahead of defender
		foreach(Transform child in myLaneSpawner.transform){
			if(child.transform.position.x > transform.position.x){
				return true;
			}
		}
			// attacker present but not ahead of defender
			return false;
	}
}
