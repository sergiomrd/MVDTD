using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapController : MonoBehaviour
{
    public GameObject mainCamera;

    private GameObject mainCameraInstance;

	// Making an instance of the Map
	public static MapController Instance { get; private set; }

	// TODO: Should be a list of prefabs to instantiate
	public GameObject tilePrefab;

    public GameObject boundaryTilePrefab;

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

    public GameObject MainCameraInstance
    {
        get
        {
            return mainCameraInstance;
        }

        set
        {
            mainCameraInstance = value;
        }
    }

    void Awake ()
	{
		if (Instance != null && Instance != this) {
			Destroy (gameObject);
		} else {
			Instance = this;
		}

        if(mainCameraInstance == null)
        {
            CreateCamera();
        }
        
		CreateMap ();
        CreateMapBounds();
    }

    void CreateCamera()
    {
       mainCameraInstance = Instantiate(mainCamera, mainCamera.transform.position, Quaternion.identity) as GameObject;
       Camera.SetupCurrent(mainCameraInstance.GetComponent<Camera>());
    }

	void CreateMap ()
	{
        GameObject mapContainer = new GameObject("Map");
        mapContainer.transform.SetParent(this.gameObject.transform);

        //TODO: Adapt for more tile types
        for (int x = 0; x < mapWidth; x++) {
			
			newXOffset = 0.375f;

			for (int y = 0; y < mapHeight; y++) {
				
				if (y != 0) { 
					GameObject normalTile = Instantiate (tilePrefab, new Vector2 ((x * xOffset) + (newXOffset), y * yOffset), Quaternion.identity) as GameObject;
					normalTile.transform.GetChild (0).GetComponent<FloorTile> ().XID = x;
					normalTile.transform.GetChild (0).GetComponent<FloorTile> ().YID = y;
					newXOffset += xOffset / 2;
					normalTile.transform.SetParent (mapContainer.transform);
					normalTile.name = ("Tile" + "_" + x + "_" + y);
					floorTilesList.Add (normalTile);
				} else {
					GameObject normalTile = Instantiate (tilePrefab, new Vector2 (x * xOffset, y * yOffset), Quaternion.identity) as GameObject;
					normalTile.transform.GetChild (0).GetComponent<FloorTile> ().XID = x;
					normalTile.transform.GetChild (0).GetComponent<FloorTile> ().YID = y;
					normalTile.transform.SetParent (mapContainer.transform);
					normalTile.name = ("Tile" + "_" + x + "_" + y);
					floorTilesList.Add (normalTile);
				}
					

			}
		}
	}

    void CreateMapBounds()
    {
        GameObject boundContainer = new GameObject("Bounds");
        boundContainer.transform.SetParent(this.gameObject.transform);
        List<Vector3> boundSpawns = new List<Vector3>();

        for (int i = 0; i < FloorTilesList.Count; i++)
        {
            FloorTile tile = FloorTilesList[i].transform.GetChild(0).GetComponent<FloorTile>();
            

            if(tile.XID == 0)
            {
                boundSpawns.Add(new Vector3(tile.transform.parent.position.x - 1f, tile.transform.parent.position.y, 0));
            }
        }

        for(int j = 0; j < boundSpawns.Count; j++)
        {
            GameObject tile = Instantiate(boundaryTilePrefab, boundSpawns[j], Quaternion.identity) as GameObject;
            tile.transform.SetParent(boundContainer.transform);
        }

    }
		
}
