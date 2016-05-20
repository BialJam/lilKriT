using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public GameObject projectile;
	public int minDamage;
	public int maxDamage;

	public bool infiniteAmmo;
	public int ammoLeft;

	public Transform bulletSpawn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	virtual public void Shoot (){
		if (!infiniteAmmo && ammoLeft == 0) {
			return;
		} else {
			GameObject.Instantiate (projectile, bulletSpawn.position, transform.rotation);
		}
	}
}
