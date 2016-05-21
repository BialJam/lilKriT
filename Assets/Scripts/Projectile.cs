using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public int damage;
	public float speed;
	public LayerMask mask;
	public float overlapRadius;

	public float lifeTime;

	// Use this for initialization
	void Start () {
		Collider[] colliders = Physics.OverlapSphere (transform.position, overlapRadius, mask);

		if(colliders.Length > 0){
			print ("Bullet spawned inside enemy");
		}

		Destroy (this.gameObject, lifeTime);
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

		if(Physics.Raycast (transform.position, transform.forward, out hit, speed * Time.deltaTime, mask)){
			//print ("shot");
			if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy")){
				Enemy e = hit.collider.gameObject.GetComponent<Enemy> ();
				e.TakeHit (hit, damage);
			}
			Destroy(gameObject);
		}
	}
}
