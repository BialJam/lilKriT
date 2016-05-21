using UnityEngine;
using System.Collections;

[RequireComponent (typeof(NavMeshAgent))]
public class Enemy : Entity {

	public GameObject deathParticles;

	public NavMeshAgent agent;

	public Player player;

	public float timeBetweenPathChecks;
	public float nextPathCheck;

	public float attackRange;

	void Awake(){
		agent = GetComponent<NavMeshAgent> ();
	}

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
	
		UpdatePath ();
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
			return true;
		}
	}

	public virtual void Attack(){

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
