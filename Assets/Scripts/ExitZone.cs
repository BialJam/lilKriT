using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitZone : MonoBehaviour {

	public string loadedLevel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.CompareTag("Player")){
			SceneManager.LoadScene (loadedLevel);
		}

	}
}
