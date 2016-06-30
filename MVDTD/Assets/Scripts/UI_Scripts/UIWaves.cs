using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIWaves : MonoBehaviour {

    public Text enemiesNumberText;
    public Text wavesNumberText;
    public Text mapHeightText;
    public Text mapWidthText;


    private int enemiesNumber = 1;
    private int wavesNumber = 1;
    private int mapHeight = 1;
    private int mapWidth = 1;

	private EventSystem eventSystem;
	private TouchScreenKeyboard keyboard;
	private EnemySpawnController spawnerController;
    private MapController mapController;

	// Use this for initialization
	void Start () {

        mapController = MapController.Instance;
		spawnerController = EnemySpawnController.Instance;
        enemiesNumberText.text = enemiesNumber.ToString();
        wavesNumberText.text = wavesNumber.ToString();
        mapHeightText.text = mapHeight.ToString();
        mapWidthText.text = mapWidth.ToString();
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

    public void mapHeightPlus()
    {
        if(mapHeight < 5)
        {
            mapHeight++;
            mapHeightText.text = mapHeight.ToString();
        }
    }

    public void mapHeightMinus()
    {
        if (mapHeight > 0)
        {
            mapHeight--;
            mapHeightText.text = mapHeight.ToString();
        }
    }

    public void mapWidthPlus()
    {
        if (mapWidth < 10)
        {
            mapWidth++;
            mapWidthText.text = mapWidth.ToString();
        }
    }

    public void mapWidthMinus()
    {
        if (mapWidth > 0)
        {
            mapWidth--;
            mapWidthText.text = mapWidth.ToString();
        }
    }

    public void Button_Begin()
	{
        mapController.MapHeight = mapHeight;
        mapController.MapWidth = mapWidth;

        spawnerController.NumberOfWaves = wavesNumber;
        spawnerController.NumberOfEnemies = enemiesNumber;

        mapController.InitMap();

		spawnerController.enabled = true;
		gameObject.SetActive (false);
       
	}

}
