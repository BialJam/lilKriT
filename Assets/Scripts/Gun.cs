using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public GameObject projectile;
	public int minDamage;
	public int maxDamage;

	public bool infiniteAmmo;
	public int ammoLeft;

	public Transform[] bulletSpawn;

	public float timeBetweenShots;
	public float nextShotTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	virtual public void Shoot (){
		if (!infiniteAmmo && ammoLeft == 0) {
			return;
		} else if(Time.time < nextShotTime){
			return;
		} else {
			foreach(Transform spawn in bulletSpawn){
				GameObject.Instantiate (projectile, spawn.position, transform.rotation);
				nextShotTime = Time.time + timeBetweenShots;

				if(!infiniteAmmo){
					ammoLeft--;
				}
			}
		}
	}
}
