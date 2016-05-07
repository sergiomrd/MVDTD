using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIBuyingTurretController : MonoBehaviour {


	[SerializeField]
	private List<GameObject> turretList = new List<GameObject>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BuyTurret(string type)
	{
		FloorTile tileToPlace = TouchController.Instance.SelectedTile;

		if(!tileToPlace.HasTurretOverTile)
		{
			switch(type.ToLower())
			{
			case "normalturret":

				tileToPlace.SetTurretOnTile(turretList[0]);

				break;
			}
		}

			
	}
		
}
