using UnityEngine;
using System.Collections;

public class IIDoorScript : IIHolder {
	bool open = false;
	public bool locked = false;
	public int doorNumber;
	//float openTimer = 100.0f;
	public GameObject pivot;
	IEnumerator Open (float startRot, float endRot, float duration) {
		float speed = 1.0f/duration;  
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime*speed) {
			if (!open)
				pivot.transform.Rotate(new Vector3(0,t,0));
			else
				pivot.transform.Rotate(new Vector3(0,-t,0));
			if (pivot.transform.rotation.eulerAngles.y >= 90.0f && !open)
			{
				Vector3 newRot = pivot.transform.rotation.eulerAngles;
				newRot.y = 90;
				pivot.transform.rotation = Quaternion.Euler(newRot);
				open = true;
				StopAllCoroutines();
				//pivot.transform.rotation = new Quaternion(
			}
			else if ((pivot.transform.rotation.eulerAngles.y <= 00.0f || pivot.transform.rotation.eulerAngles.y >= 340.0f) && open)
			{
				Vector3 newRot = pivot.transform.rotation.eulerAngles;
				newRot.y = 0;
				pivot.transform.rotation = Quaternion.Euler(newRot);
				open = false;
				StopAllCoroutines();
				//pivot.transform.rotation = new Quaternion(
			}
			//{
			//	fadeStep = 2;
			//	StopAllCoroutines();
			//}
			yield return null;
		}
	}
	// Use this for initialization
	void Start () {
		pivot = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		/*if (open)
		{
			openTimer--;
			if (openTimer <= 0)
			{
				openTimer = 0;
				StopAllCoroutines();
				StartCoroutine(Open(90,0,2.6f));
			}
		}*/
	}
	void Interact()
	{
		if (!open && !locked)
		{
			StartCoroutine(Open(0,90,3.2f));
			Debug.Log("Door open");
		}
		if (open)
		{
			StartCoroutine(Open(0,90,3.2f));
			Debug.Log("Door close");
		}
	}
}
