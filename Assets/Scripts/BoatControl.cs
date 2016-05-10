using UnityEngine;
using System.Collections;

public class BoatControl : MonoBehaviour {

	public GameObject boat;
	public Object boatPrefab;
	//public Rigidbody rb;
	public float speed = 6.0f;
	// Use this for initialization
	void Start () {
		//boat = Instantiate(boatPrefab,Vector3.zero,Quaternion.identity) as GameObject;
		boat = GameObject.Find("Boat");
		boat.transform.position = new Vector3(0,-0.66f,0);
	}

	private void moveForward(float newspeed) {
		//Vector3 newPos = boat.transform.localPosition + ( boat.transform.forward * speed * Time.deltaTime);
		//boat.transform.position = Vector3.MoveTowards(boat.transform.position, newPos, speed * Time.deltaTime);
		Vector3 newPos = boat.transform.position + ( boat.transform.forward * newspeed * Time.deltaTime);
		boat.transform.position = Vector3.MoveTowards(boat.transform.position, newPos, speed * Time.deltaTime);
		//transform.localPosition += transform.forward * speed * Time.deltaTime;
	}
	
	private void moveLeft(float newspeed,float up) {
		boat.transform.Rotate(0, newspeed *Time.deltaTime, 0);
		if (up == 0.1f)
			//return;
		//else
		moveForward(Mathf.Abs(newspeed));	
		//Vector3 newPos = boat.transform.position - ( boat.transform.right * newspeed * Time.deltaTime);
		//boat.transform.position = Vector3.MoveTowards(boat.transform.position, newPos, speed * Time.deltaTime);
		//transform.localPosition -= transform.right * speed * Time.deltaTime;
	}
	// Update is called once per frame
	/*void OnMouseDown() {
		Application.CaptureScreenshot("Screenshot.png");
	}*/
	void Update () {
		float up = Input.GetAxis("Vertical");
		float side = Input.GetAxis("Horizontal");
		if (up == 0)
			up = 0.1f;
		moveForward(up * speed);
		moveLeft(side * speed,up);
		//if (
	}
}
