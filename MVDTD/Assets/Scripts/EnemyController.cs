using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	// Speed movement of the Enemy
	public float speedMovement;

	[SerializeField]
	private int moneyCost;

	public int MoneyCost {
		get {
			return moneyCost;
		}
	}

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
	
		rb = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		// Speed movement of the Rigidbody
		Vector3 movement = Vector3.left * speedMovement * Time.deltaTime;
		rb.MovePosition(rb.position + movement);
	
	}
}
