using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// It handle the map creation
public class MapController : MonoBehaviour
{
	// Making an instance of the class MapController
	public static MapController Instance { get; private set; }

    // It takes the main camera of the scene
    public GameObject mainCamera;
    private GameObject mainCameraInstance;

    // TODO: Should be a list of prefabs to instantiate
    public GameObject tilePrefab;

    // Tile prefabs for the boundaries of the map
    public GameObject boundaryTilePrefab;

	// List of the tiles of the map
	private List<GameObject> floorTilesList = new List<GameObject> ();

    // Map size
    [SerializeField]
	private int mapWidth = 9;
	[SerializeField]
	private int mapHeight = 5;

    // Offset of the tiles
    private float yOffset = 0.375f;
    private float xOffset = 0.78f;
    private float newXOffset;

    public int MapHeight {
		get {
			return mapHeight;
		}
        set
        {
            mapHeight = value;
        }
	}

	public int MapWidth {
		get {
			return mapWidth;
		}
        set
        {
            mapWidth = value;
        }
    }

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

        DontDestroyOnLoad(this);
        //InitMap();
        
    }

    // Inits the map
    public void InitMap()
    {
        // If there is no instance of the camera, it creates
        if (mainCameraInstance == null)
        {
            CreateCamera();
        }

        //Create the map and the boundaries
        CreateMap();
        CreateMapBounds();
    }

    // This method instances the camera of the scene and setups as main camera of the scene
    void CreateCamera()
    {
       mainCameraInstance = Instantiate(mainCamera, mainCamera.transform.position, Quaternion.identity) as GameObject;
       Camera.SetupCurrent(mainCameraInstance.GetComponent<Camera>());
    }

    // This method handles the creation of the map
	void CreateMap ()
	{
        Transform child = gameObject.transform.FindChild("Map");

        if (child != null)
        {
            Destroy(child.gameObject);
            //CreateMap();
        }
        
        
        // Adds a container for the tiles
        GameObject mapContainer = new GameObject("Map");
        mapContainer.transform.SetParent(this.gameObject.transform);

        //TODO: Adapt for more tile types
        for (int x = 0; x < mapWidth; x++)
        {

            newXOffset = 0.375f;

            for (int y = 0; y < mapHeight; y++)
            {

                if (y != 0)
                {
                    GameObject normalTile = Instantiate(tilePrefab, new Vector2((x * xOffset) + (newXOffset), y * yOffset), Quaternion.identity) as GameObject;
                    normalTile.transform.GetChild(0).GetComponent<FloorTile>().XID = x;
                    normalTile.transform.GetChild(0).GetComponent<FloorTile>().YID = y;
                    newXOffset += xOffset / 2;
                    normalTile.transform.SetParent(mapContainer.transform);
                    normalTile.name = ("Tile" + "_" + x + "_" + y);
                    floorTilesList.Add(normalTile);
                }
                else
                {
                    GameObject normalTile = Instantiate(tilePrefab, new Vector2(x * xOffset, y * yOffset), Quaternion.identity) as GameObject;
                    normalTile.transform.GetChild(0).GetComponent<FloorTile>().XID = x;
                    normalTile.transform.GetChild(0).GetComponent<FloorTile>().YID = y;
                    normalTile.transform.SetParent(mapContainer.transform);
                    normalTile.name = ("Tile" + "_" + x + "_" + y);
                    floorTilesList.Add(normalTile);
                }

            
                
            }
        }
       
	}

    //This method creates the map bounds for the enemys
    void CreateMapBounds()
    {
        Transform child = gameObject.transform.FindChild("Bounds");

        if (child != null)
        {
            Destroy(child.gameObject);
        }

        // Adds a container for the bounds
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
