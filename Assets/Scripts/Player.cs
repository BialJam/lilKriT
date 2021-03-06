﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(PlayerController))]
[RequireComponent (typeof(GunController))]
public class Player : Entity {

	PlayerController pc;
	GunController gc;
	GameManager manager;

	public Transform gunHold;

	void Awake(){
		pc = GetComponent<PlayerController> ();
		gc = GetComponent<GunController> ();
		manager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager>();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//movement
		Vector3 movement = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
		movement.Normalize ();

		pc.Move (movement * movementSpeed);

		//aiming
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Vector3 aimPoint;

		if(Physics.Raycast(ray, out hit)){
			aimPoint = hit.point;
			aimPoint = new Vector3 (aimPoint.x, transform.position.y, aimPoint.z);

			transform.LookAt (aimPoint);

			gc.AimGun(aimPoint);
		}

		//shooting
		if (Input.GetMouseButton (0)) {
			//print ("Shooting");
			gc.TriggerPulled ();
		} else if(Input.GetMouseButtonUp(0)) {
			gc.TriggerReleased ();
		}

		//changing weapons
		if(Input.mouseScrollDelta.y != 0){
			gc.ScrollWeapon ((int)Input.mouseScrollDelta.y);
		}

		if(Input.GetButtonDown("Cancel")){
			SceneManager.LoadScene ("menu");
		}
	}

	public void Heal(int amount){
		HP += amount;

		Mathf.Clamp (HP, 0, HPMax);
	}

	public override void Die ()
	{
		base.Die ();
		manager.OnPlayerDeath ();
		Destroy (this.gameObject);
	}
		
}
