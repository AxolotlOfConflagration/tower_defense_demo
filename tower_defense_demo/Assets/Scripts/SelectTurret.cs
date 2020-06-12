using UnityEngine;

public class SelectTurret : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectTurret1()
    {
        buildManager.setTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void SelectTurret2()
    {
        buildManager.setTurretToBuild(buildManager.secondTurretPrefab);
    }
}
