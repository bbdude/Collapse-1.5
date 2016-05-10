using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class collectItemsGui : MonoBehaviour{
	public Texture2D plank;
	public Texture2D nails;
	public Texture2D fish;
	public Texture2D back;
	public Texture2D map;
	public Texture2D mast;

	public List<Items> listOfItems = new List<Items>(0);

	public void addItem(string type, int amount)
	{
		Items item;
		item = new Items(amount);
		switch(type)
		{
		case "plank":
			item.item = plank;
			item.type = "plank";
			break;
		case "nails":
			item.item = nails;
			item.type = "nails";
			break;
		case "fish":
			item.item = fish;
			item.type = "fish";
			break;
		case "map":
			item.item = map;
			item.type = "map";
			break;
		case "mast":
			item.item = mast;
			item.type = "mast";
			break;
		default:
			break;
        }
		item.back = back;
		item.pos = new Rect(0,Screen.height - 25,200,25);
		
		if (listOfItems.Count > 0)
		{
			foreach (Items temp in listOfItems)
			{
				temp.pos.y -= 25;
			}
		}
		item.timer = 500;
		item.text = "      Collected: " + amount.ToString();
		item.amn = amount;
        listOfItems.Add(item);
		return;
	}
	
}

public class Items {
	public Rect pos = new Rect(0,Screen.height - 25,200,25);
	public Texture2D back;
	public Texture2D item;
	public string text = "";
	public int timer;
	public string type;
	public int amn;
	public Items(int amount)
	{
		amn = amount;
	}

	public void Draw()
	{
		GUI.color = Color.white;
		GUI.DrawTexture(pos,back);
		Rect tempPos = pos;
		tempPos.width = 25;
		GUI.DrawTexture(tempPos,item);
		GUI.Label(pos,text);
		//GUI.TextField(pos,text);
		timer--;
	}
}
