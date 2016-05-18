using UnityEngine;
using System.Collections;

public class EyeBlink : MonoBehaviour {

	public Animator animator;

	public float timerMin;
	public float timerMax;

	private float currentTimer;

	// Use this for initialization
	void Start () {
	
		currentTimer = Random.Range(timerMin,timerMax);

	}
	
	// Update is called once per frame
	void Update () {
	
		currentTimer -= Time.deltaTime;

		if (currentTimer <= 0) 
		{
			animator.SetTrigger ("Blink");
			currentTimer = Random.Range(timerMin,timerMax);
		}

	}
}
