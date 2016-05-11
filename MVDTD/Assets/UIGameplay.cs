using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIGameplay : MonoBehaviour {

	private Text moneyText;
	void Awake()
	{
		moneyText = gameObject.transform.GetComponentInChildren<Text>();
	}


	public void UpdateMoney()
	{
		moneyText.text = "Money: " + GameManagerController.Instance.Money.ToString() + " $";
	}
}
