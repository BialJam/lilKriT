using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

	public int HP;
	public int HPMax;

	public float movementSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	virtual public void Move(Vector3 _velocity){

	}

	virtual public void Die(){

	}

	virtual public void TakeHit(){

	}

	virtual public void TakeDamage(){

	}


}
