using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [Header("Mouse Hover Color")]

    public Color HoverColor;

    [Header("Turret Position Offset")]

    public Vector3 PositionOffSet;

    private GameObject Turret;
    private Renderer rend;
    private Color StartColor;
    BuildManager buildManager;

    void Start() 
    {
        buildManager = BuildManager.Instance;
        rend = GetComponent<Renderer>(); //Optimization 
        StartColor = rend.material.color;
    }
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        if (Turret != null)
        {
            Debug.Log("Can't Place");
            return;
        }

        GameObject TurretToBuild = buildManager.GetTurretToBuild();
        Turret = (GameObject)Instantiate(TurretToBuild, transform.position + PositionOffSet, transform.rotation);
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        rend.material.color = HoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = StartColor;
    }
}
