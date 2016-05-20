﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof(PlayerController))]
public class Player : Entity {

	PlayerController pc;

	void Awake(){
		pc = GetComponent<PlayerController> ();
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
		}
	}
		
}