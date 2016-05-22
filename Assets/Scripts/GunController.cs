using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

	public Gun[] guns;
	public int[] ammo;
	public Gun equippedGun;
	public int equippedIndex;
	public Transform gunHold;

	// Use this for initialization
	void Start () {
		EquipGun (0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void EquipGun(int gunIndex){
		if(equippedGun != null){
			Destroy (equippedGun.gameObject);
		}

		Gun gun = Instantiate (guns [gunIndex], gunHold.position, gunHold.rotation) as Gun;
		equippedGun = gun;
		equippedGun.gc = this;
		equippedIndex = gunIndex;
		//gun.transform.SetParent (this.transform);
		gun.transform.SetParent (gunHold);
	}

	public void TriggerPulled(){
		equippedGun.TriggerPulled ();
	}

	public void TriggerReleased(){
		equippedGun.TriggerReleased ();
	}

	public void ScrollWeapon(int scrollValue){
		int weaponToEquip = equippedIndex + scrollValue;
		weaponToEquip = weaponToEquip + guns.Length;
		weaponToEquip %= guns.Length;

		EquipGun (weaponToEquip);
	}

	public void AimGun(Vector3 aimPoint){
		if(Vector3.SqrMagnitude(aimPoint - transform.position) > 1.25f * 1.25f){
			gunHold.LookAt(aimPoint);
		}
	}
}
