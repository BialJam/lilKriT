using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	public Rigidbody rigidbody;
	private Vector3 movement;

	void Awake(){
		rigidbody = GetComponent<Rigidbody> ();
	}

	public void Move(Vector3 _movement){
		movement = _movement;
	}

	public void FixedUpdate(){
		rigidbody.MovePosition (transform.position + movement * Time.deltaTime);
	}
}
