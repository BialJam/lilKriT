using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Collider))]
public class Tile : MonoBehaviour {

	public int enemyCount;
	public int playerCount;

	public float captureSpeed;
	public float recaptureSpeed;

	public enum State
	{
		ownedByEnemy, neutral, ownedByPlayer
	}

	public State tileState = State.ownedByEnemy;

	[Range (-1, 1)]
	public float color;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		UpdateBalance ();
		UpdateColor ();
	}

	void OnTriggerEnter(Collider col){
		if(col.CompareTag("Player")){
			print ("Player entered this tile");
			playerCount++;
		}

		if(col.gameObject.layer == LayerMask.NameToLayer("Enemy")){
			print ("enemy entered this tile");
			enemyCount++;
		}
	}

	void OnTriggerExit(Collider col){
		if(col.CompareTag("Player")){
			print ("Player left this tile");
			playerCount--;
		}

		if(col.gameObject.layer == LayerMask.NameToLayer("Enemy")){
			print ("enemy left this tile");
			enemyCount--;
		}
	}

	public void UpdateBalance(){
		int balance = playerCount - enemyCount;
		color += balance * captureSpeed * Time.deltaTime;

		color = Mathf.Clamp (color, -1f, 1f);
	}

	public void UpdateColor(){
		MeshRenderer mr = GetComponentInChildren<MeshRenderer> ();
		if(color >= 0){
			mr.material.color = Color.Lerp(Color.white, Color.green, color);
		} else {
			mr.material.color = Color.Lerp (Color.white, Color.red, -color);
		}

	}
}
