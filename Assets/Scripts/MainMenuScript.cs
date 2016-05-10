using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void changeLevel(){
		Application.LoadLevel("Test");
	}
	public void Exit(){
		Application.Quit();
	}
}
