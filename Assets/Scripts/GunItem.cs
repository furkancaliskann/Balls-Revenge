
using UnityEngine;

public class GunItem
{
    public string gunName;
    public float fireSpeed;
    public float ammoSpeed;
    public int shootAmount;
    public int ammoAmount;
    public int maxAmmoAmount;

    public int damage;

    public int unlockCost;
    public int[] upgradeSpeedCosts;
    public int[] upgradeAmmoCosts;


    public GunItem(string gunName, float fireSpeed, float ammoSpeed, int shootAmount, int ammoAmount, int maxAmmoAmount, int damage,
        int unlockCost, int[] upgradeSpeedCosts, int[] upgradeAmmoCosts)
    {
        this.gunName = gunName;
        this.fireSpeed = fireSpeed;
        this.ammoSpeed = ammoSpeed;
        this.shootAmount = shootAmount;
        this.ammoAmount = ammoAmount;
        this.maxAmmoAmount = maxAmmoAmount;
        this.damage = damage;
        this.unlockCost = unlockCost;
        this.upgradeSpeedCosts = upgradeSpeedCosts;
        this.upgradeAmmoCosts = upgradeAmmoCosts;
    }
}
