using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponMarketSlot : MonoBehaviour
{
    Money money;
    GunList gunList;
    GunItem gunItem;
    AudioManager audioManager;

    public string gunName;
    public Text gunNameText;

    public bool isUnlocked;
    public GameObject lockedPanel;
    public Text unlockCost;
    public Button unlockButton;

    Sprite weaponSprite;
    public Image[] allWeaponImages;

    public GameObject ammoTable;

    int speedLevel;
    public Text upgradeSpeedCostText;
    public Image[] speedLevelBars;

    int ammoLevel;
    public Text upgradeAmmoCostText;
    public Image[] ammoLevelBars;

    public void RefreshAll(Money money, GunList gunList, AudioManager audioManager, string gunName)
    {
        this.money = money;
        this.gunList = gunList;
        this.gunName = gunName;
        this.audioManager = audioManager;

        gunItem = gunList.CreateGunItem(gunName);

        ChangeAllWeaponImages();
        ChangeWeaponNameText();
        ClosePistolAmmoTable();
        CheckLocked();
        CheckUpgradeSpeedLevel();
        CheckUpgradeAmmoLevel();
    }

    public void RefreshAfterDeletingPrefs()
    {
        for (int i = 0; i < speedLevelBars.Length; i++)
        {
            speedLevelBars[i].color = ReturnRedColor();
        }

        for (int i = 0; i < ammoLevelBars.Length; i++)
        {
            ammoLevelBars[i].color = ReturnRedColor();
        }

        ChangeAllWeaponImages();
        ChangeWeaponNameText();
        ClosePistolAmmoTable();
        CheckLocked();
        CheckUpgradeSpeedLevel();
        CheckUpgradeAmmoLevel();
    }

    void ChangeAllWeaponImages()
    {
        weaponSprite = Resources.Load<Sprite>(gunName);

        for (int i = 0; i < allWeaponImages.Length; i++)
        {
            allWeaponImages[i].sprite = weaponSprite;
        }
    }

    void ChangeWeaponNameText()
    {
        gunNameText.text = gunName.ToString();
    }

    void ClosePistolAmmoTable()
    {
        if(gunName == "Pistol") ammoTable.SetActive(false);
    }

    void CheckLocked()
    {
        int no;

        if (gunName != "Pistol")
        {
            no = PlayerPrefs.GetInt(gunName + " IsUnlocked", 0);
        }
        else no = 1;

        if (no == 0)
        {
            isUnlocked = false;
            lockedPanel.SetActive(true);
            unlockButton.interactable = true;
            unlockCost.text = gunItem.unlockCost.ToString();
        }
        else if (no == 1)
        {
            isUnlocked = true;
            lockedPanel.SetActive(false);
            unlockButton.interactable = true;
        }
    }

    void CheckUpgradeSpeedLevel()
    {
        speedLevel = PlayerPrefs.GetInt(gunName + " Speed Level", 0);

        if (speedLevel < 4)
            upgradeSpeedCostText.text = gunItem.upgradeSpeedCosts[speedLevel].ToString();
        else
            upgradeSpeedCostText.text = "---";

        for (int i = 0; i < speedLevel; i++)
        {
            speedLevelBars[i].color = ReturnGreenColor();
        }

    }

    void CheckUpgradeAmmoLevel()
    {
        if (gunName == "Pistol") return;

        ammoLevel = PlayerPrefs.GetInt(gunName + " Ammo Level", 0);

        if (ammoLevel < 4)
            upgradeAmmoCostText.text = gunItem.upgradeAmmoCosts[ammoLevel].ToString();
        else
            upgradeAmmoCostText.text = "---";

        for (int i = 0; i < ammoLevel; i++)
        {
            ammoLevelBars[i].color = ReturnGreenColor();
        }
    }

    public void UnlockWeapon()
    {
        if (gunName == "Pistol" || isUnlocked || money.money < gunItem.unlockCost) return;

        money.ChangeMoney(-gunItem.unlockCost);

        PlayerPrefs.SetInt(gunName + " IsUnlocked", 1);

        audioManager.PlayMoneySound();

        CheckLocked();
    }

    public void UpdateSpeedLevel()
    {
        if (speedLevel >= 4 || money.money < gunItem.upgradeSpeedCosts[speedLevel]) return;

        money.ChangeMoney(-gunItem.upgradeSpeedCosts[speedLevel]);

        speedLevel++;

        PlayerPrefs.SetInt(gunName + " Speed Level", speedLevel);

        audioManager.PlayMoneySound();

        CheckUpgradeSpeedLevel();

    }

    public void UpdateAmmoLevel()
    {
        if (ammoLevel >= 4 || money.money < gunItem.upgradeAmmoCosts[ammoLevel]) return;

        money.ChangeMoney(-gunItem.upgradeAmmoCosts[ammoLevel]);

        ammoLevel++;

        PlayerPrefs.SetInt(gunName + " Ammo Level", ammoLevel);

        audioManager.PlayMoneySound();

        CheckUpgradeAmmoLevel();

    }

    Color ReturnGreenColor()
    {
        return new Color(40 / 255f, 220 / 255f, 40 / 255f, 255 / 255f);
    }

    Color ReturnRedColor()
    {
        return new Color(220 / 255f, 40 / 255f, 40 / 255f, 255 / 255f);
    }
}
