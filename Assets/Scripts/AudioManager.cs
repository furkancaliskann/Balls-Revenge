using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip pistolSound, smgSound, minigunSound, shotgunSound, desertEagleSound, assaultRifleSound;
    public AudioClip bombSound;
    public AudioClip moneySound;
    public AudioClip newWaveSound;
    public AudioClip dangerSound;
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip balloonPopSound;
    public AudioClip clickSound;
    public AudioClip getBonusSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayGunSound(GunItem gun)
    {
        switch (gun.gunName)
        {
            case "Pistol": audioSource.PlayOneShot(pistolSound); break;
            case "SMG": audioSource.PlayOneShot(smgSound); break;
            case "Minigun": audioSource.PlayOneShot(minigunSound); break;
            case "Shotgun": audioSource.PlayOneShot(shotgunSound); break;
            case "Desert Eagle": audioSource.PlayOneShot(desertEagleSound); break;
            case "Assault Rifle": audioSource.PlayOneShot(assaultRifleSound); break;
        }
    }

    public void PlayBombSound()
    {
        audioSource.PlayOneShot(bombSound);
    }

    public void PlayMoneySound()
    {
        audioSource.PlayOneShot(moneySound);
    }

    public void PlayNewWaveSound()
    {
        audioSource.PlayOneShot(newWaveSound);
    }

    public void PlayDangerSound()
    {
        audioSource.PlayOneShot(dangerSound);
    }

    public void PlayWinSound()
    {
        audioSource.PlayOneShot(winSound);
    }

    public void PlayLoseSound()
    {
        audioSource.PlayOneShot(loseSound);
    }

    public void PlayBalloonPopSound()
    {
        audioSource.PlayOneShot(balloonPopSound);
    }

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSound);
    }

    public void PlayGetBonusSound()
    {
        audioSource.PlayOneShot(getBonusSound);
    }
}
