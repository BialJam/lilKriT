using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

	public int HP;
	public int HPMax;

	public float movementSpeed;

	virtual public void Move(Vector3 _velocity){

	}

	virtual public void Die(){

	}

	virtual public void TakeHit(RaycastHit hit, int damage){
		TakeDamage (damage);
	}

	virtual public void TakeDamage(int damage){
		HP -= damage;
		if(HP <= 0){
			Die ();
		}
	}


}
