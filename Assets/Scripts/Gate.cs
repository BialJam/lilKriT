using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {

	public Tile[] tiles;
	public bool isClosed = true;

	public GameObject gateRays;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {	
		if(isClosed){
			CheckTiles ();
		}
	}

	public void CheckTiles(){
		if(tiles.Length == 0){
			return;
		}

		int greenTiles = 0;
		for(int i = 0; i < tiles.Length; i++){
			if (tiles [i].tileState == Tile.State.ownedByPlayer) {
				greenTiles++;
			}
		}

		if(greenTiles >= tiles.Length){
			isClosed = false;
			gateRays.SetActive (false);
		}
	}
}
