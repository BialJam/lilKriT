using UnityEngine;
using System.Collections;

[RequireComponent (typeof(LineRenderer))]
public class Turret : MonoBehaviour {

	GameObject player;
	public GameObject cannon;
	public Transform projectileSpawn;
	public Tile[] tiles;

	public float timeBetweenShots;
	public float timeBetweenHeals;
	public float nextShotTime;
	public float range;

	public GameObject projectile;
	public bool isHostile = true;

	public LineRenderer healRay;
	public float healTime;

	public GameObject turretBase;

	public int burstLength;
	public int burstRemaining;
	public float burstCooldown;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		healRay = GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(player == null){
			return;
		}

		if (isHostile) {
			if (Vector3.SqrMagnitude (player.transform.position - transform.position) < range * range) {
				cannon.transform.LookAt (player.transform.position);

				if (Time.time > nextShotTime) {
					Shoot ();
				}
			}

			CheckTiles ();
		} else {
			if (Vector3.SqrMagnitude (player.transform.position - transform.position) < range * range) {
				cannon.transform.LookAt (player.transform.position);

				healRay.SetPosition (0, projectileSpawn.position);
				healRay.SetPosition (1, player.transform.position);

				if (Time.time > nextShotTime) {
					Heal ();
				}
			}
		}
	}

	public void Shoot(){
		GameObject.Instantiate (projectile, projectileSpawn.position, projectileSpawn.rotation);
		//nextShotTime = Time.time + timeBetweenShots;

		burstRemaining--;

		if (burstRemaining <= 0) {
			nextShotTime = Time.time + burstCooldown;
			burstRemaining = burstLength;
		} else {
			nextShotTime = Time.time + timeBetweenShots;
		}
	}

	public void Heal(){
		healRay.enabled = true;

		nextShotTime = Time.time + timeBetweenHeals;
		player.GetComponent<Player> ().Heal (10);

		Invoke ("StopHealing", healTime);
	}

	public void StopHealing(){
		healRay.enabled = false;
	}

	public void CheckTiles(){
		if(tiles.Length == 0){
			return;
		}

		int greenTiles = 0;
		for(int i = 0; i < tiles.Length; i++){
			if (tiles [i].tileState == Tile.State.ownedByPlayer) {
				greenTiles++;
			}
		}

		if(greenTiles >= tiles.Length){
			isHostile = false;
			turretBase.GetComponent<MeshRenderer>().material.color = Color.green;
		}
	}
}
