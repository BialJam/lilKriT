using UnityEngine;
using System.Collections;

public class TileGenerator : MonoBehaviour {

	public string seed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GetRandomTiles(){
		System.Random random = new System.Random (seed.GetHashCode());
	}
}
