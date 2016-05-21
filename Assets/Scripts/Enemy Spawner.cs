using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] enemyTypes;
	public int[] enemySpawnRates;
	public float radius;

	public bool isActive;
	public GameObject[] tiles;

	// Use this for initialization
	void Start () {
		isActive = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
