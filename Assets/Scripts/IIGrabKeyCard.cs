using UnityEngine;
using System.Collections;

public class IIGrabKeyCard : IIHolder {
	public PlayerScript Player;
	public int keyNumber = 0;
	public IIDoorScript doorToUnlock;

	// Use this for initialization
	void Start () {
	
	}
	
	void Interact()
	{
		
		Debug.Log("Key Grabbed:" + keyNumber.ToString());
		Player.KeyRing[keyNumber] = true;
		if (doorToUnlock != null)
			doorToUnlock.locked = false;
		Destroy(this.gameObject);
	}
}
