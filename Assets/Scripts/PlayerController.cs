using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {

	public Rigidbody rigidbody;
	private Vector3 movement;

	void Awake(){
		rigidbody = GetComponent<Rigidbody> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Move(Vector3 _movement){
		movement = _movement;
	}

	public void FixedUpdate(){
		rigidbody.MovePosition (transform.position + movement * Time.deltaTime);
	}
}
