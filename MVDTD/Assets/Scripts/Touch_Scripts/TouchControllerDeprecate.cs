using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour
{



	public static TouchController Instance { get; private set; }

	// This class knows what are you touching.

	// Bool to know if the player has moved the finger
	private bool hasMoved = false;

	// Saves the hitInfo
	//private RaycastHit hitInfo;
	private RaycastHit hitInfo;


	// What tile already selected
	private FloorTile selectedTile;

	public FloorTile SelectedTile {
		get {
			return selectedTile;
		}
	}



	void Start ()
	{
		if (Instance != null && Instance != this) {
			Destroy (gameObject);
		} else {
			Instance = this;
		}
			
	}



	void Update ()
	{

		// Handle the touches

		Touch[] touches = Input.touches;

		if (touches.Length > 0) {

			if (touches.Length == 1) {

				//We get the phase of the touch
				TouchPhase phase = touches [0].phase;

				// We get the position of touch
				Vector3 pos = touches [0].position;

				// Switch between phases
				switch (phase) {

				case TouchPhase.Began:

					//Debug.Log(hitInfo.collider.name);

					// Sets a ray where the user has touch

					Ray ray = Camera.main.ScreenPointToRay (pos);

					if(Physics.Raycast(ray, out hitInfo))
					{
						
					}

					break;
				
				case TouchPhase.Moved:
					
					//TODO: It works but you can do it better
					if (touches [0].deltaPosition.x > 10 || touches [0].deltaPosition.x < -10) {
						hasMoved = true;

					}
							
					break;

				case TouchPhase.Ended:
						
					if (!hasMoved) {

						if (hitInfo.collider != null && hitInfo.collider.GetComponent<FloorTile> () != null) {
							// Store the selected tile
							selectedTile = hitInfo.collider.GetComponent<FloorTile> ();

							if (!selectedTile.HasTurretOverTile) {

								UIController.Instance.SetActive_TileMenu (true);

							} else {
								
								UIController.Instance.SetActive_TowerMenu (true);
							}
		
						}

						if (hitInfo.collider == null && UIController.Instance.ActiveMenu != null) {
							UIController.Instance.ActiveMenu.SetActive (false);
							UIController.Instance.ActiveMenu = null;
						}


					}

					hasMoved = false;
					break;
				}


			}


		}
	}
}

	



