using UnityEngine;
using System.Collections;

public class TurretBehavior : MonoBehaviour {

	public LayerMask myLayerMask;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
			
		/*
		RaycastHit[] hits;

		hits = Physics.RaycastAll(transform.position, transform.right, myLayerMask);
		Debug.Log(hits.Length);
		Debug.DrawRay(transform.position, transform.right);
		Debug.Log(hits[0].collider.gameObject.name);

		for(int i = 0; i < hits.Length; i++)
		{
			//RaycastHit hit = hits[i];
			//Debug.Log(hit.collider.gameObject.name);
		}
		*/
		//RaycastHit hit;

		/*
		if(Physics.Raycast(transform.position, transform.right, out hit, 100, ~myLayerMask))
		{
			Debug.Log(hit.transform.name);
		}
		*/
		RaycastHit [] hits = Physics.RaycastAll(transform.localPosition, transform.right, 100, ~myLayerMask);

		for(int i = 0; i < hits.Length; i++)
		{
			RaycastHit hit = hits[i];
			Debug.Log(hit.transform.name);
		}
	
	}
}
