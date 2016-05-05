using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public static UIController Instance {get; private set;}

	public enum UItype {BuyTurret}

	private UItype uiType;

	[SerializeField]
	private List<GameObject> UIPanelList = new List<GameObject>();

	void Awake()
	{
		if(Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
		}

	}

	// Use this for initialization
	void Start () {
		
		GetAllChildPanels();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GetAllChildPanels()
	{
		if(gameObject.transform.childCount > 0)
		{
			for(int i = 0; i < gameObject.transform.childCount; i++)
			{
				UIPanelList.Add(gameObject.transform.GetChild(i).gameObject);
				Debug.Log(UIPanelList[i].name);
			}
		}
	}

	public GameObject GetChildPanel(UItype type)
	{
		switch(type)
		{
		case UItype.BuyTurret:

			return UIPanelList[0];

			break;
		}

		return null;
	}
}
