using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIWaves : MonoBehaviour {

	public InputField numberWaves;
	public InputField numberEnemies;
    public Text enemiesNumberText;
    public Text wavesNumberText;

    private int enemiesNumber = 1;
    private int wavesNumber = 1;

	private EventSystem eventSystem;
	private TouchScreenKeyboard keyboard;
	private EnemySpawnController spawnerController;

	// Use this for initialization
	void Start () {
	
		spawnerController = EnemySpawnController.Instance;
        enemiesNumberText.text = enemiesNumber.ToString();
        wavesNumberText.text = wavesNumber.ToString();
	}


    public void EnemiesPlus()
    {
        if(enemiesNumber < 99)
        {
            enemiesNumber++;
            enemiesNumberText.text = enemiesNumber.ToString();
        }
        
    }

    public void EnemiesMinus()
    {
        if(enemiesNumber > 0)
        {
            enemiesNumber--;
            enemiesNumberText.text = enemiesNumber.ToString();
        }
       
    }

    public void WavesPlus()
    {
        if(wavesNumber < 99)
        {
            wavesNumber++;
            wavesNumberText.text = wavesNumber.ToString();
        }
        
    }

    public void WavesMinus()
    {
        if(wavesNumber > 0)
        {
            wavesNumber--;
            wavesNumberText.text = wavesNumber.ToString();
        }
        
    }

	public void Button_Begin()
	{
        /*
		if (numberWaves.text.Length > 0 && numberEnemies.text.Length > 0) 
		{
			spawnerController.NumberOfWaves = int.Parse(numberWaves.text);
			spawnerController.NumberOfEnemies = int.Parse (numberEnemies.text);

		}
        */

        spawnerController.NumberOfWaves = wavesNumber;
        spawnerController.NumberOfEnemies = enemiesNumber;

		spawnerController.enabled = true;
		gameObject.SetActive (false);
       
	}

}
