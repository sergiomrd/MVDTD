using UnityEngine;
using System.Collections;

public class TurretBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		int myLayerMask = ~(1 << 10);
		//layerMask = ~layerMask

		RaycastHit[] hits;

		hits = Physics.RaycastAll(transform.position, transform.right);

		for(int i = 0; i < hits.Length; i++)
		{
			RaycastHit hit = hits[i];
			Debug.Log(hit.collider.gameObject.name);
		}
	
	}
}
