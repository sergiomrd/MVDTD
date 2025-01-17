﻿using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{

	/*
	 * PUBLIC VARIABLES
	*/

	// Sets the bullet speed
	public float speedMovement;

	public int damageDeal;

	/*
	 * PRIVATE VARIABLES
	*/

	private Rigidbody rb;

	private UIGameplay uiGameplay;

	void Start ()
	{
		
		rb = gameObject.GetComponent<Rigidbody> ();

	}

	void FixedUpdate ()
	{
	
		// We set the movement of the Bullet to the right every frame
		Vector3 movement = Vector3.right * speedMovement * Time.deltaTime;
		rb.MovePosition (rb.position + movement);

	}

	/// <summary>
	/// Raises the trigger enter event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter (Collider other)
	{
		// If we hit an enemy
		if (other.GetComponent<EnemyController> () != null) {

			EnemyController enemy = other.GetComponent<EnemyController>();
			enemy.TakeDamage (damageDeal);

			Destroy (gameObject);
		}
	}
}
