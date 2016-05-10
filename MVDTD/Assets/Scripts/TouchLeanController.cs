using UnityEngine;
using System.Collections;

public class TouchLeanController : MonoBehaviour {

	public static TouchLeanController Instance { get; private set;}

	public LayerMask layerMask;

	private RaycastHit hitInfo;

	private FloorTile selectedTile;

	public FloorTile SelectedTile {
		get {
			return selectedTile;
		}
	}

	protected virtual void OnEnable()
	{
		// Hook into the OnFingerTap event
		//Lean.LeanTouch.OnFingerTap += OnFingerTap;
		Lean.LeanTouch.OnFingerDown += OnFingerDown;
		Lean.LeanTouch.OnFingerUp += OnFingerUp;

	}

	protected virtual void OnDisable()
	{
		// Unhook into the OnFingerTap event
		//Lean.LeanTouch.OnFingerTap -= OnFingerTap;
		Lean.LeanTouch.OnFingerDown -= OnFingerDown;
		Lean.LeanTouch.OnFingerUp -= OnFingerUp;
	}

	void Start ()
	{
		if (Instance != null && Instance != this) 
		{
			Destroy (gameObject);
		} 
		else 
		{
			Instance = this;
		}

	}


	void OnFingerDown(Lean.LeanFinger finger)
	{
		

			if(!finger.IsOverGui)
			{
				Ray ray = finger.GetRay();

			if(Physics.Raycast(ray, out hitInfo, Mathf.Infinity, ~layerMask))
				{
					Debug.Log(hitInfo.collider.name);
				}
			}
		

	}
	void OnFingerUp(Lean.LeanFinger finger)
	{

		Debug.Log(finger.StartedOverGui);
		if(finger.TotalDeltaScreenPosition.x < 5 && finger.TotalDeltaScreenPosition.x > -5)
		{
			
			if(UIController.Instance.ActiveMenu == null && !finger.StartedOverGui)
			{
				if (hitInfo.collider != null && hitInfo.collider.GetComponent<FloorTile> () != null) {
					// Store the selected tile
					selectedTile = hitInfo.collider.GetComponent<FloorTile> ();

					if (!selectedTile.HasTurretOverTile) {

						UIController.Instance.SetActive_TileMenu (true);

					} else {

						UIController.Instance.SetActive_TowerMenu (true);
					}

				}
			}
		}
	}


}
