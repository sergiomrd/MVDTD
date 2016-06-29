using UnityEngine;
using System.Collections;

public class GameManagerController : MonoBehaviour
{
	public static GameManagerController Instance { get; private set;}

	UIGameplay uiGameplay;

	private int money;

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
        }
    }

    void Start()
	{
		if (Instance != null && Instance != this) {
			Destroy (gameObject);
		} else {
			Instance = this;
		}

		uiGameplay = UIController.Instance.GetChildPanel(UIController.UItype.GameplayUI).GetComponent<UIGameplay>();
		Money = startMoney;
        Lives = startLives;
	}
}
