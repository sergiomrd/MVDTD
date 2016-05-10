using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UITileMenu : MonoBehaviour
{

	[SerializeField]
	private List<GameObject> turretList = new List<GameObject> ();

	public void BuyTurret (string type)
	{
		FloorTile tileToPlace = TouchLeanController.Instance.SelectedTile;

		switch (type.ToLower ()) {
		case "normalturret":

			tileToPlace.SetTurretOnTile (turretList [0]);
			UIController.Instance.SetActive_TileMenu (false);


			break;
		}
		

			
	}
		
}
