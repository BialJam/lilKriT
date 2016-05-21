using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Collider))]
public class Tile : MonoBehaviour {

	public int enemyCount;
	public int playerCount;

	public float captureSpeed;
	public float recaptureSpeed;

	public Transform particleSpawn;
	public GameObject captureParticles;

	MeshRenderer mr;

	public enum State
	{
		ownedByEnemy, neutral, ownedByPlayer
	}

	public State tileState = State.ownedByEnemy;

	[Range (-1, 1)]
	public float captureState;

	void Awake(){
		mr = GetComponentInChildren<MeshRenderer> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		UpdateBalance ();
		UpdateState ();
		UpdateColor ();
	}

	void OnTriggerEnter(Collider col){
		if(col.CompareTag("Player")){
			playerCount++;
		}

		if(col.gameObject.layer == LayerMask.NameToLayer("Enemy")){
			enemyCount++;
		}
	}

	void OnTriggerExit(Collider col){
		if(col.CompareTag("Player")){
			playerCount--;
		}

		if(col.gameObject.layer == LayerMask.NameToLayer("Enemy")){
			enemyCount--;
		}
	}

	public void UpdateBalance(){
		if (tileState == State.ownedByPlayer) {
			return;
		}

		int balance = playerCount - enemyCount;
		captureState += balance * captureSpeed * Time.deltaTime;

		if(tileState == State.ownedByEnemy && balance == 0){
			captureState -= captureSpeed * Time.deltaTime;
		}

		captureState = Mathf.Clamp (captureState, -1f, 1f);
	}

	public void UpdateState(){
		if(captureState == -1f){
			tileState = State.ownedByEnemy;
		}
			
		if(captureState == 1f && tileState != State.ownedByPlayer){
			tileState = State.ownedByPlayer;
			GameObject go = GameObject.Instantiate (captureParticles, particleSpawn.position, particleSpawn.rotation) as GameObject;
			Destroy (go, 2.0f);
		}

		if(tileState == State.ownedByEnemy && captureState >= 0f){
			tileState = State.neutral;
		}
	}

	public void UpdateColor(){
		
		if(captureState >= 0){
			mr.material.color = Color.Lerp(Color.white, Color.green, captureState);
		} else {
			mr.material.color = Color.Lerp (Color.white, Color.red, -captureState);
		}

	}
}
