using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float speedMovement;


	private Camera _camera;

	// Use this for initialization
	void Start () {

		_camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {

		Touch [] touches = Input.touches;

		if(touches.Length > 0)
		{
			if(touches.Length == 1)
			{
				if(touches[0].phase == TouchPhase.Moved)
				{
					Vector2 movement = Input.touches[0].deltaPosition * speedMovement * Time.deltaTime;
					transform.Translate(movement.x * -1 , 0,0);
					Vector3 pos = transform.position;
					pos.x = Mathf.Clamp(transform.position.x, 2, 6);
					transform.position = pos;
				}


			}
		}


	}
}
