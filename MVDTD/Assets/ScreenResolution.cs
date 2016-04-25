using UnityEngine;
using System.Collections;

public class ScreenResolution : MonoBehaviour {

	Camera cam;

	[SerializeField]
	private float PPU;

	// Use this for initialization
	void Start () {
	
		cam = Camera.main;
		cam.orthographicSize = (Screen.width / 2) / PPU;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
