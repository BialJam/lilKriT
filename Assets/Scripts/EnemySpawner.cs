using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] enemyTypes;
	public int[] enemySpawnRates;
	public float radius;

	//public bool isActive;
	public Tile[] tiles;

	public float timeBetweenWaves;
	public float nextWaveTime;

	public bool isHostile = true;

	public GameObject spawnerBase;
	public GameObject spawnerOrb;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (isHostile) {
			SpawnEnemies ();
			CheckTiles ();
		}
	}

	public void SpawnEnemies(){
		if(isHostile && Time.time > nextWaveTime){

			nextWaveTime = Time.time + timeBetweenWaves;

			for(int i = 0; i < enemyTypes.Length; i++){
				for(int j = 0; j < enemySpawnRates[i]; j++){
					Vector3 position = Random.insideUnitCircle * radius;
					position += transform.position;

					GameObject.Instantiate (enemyTypes [i], position, Quaternion.identity);
				}
			}
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
			isHostile = false;
			spawnerBase.GetComponent<MeshRenderer>().material.color = Color.green;
			spawnerOrb.GetComponent<MeshRenderer>().material.color = Color.green;
		}
	}
}
