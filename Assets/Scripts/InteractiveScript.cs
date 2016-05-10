using UnityEngine;
using System.Collections;

public class InteractiveScript : MonoBehaviour {
	public float fadeTime = 0.0f;
	public Material shinyMat;
	public Material normMat;
	public GameObject InstructSprite;
	public IIHolder scriptToEnable;

	void Start () {
		//Renderer ren = this.gameObject.GetComponent<Renderer>();
		//normMat = ren.material;
		//fadeTime = 0;
		//normMat = this.gameObject.	
	}

	void OnEnable() {
		fadeTime = 13.0f;
		Renderer ren = this.gameObject.GetComponent<Renderer>();
		Material[] mats = ren.materials; 
		mats[0] = shinyMat; 
		ren.materials = mats;
		if (InstructSprite != null)
		{
			InstructSprite.SetActive(true);
		}
	}
	// Update is called once per frame
	void Update () {
		if (fadeTime > 0)
			fadeTime -= Time.deltaTime;
		if (fadeTime < 5 && fadeTime > 0)
		{
			Renderer ren = this.gameObject.GetComponent<Renderer>();
			Material[] mats = ren.materials; 
			mats[0] = normMat; 
			ren.materials = mats;
			this.enabled = false;
			if (InstructSprite != null)
			{
				InstructSprite.SetActive(false);
			}
		}
	}
}
