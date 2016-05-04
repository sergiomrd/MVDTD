using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloorTile : MonoBehaviour {

	[SerializeField]
	private GameObject buyTurretUI;

	private bool turretOverTile = false;

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

	//TODO: Menu that specifies the turret
	[SerializeField]
	private GameObject turretToSet;

	public void SetTurret()
	{
		// Sets the turret and makes the layers right
		GameObject turret = Instantiate(turretToSet, transform.position, Quaternion.identity) as GameObject;
		turret.GetComponent<SpriteRenderer>().sortingOrder = YID * -1;

	}

	public void ActiveBuyTurretUI(bool choice)
	{
		if(choice)
		{
			buyTurretUI.SetActive(true);
		}
		else
		{
			buyTurretUI.SetActive(false);
		}
	}

}
