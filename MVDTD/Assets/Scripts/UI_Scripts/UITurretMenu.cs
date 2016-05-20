using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UITurretMenu : MonoBehaviour
{
    FloorTile selectedTile;
    List<GameObject> turretUpgradesList;
    UpgradeTurretData upgradeData;

    void OnEnable()
    {
        selectedTile = TouchLeanController.Instance.SelectedTile;
        upgradeData = selectedTile.TurretInstance.GetComponent<UpgradeTurretData>();

    }

	void Start ()
	{
        
    }
	

    public void UpgradeTurret()
    {
        
        UIController.Instance.SetActive_TowerMenu(false);
        

        if(canUpgrade(upgradeData.TurretUpgradeList[0]) && !upgradeData.LastUpgrade)
        {
            Destroy(selectedTile.TurretInstance.gameObject);
            selectedTile.SetTurretOnTile(upgradeData.TurretUpgradeList[0]);
        }


    }

	public void SellTurret ()
	{
		
		UIController.Instance.SetActive_TowerMenu (false);
		selectedTile.HasTurretOverTile = false;
		GameManagerController.Instance.Money += selectedTile.TurretInstance.GetComponent<TurretController>().SellCost;
		Destroy (selectedTile.TurretInstance.gameObject);
	
	}
    
    public bool canUpgrade(GameObject turretToUpgrade)
    {
        int currentMoney = GameManagerController.Instance.Money;
        int moneyCost = turretToUpgrade.GetComponent<TurretController>().MoneyCost;

        if (currentMoney >= moneyCost)
        {
            GameManagerController.Instance.Money -= moneyCost;
            return true;
        }

        return false;
    }
}
