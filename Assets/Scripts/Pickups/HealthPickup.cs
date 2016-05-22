using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {

	public int health;

	void OnTriggerEnter(Collider col){
		if(col.CompareTag("Player")){
			Player player = col.gameObject.GetComponent<Player> () as Player;
			if(player.HP == player.HPMax){
				return;
			}
			player.HP += health;

			Destroy (this.gameObject);
		}
	}
}
