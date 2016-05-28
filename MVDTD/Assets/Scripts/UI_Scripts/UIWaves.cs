using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIWaves : MonoBehaviour {

	public InputField numberWaves;
	public InputField numberEnemies;

	private EventSystem eventSystem;
	private TouchScreenKeyboard keyboard;
	private EnemySpawnController spawnerController;

	// Use this for initialization
	void Start () {
	
		spawnerController = EnemySpawnController.Instance;
	}
	
	// Update is called once per frame
	void Update () {
	


	}

	public void Button_Begin()
	{
		if (numberWaves.text.Length > 0 && numberEnemies.text.Length > 0) 
		{
			spawnerController.NumberOfWaves = int.Parse(numberWaves.text);
			spawnerController.NumberOfEnemies = int.Parse (numberEnemies.text);

		}

		spawnerController.enabled = true;
		gameObject.SetActive (false);
	}

}
