using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	[SerializeField]
	private bool blockCamera = false;

	public bool BlockCamera {
		get {
			return blockCamera;
		}
		set {
			blockCamera = value;
		}
	}

	[SerializeField]
	private float speedMovement;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		Touch [] touches = Input.touches;

		if(touches.Length > 0)
		{
			if(touches.Length == 1)
			{
				TouchPhase phase = touches[0].phase;

				switch(phase)
				{
				case TouchPhase.Moved:

					if(!blockCamera)
					{
						Vector2 movement = Input.touches[0].deltaPosition * speedMovement * Time.deltaTime;
						transform.Translate(movement.x * -1 , 0,0);
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
