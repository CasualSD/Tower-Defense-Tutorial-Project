using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.Instance;
    }
    public void PurchaseTurret10()
    {
        Debug.Log("Turret 10 Selected");
        buildManager.SetTurretToBuild(buildManager.Turret10Prefab);
    }
    public void PurchaseTurret20()
    {
        Debug.Log("Turret 20 Selected");
        buildManager.SetTurretToBuild(buildManager.Turret20Prefab);
    }
}
