using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public GameObject projectile;
	//public int minDamage;
	//public int maxDamage;

	public bool infiniteAmmo;
	public bool isAutomatic;
	public bool canShoot;
	//public int burstLength;

	public int ammoLeft;

	public Transform[] bulletSpawn;

	public float timeBetweenShots;
	public float nextShotTime;

	public GunController gc;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	virtual public void TriggerPulled (){
		if (!infiniteAmmo && ammoLeft == 0) {
			return;
		}
		if(Time.time < nextShotTime && isAutomatic){
			return;
		} 
		if(!isAutomatic && !canShoot){
			return;
		}
	
		//actual shooting
		foreach(Transform spawn in bulletSpawn){
			GameObject.Instantiate (projectile, spawn.position, spawn.rotation);


			if(!infiniteAmmo){
				ammoLeft--;
			}
		}

		if (isAutomatic) {
			nextShotTime = Time.time + timeBetweenShots;
		} else {
			canShoot = false;
		}

		
	}

	virtual public void TriggerReleased(){
		canShoot = true;
	}
}
