using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloorTile : MonoBehaviour {

	private bool hasTurretOverTile = false;

	public bool HasTurretOverTile {
		get {
			return hasTurretOverTile;
		}
		set {
			hasTurretOverTile = value;
		}
	}

	private float x;
	private float y;

	private int xID;
	private int yID;

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

	void Start()
	{
		x = gameObject.transform.position.x;
		y = gameObject.transform.position.y;
	}
		
	public void SetTurretOnTile(GameObject turret)
	{
		GameObject turretToSet = turret;

		// Sets the turret and makes the layers right
		GameObject turretInstance = Instantiate(turretToSet, transform.position, Quaternion.identity) as GameObject;
		turret.GetComponent<SpriteRenderer>().sortingOrder = YID * -1;
		hasTurretOverTile = true;

	}



}
