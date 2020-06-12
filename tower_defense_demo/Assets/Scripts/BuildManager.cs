using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Too many BuildManagers in the scene");
        }
        instance = this;

    }

    public GameObject standardTurretPrefab;
    public GameObject secondTurretPrefab;

    private void Start()
    {
        turretToBuild = null;
    }

    private GameObject turretToBuild;

    public GameObject getTurretToBuild()
    {
        return turretToBuild;
    }

    public void setTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
