using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {

	public float speedMovement;

	Rigidbody rb;

	// Use this for initialization
	void Start () {
	
		rb = gameObject.GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 movement = Vector3.right * speedMovement * Time.deltaTime;
		rb.MovePosition(rb.position + movement);

	}
}
