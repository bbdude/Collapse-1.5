using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Quest
{
	public Rect pos = new Rect(Screen.width - (Screen.width/7),Screen.height/3,500,25);
	public Quest()
	{
	}
	public virtual void addCollect(int amount, string typeCollect)
	{
	}
	
	public virtual bool check(){
		return false;
	}
	public virtual bool check(Vector3 one){
		return false;
	}
	public virtual string textToDisplay()
	{
		return "";
	}
	public virtual void Draw()
	{
		GUI.Label(pos,"Failure to load");
	}
}
public class collectingQuest : Quest
{

	int collect = 0;
	int max = 0;
	string type = "";
	public string text = "";
	public string textVar = "";

	public collectingQuest(int maxCollect,string typeCollect)
	{
		max = maxCollect;
		type = typeCollect;
	}
	public override void addCollect(int amount, string typeCollect)
	{
		if (type == typeCollect)
			collect += amount;
	}

	public override bool check(Vector3 one){
		if (collect >= max)
		{
			return true;
		}
		return false;
	}
	public override string textToDisplay()
	{
		return "Collected: " + collect.ToString() + "/" + max.ToString();
	}
	public override void Draw()
	{
		GUI.color = Color.black;
		Rect tempPos = pos;
		tempPos.y += 25;
		GUI.Label(pos,"Collect " + max.ToString() + " " + type);
		GUI.Label(tempPos,textToDisplay());
	}

}
public class locationQuest : Quest
{
	Vector3 point;
	float range;
	public string location = "";
	public string textVar = "";
	
	public locationQuest(Vector3 pointV3,float rangeF, string loc)
	{
		location = loc;
		point = pointV3;
		range = rangeF;
	}
	
	public override bool check(Vector3 loc){
		if (Mathf.Pow((loc.x - point.x),2) + Mathf.Pow((loc.z - point.z),2) < Mathf.Pow(range,2))
		{
			return true;
		}
		/*if (collect >= max)
		{
			return true;
		}*/
		return false;
	}
	public override  void Draw()
	{
		GUI.color = Color.black;
		GUI.Label(pos,"Reach : " + location);
	}
	public override void addCollect(int amount, string typeCollect){}
}
[SerializeField]
public class QuestTracker : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	public List<Quest> questList = new List<Quest>(0);

	void Update()
	{

	}
}
