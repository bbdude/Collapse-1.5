using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public GameObject scanner;
	public SphereCollider scannerBelt;
	public bool scannerActive = false;
	public bool scanning = false;
	public float speed = 6.0f;
	public Animator anim;
	public Camera myCamera;
	public bool[] KeyRing = new bool[5]{false,false,false,false,false};
	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		//Cursor.visible = false;
    }
	private void moveForward(float speed) {
		transform.localPosition += transform.forward * speed * Time.deltaTime;
	}
	
	private void moveBack(float speed) {
		transform.localPosition -= transform.forward * speed * Time.deltaTime;
	}
	
	private void moveRight(float speed) {
		transform.localPosition += transform.right * speed * Time.deltaTime;
	}
	
	private void moveLeft(float speed) {
		transform.localPosition -= transform.right * speed * Time.deltaTime;
    }
	// Update is called once per frame
	void Update () {
		
		//Screen.lockCursor = true;
		Cursor.lockState = CursorLockMode.Locked;
		//Screen.lockCursor = false;

		myCamera.transform.position = this.transform.position;

		Cursor.visible = false;

        float up = Input.GetAxis("Vertical");
		float side = Input.GetAxis("Horizontal");
		bool crouching = Input.GetButton("Crouch");
		bool running = Input.GetButton("Run");
		
		if (crouching) 
			speed = 8;
		else if (running) speed = 20;
		else speed = 12;

		if (up != 0)
			anim.SetBool("Running",true);
		else
			anim.SetBool("Running",false);


		if (side > 0)
		{
			anim.SetBool("TurnLeft",true);
			anim.SetBool("TurnRight",false);
		}
		else if (side < 0)
		{
			anim.SetBool("TurnLeft",false);
			anim.SetBool("TurnRight",true);
		}
		else
		{
			anim.SetBool("TurnLeft",false);
			anim.SetBool("TurnRight",false);
		}

		moveForward(up * speed);
		moveLeft(side * -speed);

        if (Input.GetMouseButtonDown(0))
		{
			//Application.CaptureScreenshot("Screenshot.png");
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit = new RaycastHit();
			//bool rayhit = false;
			if (Physics.Raycast (ray, out hit, 51.0f)) {
				if (hit.collider.tag == "II") {
                    hit.collider.SendMessageUpwards ("Interact", SendMessageOptions.DontRequireReceiver);
                }
			}
		}


		if (scannerActive && !scanning)
		{
			StartCoroutine("Scan");
		}
		else if (!scannerActive)
		{
			StopAllCoroutines();
			scannerBelt.radius = 0;
			scanning = false;
		}
	}
	IEnumerator Scan()
	{
		scanning = true;
		for (int i = 0; i < 41; i++)
		{
			scannerBelt.radius += 0.22f;
			if (i == 40)
			{
				scannerBelt.radius = 0;
				scanning = false;
			}
			yield return null;
		}
	}
}
