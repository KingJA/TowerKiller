using UnityEngine;
[System.Serializable]
public class TurretData {
    /*基础炮塔*/
    public GameObject turretPrefab;
    /*升级后炮塔*/
    public GameObject turretUpgradedPrefab;
    /*基础造价*/
    public int cost;
    /*升级造价*/
    public int costUpgraded;

    public enum TurretType {
        LaserTurret,
        MissileTurret,
        StandardTurret
    }

}
