using UnityEngine;
using System.Collections;

public class TurretBehavior : MonoBehaviour {

	public float shootInterval;

	[SerializeField]
	private LayerMask myLayerMask;

	[SerializeField]
	private GameObject ammo;


	// Use this for initialization
	void Start () {

		InvokeRepeating("Shoot", 0.5f, shootInterval);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
			

	
	}

	bool EnemyInFront()
	{
		RaycastHit [] hits = Physics.RaycastAll(new Vector3(transform.localPosition.x, transform.localPosition.y + 0.5f), transform.right, 100, ~myLayerMask);

		Debug.DrawRay(new Vector3(transform.localPosition.x, transform.localPosition.y + 0.5f, transform.localPosition.z), transform.right);

		for(int i = 0; i < hits.Length; i++)
		{
			RaycastHit hit = hits[i];
			if(hit.collider != null && hit.collider.GetComponent<EnemyBehavior>())
			{
				return true;
			}
		}

		return false;
	}

	void Shoot()
	{
		if(EnemyInFront())
		{
			GameObject bullet = Instantiate(ammo, new Vector3(transform.localPosition.x, transform.localPosition.y + 0.5f), Quaternion.identity) as GameObject;
		}
	}
}
