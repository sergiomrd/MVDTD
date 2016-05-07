using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public static UIController Instance {get; private set;}

	public enum UItype {TileMenu, TurretMenu}

	private UItype uiType;

	[SerializeField]
	private List<GameObject> UIPanelList = new List<GameObject>();

	[SerializeField]
	private GameObject tileMenu;

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
			}
		}
	}

	public GameObject GetChildPanel(UItype type)
	{
		switch(type)
		{
		case UItype.TileMenu:

			return UIPanelList[0];

			break;
		}

		return null;
	}

	public void SetActive_TileMenu(bool choice, FloorTile tile)
	{
		tileMenu = GetChildPanel(UItype.TileMenu);

		if(choice)
		{
			tileMenu.SetActive(true);
			tileMenu.transform.position = new Vector3(tile.X,tile.Y);
		}
		else
		{
			tileMenu.SetActive(false);
		}
	}

	public void SetActive_TowerMenu(bool choice, FloorTile tile)
	{
		tileMenu = GetChildPanel(UItype.TileMenu);

		if(choice)
		{
			tileMenu.SetActive(true);
			tileMenu.transform.position = new Vector3(tile.X,tile.Y);
		}
		else
		{
			tileMenu.SetActive(false);
		}
	}
}

