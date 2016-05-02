using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public float speedMovement;

	Rigidbody rb;

	// Use this for initialization
	void Start () {
	
		rb = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Vector3 movement = Vector3.left * speedMovement * Time.deltaTime;
		rb.MovePosition(rb.position + movement);
	
	}
}
