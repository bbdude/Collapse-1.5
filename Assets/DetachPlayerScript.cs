using UnityEngine;
using System.Collections;

public class DetachPlayerScript : MonoBehaviour {

	// Use this for initialization
	public GameObject player;
	public string levelToLoad = "";

	void OnTriggerStay(Collider other)
	{
		if (Input.GetKeyUp(KeyCode.Space) && other.tag == "Player")
		{
 			Application.LoadLevel(levelToLoad);
		}
	}
}
