using UnityEngine;
using System.Collections;

public class UITurretMenu : MonoBehaviour
{

    FloorTile selectedTile;
	
	void Start ()
	{
	
	}
	

    public void UpgradeTurret()
    {
        selectedTile = TouchLeanController.Instance.SelectedTile;
        UIController.Instance.SetActive_TowerMenu(false);

    }

	public void SellTurret ()
	{
		
		selectedTile = TouchLeanController.Instance.SelectedTile;
		UIController.Instance.SetActive_TowerMenu (false);
		selectedTile.HasTurretOverTile = false;
		GameManagerController.Instance.Money += selectedTile.TurretInstance.GetComponent<TurretController>().SellCost;
		Destroy (selectedTile.TurretInstance.gameObject);
	
	}
}
