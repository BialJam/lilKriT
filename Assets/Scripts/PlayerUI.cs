using UnityEngine;
using System.Collections;

public class PlayerUI : MonoBehaviour {

	public Player player;

	public UnityEngine.UI.Text ammoLeft;
	public UnityEngine.UI.Slider healthBar;

	// Use this for initialization
	void Start () {
		healthBar.minValue = 0;
		healthBar.maxValue = player.HPMax;
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.value = player.HP;
		//print (player.HP);
		if (player.GetComponent<GunController> ().equippedGun.infiniteAmmo) {
			ammoLeft.text = "";
		} else {
			ammoLeft.text = player.GetComponent<GunController> ().equippedGun.ammoLeft.ToString();
		}
	}
}
