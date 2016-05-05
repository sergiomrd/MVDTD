using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIBuyingTurretController : MonoBehaviour {

	private GameObject activeTile;

	public GameObject ActiveTile {
		get {
			return activeTile;
		}
		set {
			activeTile = value;
		}
	}

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
		if(!ActiveTile.GetComponent<FloorTile>().HasTurretOverTile)
		{
			switch(type.ToLower())
			{
			case "normalturret":

				ActiveTile.GetComponent<FloorTile>().SetTurretOnTile(turretList[0]);

				break;
			}
		}

			
	}
		
}
