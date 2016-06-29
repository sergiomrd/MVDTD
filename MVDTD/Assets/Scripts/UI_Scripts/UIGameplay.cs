using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIGameplay : MonoBehaviour {

	public Text moneyText;
    public Text livesText;
    public GameObject gameOverPanel;

	void Awake()
	{
        gameOverPanel.SetActive(false);
    }


	public void UpdateMoney()
	{
		moneyText.text = "Money: " + GameManagerController.Instance.Money.ToString() + " $";
	}

    public void UpdateLives()
    {
        livesText.text = "Lives: " + GameManagerController.Instance.Lives.ToString();
    }

    public void ShowGameOverPanel(bool option)
    {
        if(option)
        {
            gameOverPanel.SetActive(true);
            GameManagerController.Instance.PauseGame(true);
        }
        else
        {
            gameOverPanel.SetActive(false);
        }
        
    }
}
