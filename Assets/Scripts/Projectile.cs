using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public int damage;
	public float speed;
	public LayerMask mask;
	public float overlapRadius;

	// Use this for initialization
	void Start () {
		Collider[] colliders = Physics.OverlapSphere (transform.position, overlapRadius, mask);

		if(colliders.Length > 0){
			print ("Bullet spawned inside enemy");
		}
	}
	
	// Update is called once per frame
	void Update () {
		CheckForCollision ();

		transform.Translate (Vector3.forward * speed * Time.deltaTime);
	}

	public void CheckForCollision(){
		//Collider[] colliders = Physics.OverlapSphere (transform.position, overlapRadius, mask);

		Ray ray;
		RaycastHit hit;

		if(Physics.Raycast (transform.position, transform.forward, speed * Time.deltaTime, mask)){
			//print ("shot");
			Destroy(gameObject);
		}
	}
}
