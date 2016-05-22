using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void QuitGame(){
		Application.Quit ();
	}

	public void NewGame(){
		SceneManager.LoadScene ("levelOne");
	}

	public void LevelOne(){
		SceneManager.LoadScene ("levelOne");
	}

	public void LevelTwo(){
		SceneManager.LoadScene ("levelTwo");
	}

	public void LevelThree(){
		SceneManager.LoadScene ("levelThree");
	}

	public void LevelFour(){
		SceneManager.LoadScene ("levelFour");
	}
}
