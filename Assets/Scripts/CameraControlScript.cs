using UnityEngine;
using System.Collections;

public class CameraControlScript : MonoBehaviour {
	
	Vector3 lookTarget;
	float speed = 150.0f;
	public bool isCamera = false;
	private Vector3 standHeight = new Vector3(0,11.71f,-0.13f);
	private Vector3 crouchHeight = new Vector3(0,8.38f,-0.13f);
	void Start () {
		
	}
	
	void Update(){ 
		Vector3 holder = Vector3.zero;
		if (!isCamera)
		{
			holder = new Vector3(0, Input.GetAxis("Mouse X"),0) * Time.deltaTime * speed;
			
			this.transform.Rotate(holder);
			this.transform.rotation = Quaternion.Euler(this.transform.rotation.eulerAngles.x,this.transform.rotation.eulerAngles.y,0);
		}
		else if (isCamera)
		{
			Vector3 euler = this.transform.localEulerAngles;
			if (Input.GetAxis("Mouse Y") != 0)
			{
				euler.x -= speed * Time.deltaTime * Input.GetAxis("Mouse Y");
			}
			/*if (Input.GetAxis("Mouse Y") < 180)
			{
				euler.x += speed * Time.deltaTime * Input.GetAxis("Mouse Y");
			}
			else if (Input.GetAxis("Mouse Y") > 0)
			{
				euler.x += speed * Time.deltaTime * Input.GetAxis("Mouse Y");
			}*/
			euler.y = 0;
			euler.z = 0;
			this.transform.localEulerAngles = euler;

			bool crouching = Input.GetButton("Crouch");
			
			if (crouching)
			{
				Vector3 newHeight = this.transform.position;
				newHeight.y = Vector3.MoveTowards(this.transform.position,crouchHeight,6).y;
				this.transform.position = newHeight;
			}
			else
			{
				Vector3 newHeight = this.transform.position;
				newHeight.y = Vector3.MoveTowards(this.transform.position,standHeight,6).y;
				this.transform.position = newHeight;
			}
		}
		
	}
}
