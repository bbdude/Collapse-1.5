using UnityEngine;
using UnityEditor;
using System.Collections;

public class BoatScriptHolder : MonoBehaviour {

	public GameObject plank;
	public GameObject ghostPlank;
	public Rigidbody rb;// = other.GetComponent<Rigidbody>();
	public GameObject[] planks;// = new GameObject();
	public GameObject boatParent;
	public Object prefab;
	public Camera camera;
	Vector3 mPos = new Vector3();
	int planksLeft = 6;
	bool clickedGui = false;
	// Use this for initialization
	public bool doWindow0 = true;
	void DoWindow0(int windowID) {
		if (GUI.Button(new Rect(10, 30, 70, 20), "Save"))
		{
			//Object prefab = EditorUtility.("Assets/Temporary/"+t.gameObject.name+".prefab");
			boatParent.SetActive(true);
			foreach(GameObject i in planks)
			{
				if (i != null)
					i.transform.parent = boatParent.transform;
			}
			BoxCollider box = boatParent.AddComponent<BoxCollider>();
			box.center = new Vector3(0,1.5f,0);
			box.size = new Vector3(4.824648f,1,-6.476211f);

			//Camera cam = new Camera();
			//Camera cam = Instantiate(camera) as Camera;
			//cam.transform.parent = boatParent.transform;
			//cam.transform.position = new Vector3(0.506f,5.17f,-3.4f);
			//Quaternion qua = new Quaternion();
			//qua.eulerAngles = new Vector3(23.77845f,0,0);
			//cam.transform.rotation = qua;// new Quaternion.eulerAngles(new Vector3(23.77845f,0,0));
			//cam.enabled = true;
			//Rigidbody rigid = boatParent.AddComponent<Rigidbody>();
			//rigid.useGravity = true;
			//rigid.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
			EditorUtility.ReplacePrefab(boatParent,prefab, ReplacePrefabOptions.ConnectToPrefab);
			clickedGui = true;
			Application.LoadLevel("Ocean");
		}
		if (GUI.Button(new Rect(80, 30, 100, 20), "Restart"))
			Application.LoadLevel("BoatCreation");
	}
	void OnGUI() {
		doWindow0 = GUI.Toggle(new Rect(10, 10, 100, 20), doWindow0, "Completed");
		if (doWindow0)
			GUI.Window(0, new Rect(110, 10, 200, 60), DoWindow0, "Basic Window");				
	}
	// Update is called once per frame
	void Update () {
		//Vector2 mPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

		mPos = Input.mousePosition;
		mPos.z = 17.5f;
		//mPos -= new Vector3(0,0,20);
		mPos = Camera.main.ScreenToWorldPoint(mPos);
		//rb.MovePosition(Vector3.MoveTowards(ghostPlank.transform.position, mPos, 50.0f * Time.deltaTime));
		mPos.y = 1.77f;
		//mPos -= new Vector3(0,0,35);
		ghostPlank.transform.position = Vector3.MoveTowards(ghostPlank.transform.position, mPos, 50.0f * Time.deltaTime);
		//ghostPlank.transform.position.y = 1.77f;
		//ghostPlank.transform.position = mPos;
		if (Input.GetMouseButtonUp(0) && planksLeft > 0 && !clickedGui)
		{
			planksLeft--;
			planks[planksLeft] = Instantiate(plank,ghostPlank.transform.position,ghostPlank.transform.rotation) as GameObject;

			if (planksLeft == 0)
			{
				ghostPlank.SetActive(false);
			}
		}
		clickedGui = false;// new Vector3(mPos.x/350,1.39f,mPos.y/300);
		//Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
	}
}
