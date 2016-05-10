using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

	#endregion

	#region Public variables

	/*
	 * PUBLIC VARIABLES
	*/

	#endregion

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
