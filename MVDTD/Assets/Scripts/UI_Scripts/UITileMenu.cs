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

			if(canBuy(turretList[0]))
			{
				tileToPlace.SetTurretOnTile (turretList [0]);
				UIController.Instance.SetActive_TileMenu (false);
			}
			else
			{
				Debug.Log("No money");
			}

			break;
		}
			
	}
		
	private bool canBuy(GameObject turretToBuy)
	{
		int currentMoney = GameManagerController.Instance.Money;
		int moneyCost = turretToBuy.GetComponent<TurretController>().MoneyCost;

		if(currentMoney >= moneyCost)
		{
			GameManagerController.Instance.Money -= moneyCost;
			return true;
		}

		return false;
	}
		
}
