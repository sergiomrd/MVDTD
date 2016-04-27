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
	void Start()
	{
		_camera = Camera.main;
	}

	void Update()
	{
		Vector3 v3;

		Touch [] touches = Input.touches;

		if(touches.Length > 0)
		{
			if(touches.Length == 1)
			{
				TouchPhase phase = touches[0].phase;

				Vector3 pos = touches[0].position;

				switch(phase)
				{
				case TouchPhase.Began:

					Ray ray = Camera.main.ScreenPointToRay(pos);
					RaycastHit hitInfo;

					if(Physics.Raycast(ray, out hitInfo))
					{
						
						//If we hit something, the camera will be blocked
						_camera.GetComponent<CameraController>().BlockCamera = true;

						if(hitInfo.collider.GetComponent<Draggable>() != null)
						{
							gameObjectToDrag = hitInfo.transform.gameObject;
							Debug.Log(gameObjectToDrag);
							dist = hitInfo.transform.position.z - _camera.transform.position.z;
							v3 = new Vector3(pos.x, pos.y, pos.z);
							v3 = Camera.main.ScreenToWorldPoint(v3);
							offset = gameObjectToDrag.transform.position - v3;

						}




						
					}

					break;
				case TouchPhase.Moved:

					if(gameObjectToDrag != null)
					{
						v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
						v3 = Camera.main.ScreenToWorldPoint(v3);
						gameObjectToDrag.transform.position = v3 + offset;

						_camera.GetComponent<CameraController>().BlockCamera = true;
					}

	
					break;
				case TouchPhase.Ended:

					gameObjectToDrag = null;
					_camera.GetComponent<CameraController>().BlockCamera = false;

					break;
				}
			}
		}
	}


}
