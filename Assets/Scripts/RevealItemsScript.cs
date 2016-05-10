using UnityEngine;
using System.Collections;

public class RevealItemsScript : MonoBehaviour {
	public Material shinyMat;
	void OnTriggerEnter ( Collider obj) {
		if (obj.gameObject.tag == "II")
		{
			//Renderer ren = obj.gameObject.GetComponent<Renderer>();
			//Material[] mats = ren.materials; 
			//mats[0] = shinyMat; 
			//ren.materials = mats;
			//(obj.GetComponent("Halo") as Behaviour).enabled = true;

			InteractiveScript iis = obj.gameObject.GetComponent<InteractiveScript>();
			iis.enabled = true;
			//iis.fadeTime = 500;
		}
		//}
	}
}
