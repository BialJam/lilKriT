using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public int damage;
	public float speed;
	public LayerMask mask;
	public float overlapRadius;

	public float lifeTime;

	public bool canHurtPlayer;
	public bool explosive;
	public float explosionRange;
	public GameObject particles;

	// Use this for initialization
	void Start () {
		if(!canHurtPlayer){
			Collider[] colliders = Physics.OverlapSphere (transform.position, overlapRadius, mask);

			if(colliders.Length > 0){
				print ("Bullet spawned inside enemy");
			}
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

		//Ray ray;
		RaycastHit hit;

		if(canHurtPlayer){
			if(Physics.Raycast (transform.position, transform.forward, out hit, speed * Time.deltaTime)){
				if(hit.collider.gameObject.CompareTag("Player") && !hit.collider.isTrigger){
					Entity e = hit.collider.gameObject.GetComponent<Entity> ();
					e.TakeHit (hit, damage);

					if(particles != null){
						GameObject go = GameObject.Instantiate (particles, transform.position, transform.rotation) as GameObject;
						Destroy (go, 1);
					}
					Destroy(gameObject);
				}
			}
		}

		if(Physics.Raycast (transform.position, transform.forward, out hit, speed * Time.deltaTime, mask)){
			if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy") && !hit.collider.isTrigger){
				Entity e = hit.collider.gameObject.GetComponent<Entity> ();
				e.TakeHit (hit, damage);
			}

			if(particles != null){
				GameObject go = GameObject.Instantiate (particles, transform.position, transform.rotation) as GameObject;
				Destroy (go, 1);
			}
			Destroy(gameObject);
		}
	}
}
