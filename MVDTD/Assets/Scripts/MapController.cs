using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapController : MonoBehaviour {

	public static MapController Instance {get; private set;}

	public GameObject NormalTilePrefab;

	private List<GameObject> floorTiles = new List<GameObject>();

	private int mapWidth = 9;
	private int mapHeight = 5;

	private float yOffset = 0.375f;
	private float xOffset = 0.78f;
	private float newXOffset;

	public List<GameObject> FloorTiles {
		get {
			return floorTiles;
		}
	}

	void Start () {

		if(Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
		}

		CreateMap();

	}

	void Update () {
	
	}

	void CreateMap()
	{
		//TODO: Adapt for more tile types


		for (int x = 0; x < mapWidth; x++) {
			
			newXOffset = 0.375f;

			for (int y = 0; y < mapHeight; y++) {
				
				if(y != 0)
				{ 
					GameObject normalTile = Instantiate(NormalTilePrefab, new Vector2((x * xOffset) + (newXOffset), y * yOffset), Quaternion.identity) as GameObject;
					normalTile.transform.GetChild(0).GetComponent<FloorTile>().XID = x;
					normalTile.transform.GetChild(0).GetComponent<FloorTile>().YID = y;
					newXOffset += xOffset/2;
					normalTile.transform.SetParent(this.gameObject.transform);
					normalTile.name = ("Tile" + "_" + x + "_" + y);
					floorTiles.Add(normalTile);
				}
				else
				{
					GameObject normalTile = Instantiate(NormalTilePrefab, new Vector2(x * xOffset, y * yOffset), Quaternion.identity) as GameObject;
					normalTile.transform.GetChild(0).GetComponent<FloorTile>().XID = x;
					normalTile.transform.GetChild(0).GetComponent<FloorTile>().YID = y;
					normalTile.transform.SetParent(this.gameObject.transform);
					normalTile.name = ("Tile" + "_" + x + "_" + y);
					floorTiles.Add(normalTile);
				}
					

			}
		}
	}

	void GetTileAt(int x, int y)
	{
		
	}
}
