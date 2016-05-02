using UnityEngine;
using System.Collections;

public class FloorTile : MonoBehaviour {

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

	[SerializeField]
	private GameObject turretToSet;

	public void SetTurret()
	{
		Debug.Log(XID + "_" + YID);

		GameObject turret = Instantiate(turretToSet, transform.position, Quaternion.identity) as GameObject;
		turret.GetComponent<SpriteRenderer>().sortingOrder = YID * -1;

	}
		

}
