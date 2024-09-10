using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunList : MonoBehaviour
{
    public List<GunItem> guns = new List<GunItem>();

    void Awake()
    {
        CreateGun("Pistol", 0.25f, 10f, 1, 0, 0, 1, 0, new int[] { 50, 80, 110, 140 }, null);
        CreateGun("SMG", 0.125f, 15f, 1, 75, 75, 1, 50, new int[] { 35, 75, 115, 155 }, new int[] { 30, 70, 110, 150 });
        CreateGun("Shotgun", 0.25f, 20f, 3, 45, 45, 1, 100, new int[] { 40, 80, 120, 160 }, new int[] { 35, 75, 115, 155 });
        CreateGun("Desert Eagle", 0.30f, 30f, 1, 40, 40, 3, 150, new int[] { 75, 115, 155, 195 }, new int[] { 65, 105, 145, 185 });
        CreateGun("Assault Rifle", 0.175f, 25f, 1, 80, 80, 2, 200, new int[] { 60, 95, 120, 155 }, new int[] { 55, 90, 115, 150 });
        CreateGun("Minigun", 0.075f, 20f, 1, 100, 100, 1, 400, new int[] { 100, 150, 250, 300 }, new int[] { 130, 240, 350, 460 });

        CreateGun("Bomb", 0, 0, 0, 0, 0, 0, 0, null, null);
        CreateGun("Money", 0, 0, 0, 0, 0, 0, 0, null, null);
    }

    void CreateGun(string name, float fireSpeed, float ammoSpeed, int shootAmount, int ammoAmount, int maxAmmoAmount, int damage,
        int unlockCost, int[] upgradeSpeedCosts, int[] upgradeAmmoCosts)
    {
        guns.Add(new GunItem(name, fireSpeed, ammoSpeed, shootAmount, ammoAmount, maxAmmoAmount, damage, unlockCost, upgradeSpeedCosts, upgradeAmmoCosts));
    }

    public GunItem CreateGunItem(string gunName)
    {
        GunItem result = guns.Find(x => x.gunName == gunName);
        if (result == null) return null;
        else return(new GunItem(result.gunName, result.fireSpeed, result.ammoSpeed, result.shootAmount, result.ammoAmount, result.maxAmmoAmount, result.damage,
            result.unlockCost, result.upgradeSpeedCosts, result.upgradeAmmoCosts));
    }

    
}
