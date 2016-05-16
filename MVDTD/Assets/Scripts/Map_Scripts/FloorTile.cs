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
    private Sprite normalSprite, betweenSprite;

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

		// Sets the turret and makes the layers right
		turretInstance = Instantiate (turretToSet, transform.position, Quaternion.identity) as GameObject;
		turretInstance.GetComponent<SpriteRenderer> ().sortingOrder = yID * -1;
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
                spriteRender.sprite = betweenSprite;
            }
            else
            {
                spriteRender.sprite = normalSprite;
            }

            if((yID % 2 == 0 && xID % 2 == 0) || (yID % 2 == 1 && xID % 2 == 1))
            {
                spriteRender.color = new Color(255 / 255f, 215 / 255f, 215 / 255f, 255 / 255f);
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
