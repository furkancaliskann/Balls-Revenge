using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    AudioManager audioManager;
    Pause pause;

    public GunList gunList;
    public GunItem myGun;

    public GameObject ammoPrefab;
    public AndroidButton shootButton;

    public Image weaponImage;
    public Text weaponNameText;

    public Image weaponAmmoBar;

    bool ready = true;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<AudioManager>();
        gunList = audioManager.GetComponent<GunList>();
        pause = audioManager.GetComponent<Pause>();

        ChangeGun("Pistol");
    }

    void Update()
    {
        if (pause.gamePaused) return;

        if (Input.GetKey(KeyCode.Space) || shootButton.pointerDown) Fire();
    }

    public void ChangeGun(string gunName)
    {
        myGun = gunList.CreateGunItem(gunName);

        myGun.fireSpeed -= myGun.fireSpeed / 100 * (PlayerPrefs.GetInt(myGun.gunName + " Speed Level", 0) * 5);
        myGun.ammoAmount += myGun.ammoAmount / 100 * (PlayerPrefs.GetInt(myGun.gunName + " Ammo Level", 0) * 10);
        myGun.maxAmmoAmount = myGun.ammoAmount;

        EditWeaponPanel(gunName);
    }

    void EditWeaponPanel(string gunName)
    {
        weaponImage.sprite = Resources.Load<Sprite>(gunName);
        weaponNameText.text = gunName;
        UpdateAmmoBar();
    }

    public void Fire()
    {
        if (!ready || myGun == null) return;

        audioManager.PlayGunSound(myGun);
        ready = false;

        if(myGun.shootAmount == 1)
        {
            GameObject ammo = Instantiate(ammoPrefab, transform.position + new Vector3(0, 0.75f, 0), Quaternion.identity);
            ammo.GetComponent<Rigidbody2D>().velocity = new Vector3(0, myGun.ammoSpeed, 0);

            ammo.GetComponent<Ammo>().damageAmount = myGun.damage;
        }
        else
        {
            GameObject ammo = Instantiate(ammoPrefab, transform.position + new Vector3(0, 0.75f, 0), Quaternion.Euler(0,0,-15));
            ammo.GetComponent<Rigidbody2D>().velocity = ammo.transform.up * myGun.ammoSpeed;
            ammo.GetComponent<Ammo>().damageAmount = myGun.damage;
            GameObject ammo3 = Instantiate(ammoPrefab, transform.position + new Vector3(0, 0.75f, 0), Quaternion.identity);
            ammo3.GetComponent<Rigidbody2D>().velocity = ammo3.transform.up * myGun.ammoSpeed;
            ammo3.GetComponent<Ammo>().damageAmount = myGun.damage;
            GameObject ammo2 = Instantiate(ammoPrefab, transform.position + new Vector3(0, 0.75f, 0), Quaternion.Euler(0, 0, 15));
            ammo2.GetComponent<Rigidbody2D>().velocity = ammo2.transform.up * myGun.ammoSpeed;
            ammo2.GetComponent<Ammo>().damageAmount = myGun.damage;
        }

        myGun.ammoAmount--;

        if (myGun.ammoAmount <= 0 && myGun.gunName != "Pistol") ChangeGun("Pistol");

        UpdateAmmoBar();

        Invoke(nameof(ReadyToShoot), myGun.fireSpeed);
    }

    void ReadyToShoot()
    {
        ready = true;
    }

    void UpdateAmmoBar()
    {
        if (myGun.gunName == "Pistol")
        {
            weaponAmmoBar.enabled = false;
            weaponAmmoBar.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            if(!weaponAmmoBar.enabled)
            {
                weaponAmmoBar.enabled = true;
            }

            weaponAmmoBar.transform.localScale = new Vector3(myGun.ammoAmount / (float)myGun.maxAmmoAmount, 1, 1);
        }
            
    }
}
