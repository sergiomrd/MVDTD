using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour {

	//Declares the game object to be dragged
	[SerializeField]
	private GameObject gameObjectToDrag;

	[SerializeField]
	private float speedMovement;

	private float dist;
	private Vector3 offset;
	private Vector3 touchWorld;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		/*
		//If the thing has the component Draggable, then we will move it
		if(hitInfo.collider.GetComponent<Draggable>() != null)
		{
			//We get the object to drag
			gameObjectToDrag = hitInfo.transform.gameObject;

			//We create a vector of the touch position in World
			touchWorld = Camera.main.ScreenToWorldPoint(pos);

			//The offset is set as the current transform of the object minus the actual position of the touch
			offset = gameObjectToDrag.transform.position - touchWorld;
		}
		*/

		/*
		//If we have something to drag
		if(gameObjectToDrag != null)
		{
			//We get the touch position in the World
			touchWorld = Camera.main.ScreenToWorldPoint(pos);
			//Set the Z Axis to 0
			touchWorld.z = 0;
			//Set the object position to our touch position and adds some offset
			gameObjectToDrag.transform.position = touchWorld + offset;


		}
		*/

		//If we stop touching, the game object turns null
		//gameObjectToDrag = null;

	}
}
