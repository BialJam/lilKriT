using UnityEngine;
using System.Collections;

public class EnemyFatguy : Entity {

	public GameObject deathParticles;

	public NavMeshAgent agent;

	public Player player;

	public float timeBetweenPathChecks;
	public float nextPathCheck;

	public float attackRange;
	public float nextAttackTime;
	public float attackCooldown;
	public LayerMask mask;

	public int burstLength;
	public int burstRemaining;
	public float burstCooldown;

	public Projectile bullet;
	public Transform bulletSpawnRight;
	public Transform bulletSpawnLeft;

	public bool attackRight;

	void Awake(){
		agent = GetComponent<NavMeshAgent> ();
	}

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
		burstRemaining = burstLength;
	}

	// Update is called once per frame
	void Update () {
		UpdatePath ();

		if(IsInRange()){
			bulletSpawnLeft.LookAt (player.transform.position);
			bulletSpawnRight.LookAt (player.transform.position);
			Attack ();
		}
	}

	public void UpdatePath(){
		if (Time.time < nextPathCheck || player == null) {
			return;
		} else {
			Vector3 direction = (player.transform.position - transform.position).normalized;
			agent.SetDestination (player.transform.position - direction);
			nextPathCheck = Time.time + timeBetweenPathChecks;
		}
	}

	public virtual bool IsInRange(){
		if(Vector3.SqrMagnitude(transform.position - player.transform.position) > attackRange * attackRange){
			return false;
		} else {
			RaycastHit hit;

			if (Physics.Raycast(transform.position, player.transform.position, attackRange, mask)) {
				//hitting an obstacle
				return false;
			} else {
				return true;
			}
		}
	}

	public virtual void Attack(){
		if(Time.time > nextAttackTime){

			if(attackRight){
				GameObject.Instantiate (bullet, bulletSpawnRight.position, bulletSpawnRight.rotation);
			} else {
				GameObject.Instantiate (bullet, bulletSpawnLeft.position, bulletSpawnLeft.rotation);
			}

			attackRight = !attackRight;
			burstRemaining--;

			if (burstRemaining <= 0) {
				nextAttackTime = Time.time + burstCooldown;
				burstRemaining = burstLength;
			} else {
				nextAttackTime = Time.time + attackCooldown;
			}
		}
	}

	public override void Die ()
	{
		GameObject particles = GameObject.Instantiate (deathParticles, transform.position, transform.rotation) as GameObject;
		Destroy (particles, 1.0f);
		agent.enabled = false;
		this.transform.position += Vector3.up * 100;
		Destroy (this.gameObject, 0.5f);
	}
}
