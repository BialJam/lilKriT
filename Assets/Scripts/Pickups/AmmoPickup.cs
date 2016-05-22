using UnityEngine;
using System.Collections;

public class AmmoPickup : MonoBehaviour {

	public int ammo;
	public int gunIndex;

	void OnTriggerEnter(Collider col){
		if(col.CompareTag("Player")){
			Player player = col.gameObject.GetComponent<Player> () as Player;
			player.GetComponent<GunController> ().ammo [gunIndex] += ammo;
			//player.HP += health;

			Destroy (this.gameObject);
		}
	}
}
