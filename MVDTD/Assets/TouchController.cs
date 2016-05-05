using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour  {

	// Time that the player has to tap the screen
	private float longPressTime;

	// Time that the player has to tap the screen at the beggining
	[SerializeField]
	private float touchTimeInstantiate = 0.5f;

	// Saves the hitInfo
	private RaycastHit hitInfo;

	void Start()
	{
		longPressTime = touchTimeInstantiate;
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

					longPressTime -= Time.deltaTime;
					//_camera.GetComponent<CameraController>().BlockCamera = true;

					if(longPressTime <= 0)
					{
						//TODO: if Can Build
						if(hitInfo.collider != null && hitInfo.collider.GetComponent<FloorTile>() != null)
						{
							//TODO Open Turret Menu and Fix phase moved

							hitInfo.collider.GetComponent<FloorTile>().ActiveBuyTurretUI(true);
							longPressTime = touchTimeInstantiate;

							//if the tile has turret on it open turret menú
						}

					}

					break;

				case TouchPhase.Began:
					
					// Sets a ray where the user has touch
					Ray ray = Camera.main.ScreenPointToRay(pos);


					if(Physics.Raycast(ray, out hitInfo))
					{
						Debug.Log(hitInfo.collider.name);

					}

					break;
				
				case TouchPhase.Moved:

					longPressTime = touchTimeInstantiate;

					break;

				case TouchPhase.Ended:
					
					longPressTime = touchTimeInstantiate;

					break;
				}
			}
		}

	}


}
