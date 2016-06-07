using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class FloorTile : MonoBehaviour
{
	#region Private variables

	/*
	 * PRIVATE VARIABLES
	*/

	// Bool to know if the tile has some turret on it
	private bool hasTurretOverTile = false;

	// Get the actual turretInstance over the tile
	private GameObject turretInstance;

	// The actual position of the tile in World Space
	private float x, y;

	// The IDs of the positions not in World Space
	[SerializeField]
	private int xID, yID;

    [SerializeField]
    private List<Sprite> floorSpritesHead;

    [SerializeField]
    private List<Sprite> floorSpritesBody;

    private SpriteRenderer spriteRender;

	#endregion

	#region Public variables

	/*
	 * PUBLIC VARIABLES
	*/

	#endregion
    void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }


	void Start ()
	{
        
		x = gameObject.transform.position.x;
		y = gameObject.transform.position.y;
	}


	/// <summary>
	/// Sets the turret on tile.
	/// </summary>
	/// <param name="turret">Turret.</param>
	public void SetTurretOnTile (GameObject turret)
	{
		GameObject turretToSet = turret;

        Vector3 positionToSet = new Vector3(transform.position.x, transform.position.y, 0);

		// Sets the turret and makes the layers right
		turretInstance = Instantiate (turretToSet, positionToSet, Quaternion.identity) as GameObject;
        turretInstance.GetComponent<TurretController>().TileOverPosition = this;
        SpriteRenderer[] spriteRenderers = turretInstance.GetComponentsInChildren<SpriteRenderer>();

        int mapHeight = MapController.Instance.MapHeight;

      
        for(int j = 0; j < spriteRenderers.Length; j++)
        {
               
            spriteRenderers[j].sortingOrder = -yID;
                
        }

        

		hasTurretOverTile = true;

	}



	/*
	 * PROPERTIES
	*/

	public int YID {
		get {
			return yID;
		}
		set {
			yID = value;
            if(yID > 0)
            {
                spriteRender.sprite = floorSpritesBody[Random.Range(0, floorSpritesBody.Count)];
            }
            else
            {
                spriteRender.sprite = floorSpritesHead[Random.Range(0,floorSpritesHead.Count)];
            }

			if ((yID % 2 == 0 && xID % 2 == 0) || (yID % 2 == 1 && xID % 2 == 1)) {
				spriteRender.color = new Color (255 / 255f, 215 / 255f, 215 / 255f, 255 / 255f);
			} 
		}
	}

	public int XID {
		get {
			return xID;
		}
		set {
			xID = value;
		}
	}

	public float X {
		get {
			return x;
		}
	}

	public float Y {
		get {
			return y;
		}
	}

	public GameObject TurretInstance {
		get {
			return turretInstance;
		}
	}

	public bool HasTurretOverTile {
		get {
			return hasTurretOverTile;
		}
		set {
			hasTurretOverTile = value;
		}
	}

}
