using UnityEngine;
using System.Collections;


public class TurretController : MonoBehaviour
{

	//The amount of time wich the turret shoots the next shoot
	public float fireRate;

	//The amount of vision sight of the turret to shoots (Map width of the 3 row)
	public float shootRange;

	//The layers mask that we don't want to be affected by raycast
	[SerializeField]
	private LayerMask layerMask;

	//TODO: Ammo has to be on the Turret Behavior
	//The ammo to shoot
	[SerializeField]
	private GameObject ammo;
    
    private int turretLevel = 1;

	[SerializeField]
	private int moneyCost;

	public int MoneyCost {
		get {
			return moneyCost;
		}
	}

	[SerializeField]
	private int sellCost;

	public int SellCost {
		get {
			return sellCost;
		}
	}

    public int TurretLevel
    {
        get
        {
            return turretLevel;
        }

        set
        {
            turretLevel = value;
        }
    }

    // Use this for initialization
    void Start ()
	{

		//Initialize the shoot range to the end of the map
		shootRange = MapController.Instance.FloorTilesList [MapController.Instance.FloorTilesList.Count - 3].transform.localPosition.x;

		//Invokes the method shoot at 0.5f and every fire rate
		InvokeRepeating ("Shoot", 0.5f, fireRate);
	}

	void Update ()
	{
		Debug.DrawRay (new Vector3 (transform.localPosition.x, transform.localPosition.y + 0.5f), new Vector3 (shootRange, 0), Color.blue);
	}

	// Method to know if the turret have any enemy ahead
	bool EnemyInFront ()
	{
		//Origin of the Raycast
		Vector3 raycastOrigin = new Vector3 (transform.localPosition.x, transform.localPosition.y + 0.5f);

		//Get all the raycasts hits
		RaycastHit[] hits = Physics.RaycastAll (raycastOrigin, transform.right, shootRange, ~layerMask);


		//We go through all the hits
		for (int i = 0; i < hits.Length; i++) {
			RaycastHit hit = hits [i];

			//If we hit some enemy, we have an enemy ahead
			if (hit.collider != null && hit.collider.GetComponent<EnemyController> ()) {
				return true;
			}
		}

		return false;
	}

	//TODO This has to be on the Behavior of the Turret
	void Shoot ()
	{
		//If we have some enemy in Front, we shoot our ammo
		if (EnemyInFront ()) {
			GameObject bullet = Instantiate (ammo, new Vector3 (transform.localPosition.x, transform.localPosition.y + 0.5f), Quaternion.identity) as GameObject;
		}
	}
		
}
