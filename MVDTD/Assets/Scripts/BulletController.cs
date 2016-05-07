using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	// Set of the bullet speed movement
	public float speedMovement;

	private Rigidbody rb;

	void Start () {
	
		rb = gameObject.GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		// We set the movement of the Bullet
		Vector3 movement = Vector3.right * speedMovement * Time.deltaTime;
		rb.MovePosition(rb.position + movement);

	}

	void OnTriggerEnter(Collider other)
	{
		//Hit an Enemy
		if(other.GetComponent<EnemyController>() != null)
		{
			Destroy(other.gameObject);
		}
	}
}
