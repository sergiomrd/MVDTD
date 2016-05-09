using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour  {

	public static TouchController Instance {get; private set;}

	// This class knows what are you touching.

	// Variable that holds the time that the player has to tap the screen.
	private float longPressTime;

	// Time that the player has to tap the screen at the beggining.
	[SerializeField]
	private float touchTimeInstantiate = 0.5f;

	private bool hasMoved = false;

	// Saves the hitInfo
	private RaycastHit hitInfo;

	// What tile already selected
	private FloorTile selectedTile;

	public FloorTile SelectedTile {
		get {
			return selectedTile;
		}
	}

	void Start()
	{
		// Instance the the long press time
		longPressTime = touchTimeInstantiate;

		if(Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	void Update()
	{
		// Handle the touches
		Touch [] touches = Input.touches;

		if(touches.Length > 0)
		{
			if(touches.Length == 1)
			{
				//We get the phase of the touch
				TouchPhase phase = touches[0].phase;

				// We get the position of touch
				Vector3 pos = touches[0].position;

				// Switch between phases
				switch(phase)
				{

				// If we stay the touch in that position
				case TouchPhase.Stationary:

					/*
					// Long Press time decreases
					longPressTime -= Time.deltaTime;

					if(longPressTime <= 0)
					{
						// If we hit a floot tile
						if(hitInfo.collider != null && hitInfo.collider.GetComponent<FloorTile>() != null)
						{
							// Store the selected tile
							selectedTile = hitInfo.collider.GetComponent<FloorTile>();

							// If the tile doesn't have any turret built
							// We activate the buy turret UI
							if(!selectedTile.HasTurretOverTile)
							{
								UIController.Instance.SetActive_TileMenu(true);
								longPressTime = touchTimeInstantiate;

							}
							else
							{
								UIController.Instance.SetActive_TowerMenu(true);
								longPressTime = touchTimeInstantiate;
							}
				
						}



					}
					*/
					break;

				case TouchPhase.Began:
					
					// Sets a ray where the user has touch
					Ray ray = Camera.main.ScreenPointToRay(pos);


					if(Physics.Raycast(ray, out hitInfo))
					{
						
						//Debug.Log(hitInfo.collider.name);


					}

					break;
				
				case TouchPhase.Moved:

					//TODO: It works but you can do it better
					if(touches[0].deltaPosition.x > 10 || touches[0].deltaPosition.x < -10)
					{
						hasMoved = true;
					}

					longPressTime = touchTimeInstantiate;

					break;

				case TouchPhase.Ended:

					if(!hasMoved)
					{
						if(hitInfo.collider != null && hitInfo.collider.GetComponent<FloorTile>() != null)
						{
							
							// Store the selected tile
							selectedTile = hitInfo.collider.GetComponent<FloorTile>();

							// If the tile doesn't have any turret built
							// We activate the buy turret UI
							if(!selectedTile.HasTurretOverTile)
							{
								UIController.Instance.SetActive_TileMenu(true);
								longPressTime = touchTimeInstantiate;

							}
							else
							{
								UIController.Instance.SetActive_TowerMenu(true);
								longPressTime = touchTimeInstantiate;

							}
						}
					}


					hasMoved = false;
					longPressTime = touchTimeInstantiate;

					break;
				}
			}
		}

	}


}
