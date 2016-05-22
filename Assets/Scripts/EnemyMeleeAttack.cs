using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Collider))]
public class EnemyMeleeAttack : MonoBehaviour {

	public float attackDuration;
	public float attackCooldown;

	public float attackEndTime;
	public float nextAttackTime;

	public Collider attackCollider;
	public int damage;

	void Awake(){
		attackCollider = GetComponent<Collider> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(attackCollider.enabled == true && Time.time > attackEndTime){
			attackCollider.enabled = false;
		}
	}

	public void Attack(){
		if(Time.time > nextAttackTime){
			attackEndTime = Time.time + attackDuration;
			nextAttackTime = Time.time + attackCooldown;
			attackCollider.enabled = true;
		}
	}

	public void OnTriggerEnter(Collider col){
		
		if(col.gameObject.CompareTag("Player")){
			Player player = col.gameObject.GetComponent<Player> ();
			player.TakeDamage (damage);
		}
	}
}
