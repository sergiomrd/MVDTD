using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretController : MonoBehaviour
{
	
    public int maxLife;
	[SerializeField]
	private int currentLife;

	public int CurrentLife {
		get {
			return currentLife;
		}
		set {
			currentLife = value;
			if (currentLife <= 0) 
			{
				Kill ();
			}

		}
	}


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

	private SpriteRenderer[] turretPartsRenderer;


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

    

    // Use this for initialization
    void Start ()
	{
		turretPartsRenderer = gameObject.GetComponentsInChildren<SpriteRenderer> ();

		//Initialize the shoot range to the end of the map
		shootRange = MapController.Instance.FloorTilesList [MapController.Instance.FloorTilesList.Count - 3].transform.localPosition.x;

		//Invokes the method shoot at 0.5f and every fire rate
		InvokeRepeating ("Shoot", 0.5f, fireRate);

		currentLife = maxLife;
	}

	void Update ()
	{
		Debug.DrawRay (new Vector3 (transform.localPosition.x, transform.localPosition.y + 0.3f), new Vector3 (shootRange, 0), Color.blue);
	}

	// Method to know if the turret have any enemy ahead
	bool EnemyInFront ()
	{
		//Origin of the Raycast
		Vector3 raycastOrigin = new Vector3 (transform.localPosition.x, transform.localPosition.y + 0.3f);

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
			GameObject bullet = Instantiate (ammo, new Vector3 (transform.localPosition.x + 0.05f, transform.localPosition.y + 0.25f), Quaternion.identity) as GameObject;
		}
	}

	public void TakeDamage(int damage)
	{
		CurrentLife -= damage;
		StartCoroutine (ChangeHitColor ());
	}

	IEnumerator ChangeHitColor()
	{

		Color startColor = turretPartsRenderer[0].color;

		for (int i = 0; i < turretPartsRenderer.Length; i++) 
		{
			turretPartsRenderer[i].color = Color.red;

			yield return new WaitForSeconds(0.05f);

			turretPartsRenderer [i].color = startColor;
		}
			

	}

	void Kill()
	{
		Destroy (gameObject);
	}
		
		
}
