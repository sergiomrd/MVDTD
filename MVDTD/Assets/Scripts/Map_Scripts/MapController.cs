using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapController : MonoBehaviour
{

	// Making an instance of the Map
	public static MapController Instance { get; private set; }

	// TODO: Should be a list of prefabs to instantiate
	public GameObject tilePrefab;

	// List of the tiles of the map
	private List<GameObject> floorTilesList = new List<GameObject> ();

	// Map size
	[SerializeField]
	private int mapWidth = 9;
	[SerializeField]
	private int mapHeight = 5;

	public int MapHeight {
		get {
			return mapHeight;
		}
	}

	public int MapWidth {
		get {
			return mapWidth;
		}
	}

	// Offset of the tiles
	private float yOffset = 0.375f;
	private float xOffset = 0.78f;
	private float newXOffset;

	public List<GameObject> FloorTilesList {
		get {
			return floorTilesList;
		}
	}

	void Awake ()
	{
		if (Instance != null && Instance != this) {
			Destroy (gameObject);
		} else {
			Instance = this;
		}

		CreateMap ();
	}


	void Start ()
	{



	}

	void CreateMap ()
	{
		//TODO: Adapt for more tile types
		for (int x = 0; x < mapWidth; x++) {
			
			newXOffset = 0.375f;

			for (int y = 0; y < mapHeight; y++) {
				
				if (y != 0) { 
					GameObject normalTile = Instantiate (tilePrefab, new Vector2 ((x * xOffset) + (newXOffset), y * yOffset), Quaternion.identity) as GameObject;
					normalTile.transform.GetChild (0).GetComponent<FloorTile> ().XID = x;
					normalTile.transform.GetChild (0).GetComponent<FloorTile> ().YID = y;
					newXOffset += xOffset / 2;
					normalTile.transform.SetParent (this.gameObject.transform);
					normalTile.name = ("Tile" + "_" + x + "_" + y);
					floorTilesList.Add (normalTile);
				} else {
					GameObject normalTile = Instantiate (tilePrefab, new Vector2 (x * xOffset, y * yOffset), Quaternion.identity) as GameObject;
					normalTile.transform.GetChild (0).GetComponent<FloorTile> ().XID = x;
					normalTile.transform.GetChild (0).GetComponent<FloorTile> ().YID = y;
					normalTile.transform.SetParent (this.gameObject.transform);
					normalTile.name = ("Tile" + "_" + x + "_" + y);
					floorTilesList.Add (normalTile);
				}
					

			}
		}
	}
		
}
