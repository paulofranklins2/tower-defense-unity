using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager buildManager;
    private GameObject turretToBuild;
    public GameObject standardTurretPrefab;

    void Start()
    {
        turretToBuild = standardTurretPrefab;
    }
    void Awake()
    {
        if(buildManager != null)
        {
            Debug.Log("Problem");
            return;
        }
        buildManager = this;
    }
    public GameObject getTurretToBuild()
    {
        return turretToBuild;
    }
}
