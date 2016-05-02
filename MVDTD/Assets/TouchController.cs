using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour  {

	//Declares the camera
	private Camera _camera;


	//Declares the game object to be dragged
	[SerializeField]
	private GameObject gameObjectToDrag;

	[SerializeField]
	private float speedMovement;
	private float dist;
	private Vector3 offset;
	private Vector3 touchWorld;

	private float touchTime = 2f;

	[SerializeField]
	private float touchTimeInstantiate = 1f;

	private bool longPress = false;

	private RaycastHit hitInfo;

	void Start()
	{
		_camera = Camera.main;
	}

	void Update()
	{

		Touch [] touches = Input.touches;

		if(touches.Length > 0)
		{
			if(touches.Length == 1)
			{
				//We get the phase of the touch
				TouchPhase phase = touches[0].phase;

				// We get the position of touch
				Vector3 pos = touches[0].position;

				switch(phase)
				{

				case TouchPhase.Stationary:

					touchTime -= Time.deltaTime;
					//_camera.GetComponent<CameraController>().BlockCamera = true;

					if(touchTime <= 0)
					{
						if(hitInfo.collider.GetComponent<FloorTile>() != null)
						{
							//TODO Open Turret Menu
							//Fix movement
							hitInfo.collider.GetComponent<FloorTile>().SetTurret();
							touchTime = touchTimeInstantiate;
						}

					}

					break;

				case TouchPhase.Began:
					
					// Sets a ray where the user has touch
					Ray ray = Camera.main.ScreenPointToRay(pos);

					if(Physics.Raycast(ray, out hitInfo))
					{
						
						//If we hit something, the camera will be blocked
						//_camera.GetComponent<CameraController>().BlockCamera = true;

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

					}
					break;
				
				case TouchPhase.Moved:

					touchTime = touchTimeInstantiate;

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

					break;

				case TouchPhase.Ended:
					
					touchTime = touchTimeInstantiate;

					//If we stop touching, the game object turns null
					//gameObjectToDrag = null;


					//And we activate again the camera movement
					//_camera.GetComponent<CameraController>().BlockCamera = false;

					break;
				}
			}
		}

	}


}
