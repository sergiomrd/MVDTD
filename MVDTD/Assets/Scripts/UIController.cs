﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{

	// Create an instance of UIController
	public static UIController Instance { get; private set; }

	// Type of GUI menus and stuff
	public enum UItype
	{
		TileMenu,
		TurretMenu,
		GameplayUI

	}

	private UItype uiType;

	public EventSystem eventsystem;

	// We get all the GUI childrens
	[SerializeField]
	private List<GameObject> UIPanelList = new List<GameObject> ();

	// Stores the selected tile
	private FloorTile selectedTile;


	[SerializeField]
	private GameObject activeMenu;

	public GameObject ActiveMenu {
		get {
			return activeMenu;
		}
		set {
			activeMenu = value;
		}
	}

	void Awake ()
	{
		if (Instance != null && Instance != this) {
			Destroy (gameObject);
		} else {
			Instance = this;
		}

		eventsystem = EventSystem.current;
		GetAllChildPanels ();

	}

	/// <summary>
	/// Gets all child GUI.
	/// </summary>
	void GetAllChildPanels ()
	{
		if (gameObject.transform.childCount > 0) {
			for (int i = 0; i < gameObject.transform.childCount; i++) {
				UIPanelList.Add (gameObject.transform.GetChild (i).gameObject);
			}
		}
	}

	/// <summary>
	/// Gets the UI selected.
	/// </summary>
	/// <returns>the UI Gameobject.</returns>
	/// <param name="type">Type.</param>
	public GameObject GetChildPanel (UItype type)
	{
		switch (type) {
		case UItype.TileMenu:

			return UIPanelList [0];

			break;
		
		case UItype.TurretMenu:

			return UIPanelList [1];

			break;
		
		case UItype.GameplayUI:
			
			return UIPanelList[2];

			break;
		}

		return null;
	}

	/// <summary>
	/// Sets the active tile menu.
	/// </summary>
	/// <param name="choice">If set to <c>true</c> choice.</param>
	public void SetActive_TileMenu (bool choice)
	{
		// Get the Tile Menu UI
		GameObject tileMenu = GetChildPanel (UItype.TileMenu);

		// Get the selected tile
		selectedTile = TouchLeanController.Instance.SelectedTile;

		if (choice) {
			// Set the menu visible and makes the menu position over the selected tile
			activeMenu = tileMenu;
			tileMenu.SetActive (true);
			tileMenu.transform.position = new Vector3 (selectedTile.X, selectedTile.Y);
		

		} else {
			
			activeMenu = null;
			tileMenu.SetActive (false);
		

		}
	}

	public void SetActive_TowerMenu (bool choice)
	{
		GameObject towerMenu = GetChildPanel (UItype.TurretMenu);
		selectedTile = TouchLeanController.Instance.SelectedTile;

		if (choice) {
			// Set the menu visible and makes the menu position over the selected tile
			activeMenu = towerMenu;
			towerMenu.SetActive (true);
			towerMenu.transform.position = new Vector3 (selectedTile.X, selectedTile.Y);
		

		} else {
			
			activeMenu = null;
			towerMenu.SetActive (false);

		}
	}
}

