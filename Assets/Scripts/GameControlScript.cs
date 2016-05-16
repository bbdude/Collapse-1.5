using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameControlScript : MonoBehaviour {
	public Texture2D border;
	public Texture2D[] bars = new Texture2D[4];
	public Texture2D cursor;
	public Rect[] barPosition = new Rect[4];
	public Rect[] barCrop = new Rect[4];
	public int fadeStep = 0;
	public Color guiColor;
	public PlayerScript pScript;
	public GameObject[] locForQuest = new GameObject[1];
	public AudioSource audioClip = new AudioSource();
	//private bool fadeRunning = false;
	//private bool unfadeRunning = false;

	public bool[] lockBar = new bool[2];
	public collectItemsGui cIGUI;
	public QuestTracker questTracker;
	int questAdvancement = 0;
	
	void OnGUI()
	{ 
		GUI.color = guiColor;
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), border);
		for (int i = 0; i < 4; i++)
		{
			GUI.color = Color.white;
			if (i == 1 || i == 3)
				GUI.BeginGroup(barCrop[i]);
			if (i == 1 && lockBar[0])
				GUI.color = Color.black;
			if (i == 3 && lockBar[1])
				GUI.color = Color.black;
			GUI.DrawTexture(barPosition[i], bars[i]);
			if (i == 1 || i == 3)
				GUI.EndGroup();
		}
		foreach (Items items in cIGUI.listOfItems)
		{
			if (items != null)
			{
				items.Draw();
			}
		}
		foreach (Quest quest in questTracker.questList)
		{
				quest.Draw();
		}
		for (int i = cIGUI.listOfItems.Count - 1; i >= 0; i--)
		{
			if (cIGUI.listOfItems[i].timer <= 0)
			{
				cIGUI.listOfItems.RemoveAt(i);
			}
        }
		for (int i = questTracker.questList.Count - 1; i >= 0; i--)
		{
			if (questTracker.questList[i].check(pScript.transform.position) && questTracker.questList[i] != null)
			{
				questTracker.questList.RemoveAt(i);
				questAdvancement++;
			}
		}
		switch(questAdvancement)
		{
		case 0:
		{
			if (!audioClip.isPlaying)
				audioClip.Play();
			else
				questAdvancement++;
			break;
		}
		case 1:
		{
            createLocQuest(1, "Shack");
            createCollectQuest(10, "plank");
            createCollectQuest(30, "nails");
            createQuestSet();
            //locForQuest[1].SetActive(true);
			//locationQuest tempLQue = new locationQuest(locForQuest[1].transform.position,locForQuest[1].transform.localScale.x/2,"Shacks");
			//questTracker.questList.Add(tempLQue);

			/*collectingQuest tempCQue = new collectingQuest(10,"plank");
			questTracker.questList.Add(tempCQue);

			collectingQuest tempCQueTwo = new collectingQuest(30,"nails");
			questTracker.questList.Add(tempCQueTwo);
			int i = 0;
			if (questTracker.questList.Count > 0)
			{
				foreach (Quest temp in questTracker.questList)
				{
					temp.pos.y += 50 * i;
					i++;
				}
			}
			questAdvancement++;*/
			break;
		}
		case 3:
		{
            createLocQuest(1, "", false);
			//locForQuest[1].SetActive(false);
			break;
		}
		case 5:
		{
                    createLocQuest(2, "Shacks");
                    createCollectQuest(1, "map");
                    createCollectQuest(1, "mast");
                    createQuestSet();


                    /*locForQuest[2].SetActive(true);
			locationQuest tempLQue = new locationQuest(locForQuest[2].transform.position,locForQuest[2].transform.localScale.x/2,"Shacks");
			questTracker.questList.Add(tempLQue);

			collectingQuest tempCQue = new collectingQuest(1,"map");
			questTracker.questList.Add(tempCQue);

			collectingQuest tempCQueTwo = new collectingQuest(1,"mast");
			questTracker.questList.Add(tempCQueTwo);
			
			int i = 0;
			if (questTracker.questList.Count > 0)
			{
				foreach (Quest temp in questTracker.questList)
				{
					temp.pos.y += 50 * i;
					i++;
				}
			}
			//tempCQue = new collectingQuest(1,"fishing pole");
			//questTracker.questList.Add(tempCQue);
			questAdvancement++;*/
			break;
		}
		case 9:
		{
            createLocQuest(2, "Shacks",false);
            //createLocQuest(0, "Shacks",true);
            //        locForQuest[2].SetActive(false);
			//locForQuest[0].SetActive(true);
			questAdvancement++;
			break;
		}
		case 10:
		{
            createLocQuest(0, "Jetty");
            createQuestSet();
            /*locationQuest tempLQue = new locationQuest(locForQuest[0].transform.position,locForQuest[0].transform.localScale.x/2,"Jetty");
			questTracker.questList.Add(tempLQue);
			if (questTracker.questList.Count > 0)
			{
				foreach (Quest temp in questTracker.questList)
				{
					temp.pos.y -= 50;
				}
			}
			questAdvancement++;*/
			break;
		}
		case 12:
		{
            createLocQuest(0, "Jetty",false);
            //locForQuest[0].SetActive(false);
			SceneManager.LoadScene("BoatCreation");
			break;
		}
		default:
			break;
		}
		GUI.DrawTexture(new Rect((Screen.width/2)-5,(Screen.height/2)-5,10,10),cursor);
	}

	IEnumerator Fade (float startLevel, float endLevel, float duration) {
		//fadeRunning = true;
		float speed = 1.0f/duration;  
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime*speed) {
			guiColor.a = Mathf.Lerp(startLevel,endLevel,t);
			if (guiColor.a >= 1.0f)
			{
				fadeStep = 2;
				StopAllCoroutines();
			}
			yield return null;
			//fadeRunning = false;
		}
	}
	IEnumerator UnFade (float startLevel, float endLevel, float duration) {
		//unfadeRunning = true;
		float speed = 1.0f/duration;  
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime*speed) {
			float a = Mathf.Lerp(startLevel,endLevel,t);
			guiColor.a = 1.0f - a;
			if (guiColor.a <= 0.0f)
			{
				fadeStep = 0;
				StopAllCoroutines();
			}
			yield return null;
		}
		//unfadeRunning = false;
	}
    
    void createCollectQuest(int amountNeeded, string name)
    {
        collectingQuest tempCQue = new collectingQuest(amountNeeded, name);
        questTracker.questList.Add(tempCQue);
        return;
    }
    void createKillQuest(int amountNeeded,string name)
    {
        killingQuest tempCQue = new killingQuest(amountNeeded, name);
        questTracker.questList.Add(tempCQue);
        return;
    }
    void createLocQuest(int locToEnable, string name, bool enable = true)
    {
        locForQuest[locToEnable].SetActive(enable);
        if (!enable)
            return;
        locationQuest tempLQue = new locationQuest(locForQuest[locToEnable].transform.position, locForQuest[locToEnable].transform.localScale.x / 2, name);
        questTracker.questList.Add(tempLQue);

        return;
    }
    //run after every set of createQuest funtions
    void createQuestSet(bool advance = true, int howMuch = 1)
    {
        int i = 0;
        if (questTracker.questList.Count > 0)
        {
            foreach (Quest temp in questTracker.questList)
            {
                temp.pos.y += 50 * i;
                i++;
            }
        }
        if (advance)
            questAdvancement += howMuch;
        return;
    }

    void Update () {
		/*if (Input.GetKeyUp(KeyCode.Q))
		{
			if (fadeStep == 0)
			{
				StartCoroutine(Fade(0,250,500.0f));
			}
			else if (fadeStep == 2)
			{
				StartCoroutine(UnFade(0,250,500.0f));
			}
		}*/
		/*if (pScript.scannerActive && !fadeRunning)
		{
			if (unfadeRunning)
				StopAllCoroutines();
			StartCoroutine(Fade(0,250,500.0f));
		}
		if (!pScript.scannerActive && fadeStep == 2 && !unfadeRunning)
		{
			StopAllCoroutines();
			StartCoroutine(UnFade(0,250,500.0f));
		}*/
		//////////bar one/////////////////
		//if (Input.GetKeyUp(KeyCode.Space))
		//{

		//}
		if (Input.GetKey(KeyCode.E) && !lockBar[0])
		{
			if (!pScript.scannerActive)
			{
				pScript.scannerActive = true;
			}
			float cropH = Mathf.Lerp(0,150,Time.deltaTime*0.5f);
			barCrop[1].height -= cropH;
			if (barCrop[1].height <= 0)
			{	lockBar[0] = true; barCrop[1].height = 0;
			}
		}
		else if (barCrop[1].height < 150)
			barCrop[1].height += Mathf.Lerp(0,150,Time.deltaTime*0.1f);
		else if  (lockBar[0])
		{
			if (barCrop[1].height >= 125)
			{	
				lockBar[0] = false; 
				barCrop[1].height = 150;
			}
		}
		////////bar two///////////////
		 if (Input.GetKey(KeyCode.R) && !lockBar[1])
		{
			float cropH = Mathf.Lerp(0,122,Time.deltaTime*0.4f);
			barCrop[3].height -= cropH;
			if (barCrop[3].height <= 29)
			{	lockBar[1] = true; barCrop[3].height = 29;
			}
		}
		else if (barCrop[3].height < 122)
			barCrop[3].height += Mathf.Lerp(0,122,Time.deltaTime*0.08f);
		else if  (lockBar[1])
		{
			if (barCrop[3].height >= 100)
			{	
				lockBar[1] = false; 
				barCrop[3].height = 122;
			}
		}
		if (pScript.scannerActive && (lockBar[0] || !Input.GetKey(KeyCode.E)))
			pScript.scannerActive = false;

		//pScript.scannerActive = !lockBar[1] && Input.GetKey(KeyCode.E);

	}
}
