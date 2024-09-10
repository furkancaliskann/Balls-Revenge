using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    Money money;
    GunList gunList;
    AudioManager audioManager;
    Settings settings;
    LevelManager levelManager;

    public GameObject weaponMarketSlotPrefab;
    public Transform weaponPanel;

    public List<GameObject> weaponMarketSlots = new List<GameObject>();
    public int pageNo = 0;

    void Awake()
    {
        money = GetComponent<Money>();
        gunList = GetComponent<GunList>();
        audioManager = GetComponent<AudioManager>();
        settings = GetComponent<Settings>();
        levelManager = GetComponent<LevelManager>();
    }

    void Start()
    {
        CreateWeaponPanels();
    }

    public void DeletePrefs()
    {
        PlayerPrefs.DeleteAll();
        money.ResetMoney();

        settings.GetSoundLevel();
        settings.GetFpsSetting();

        levelManager.GetCurrentChapter();

        for (int i = 0; i < weaponMarketSlots.Count; i++)
        {
            weaponMarketSlots[i].GetComponent<WeaponMarketSlot>().RefreshAfterDeletingPrefs();
        }
    }
    public void GiveMoney()
    {
        money.ChangeMoney(1000);
    }

    void CreateWeaponPanels()
    {
        for (int i = 0; i < gunList.guns.Count; i++)
        {
            if (gunList.guns[i].gunName != "Bomb" && gunList.guns[i].gunName != "Money")
            {
                GameObject a = Instantiate(weaponMarketSlotPrefab, weaponPanel);
                a.GetComponent<WeaponMarketSlot>().RefreshAll(money, gunList, audioManager, gunList.guns[i].gunName);
                weaponMarketSlots.Add(a);
            }
        }

        OpenPage(pageNo);
    }

    void OpenPage(int pageNo)
    {
        CloseAllSlots();

        switch(pageNo)
        {
            case 0: if (weaponMarketSlots.Count < 2) return; weaponMarketSlots[0].SetActive(true); weaponMarketSlots[1].SetActive(true); break;
            case 1: if (weaponMarketSlots.Count < 4) return; weaponMarketSlots[2].SetActive(true); weaponMarketSlots[3].SetActive(true); break;
            case 2: if (weaponMarketSlots.Count < 6) return; weaponMarketSlots[4].SetActive(true); weaponMarketSlots[5].SetActive(true); break;
        }
    }

    void CloseAllSlots()
    {
        for (int i = 0; i < weaponMarketSlots.Count; i++)
        {
            weaponMarketSlots[i].SetActive(false);
        }
    }

    public void OpenNextPage()
    {
        if (pageNo >= 2) return;
        else pageNo++;

        OpenPage(pageNo);
    }

    public void OpenPreviousPage()
    {
        if (pageNo <= 0) return;
        else pageNo--;

        OpenPage(pageNo);
    }
}
