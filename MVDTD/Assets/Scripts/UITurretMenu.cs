using UnityEngine;
using System.Collections;

public class UITurretMenu : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void SellTurret ()
	{
		
		FloorTile selectedTile = TouchLeanController.Instance.SelectedTile;
		UIController.Instance.SetActive_TowerMenu (false);
		selectedTile.HasTurretOverTile = false;
		Destroy (selectedTile.TurretInstance.gameObject);
	
	}
}
