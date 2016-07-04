using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManagerController : MonoBehaviour
{
    // Create an instance of GameManager
	public static GameManagerController Instance { get; private set;}
    
    // References the uiGameplay;
	UIGameplay uiGameplay;

    // Number of money of the player
	private int money;

    // Number of lives of the player
    private int lives;

    [SerializeField]
    private int startLives;

	[SerializeField]
	private int startMoney;

	public int Money {
		get {
			return money;
		}
		set {
			money = value;
			uiGameplay.UpdateMoney();
		}
	}

    public int Lives
    {
        get
        {
            return lives;
        }

        set
        {
            lives = value;
            uiGameplay.UpdateLives();
            if (lives == 0)
            {
                uiGameplay.ShowGameOverPanel(true);
            }
            
        }
    }


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
    }

    void Start()
	{
		uiGameplay = UIController.Instance.GetChildPanel(UIController.UItype.GameplayUI).GetComponent<UIGameplay>();
		Money = startMoney;
        Lives = startLives;
	}

    void InitGameConfig()
    {
        Money = startMoney;
        Lives = startLives;
    }

    //TODO - MAKE IT ALL INITS
    public void RestartGame()
    {
        
        GameManagerController.Instance.PauseGame(false);
        uiGameplay.ShowGameOverPanel(false);

        MapController.Instance.InitMap();
        InitGameConfig();
        EnemySpawnController.Instance.InitSpawn();
        //EnemySpawnController.Instance.InitSpawn();
        //UIController.Instance.SetActive_WaveMenu(true);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Money = startMoney;
        //Lives = startLives;
    }

    public void PauseGame(bool option)
    {
        if(option)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        
    }
}
