using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	// Bool to block the camera movement
	[SerializeField]
	private bool blockCameraMovement = false;

	public bool BlockCameraMovement {
		get {
			return blockCameraMovement;
		}
		set {
			blockCameraMovement = value;
		}
	}

	// Speed movement of the camera
	[SerializeField]
	private float speedMovement;
	
	// Update is called once per frame
	void Update () {

		// Get the touches
		Touch [] touches = Input.touches;

		if(touches.Length > 0)
		{
			if(touches.Length == 1)
			{
				//Get the phase of the first touch
				TouchPhase phase = touches[0].phase;

				switch(phase)
				{
				case TouchPhase.Moved:

					// If the camera isn't blocked
					if(!blockCameraMovement)
					{
						// Create a movement vector that saves the delta position and translate it
						Vector2 movement = Input.touches[0].deltaPosition * speedMovement * Time.deltaTime;
						transform.Translate(movement.x * -1 , 0,0);

						// We clamp the area of the camera movement and check the position 
						Vector3 pos = transform.position;
						pos.x = Mathf.Clamp(transform.position.x, 2, 6);
						transform.position = pos;
					}


					break;

				}
					

			}
		}


	}
}
