using UnityEngine;
using System.Collections;

public class IIPickItem : IIHolder {
	public collectItemsGui cIGUI;
	public QuestTracker questTracker;
	public string[] type = new string[2];
	void Interact()
	{
		int ram = Random.Range(1,4);
		cIGUI.addItem(type[0],ram);
		if (type.Length > 1)
			cIGUI.addItem(type[1],ram+2);
		
		foreach (Quest quest in questTracker.questList)
		{
			quest.addCollect(ram,type[0]);
			if (type.Length > 1)
				quest.addCollect(ram + 2,type[1]);
		}


        Destroy(this.gameObject);
	}
}
