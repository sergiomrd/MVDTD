using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UpgradeTurretData : MonoBehaviour {

    [SerializeField]
    private bool lastUpgrade;

    // Its a list if in the future we want branches of upgrades
    [SerializeField]
    private List<GameObject> turretUpgradeList;

    public bool LastUpgrade
    {
        get
        {
            return lastUpgrade;
        }
    }

    public List<GameObject> TurretUpgradeList
    {
        get
        {
            return turretUpgradeList;
        }

        set
        {
            turretUpgradeList = value;
        }
    }
}
