using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;
    private GameObject TurretToBuild;
    public GameObject Turret10Prefab;
    public GameObject Turret20Prefab;
    public GameObject Turret30;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("More than 1 Build Manager Instance.");
            return;
        }
        Instance = this; //Instance in this cass is my build manager
    }

    public GameObject GetTurretToBuild()
    {
        return TurretToBuild;
    }

    public void SetTurretToBuild(GameObject Turret)
    {
        TurretToBuild = Turret;
    }
}
