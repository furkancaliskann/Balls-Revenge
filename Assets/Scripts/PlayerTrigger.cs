using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    GameManager manager;
    SpawnManager spawnManager;
    Money money;
    Gun gun;
    AudioManager audioManager;
    
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        spawnManager = manager.GetComponent<SpawnManager>();
        money = manager.GetComponent<Money>();
        gun = GetComponent<Gun>();
        audioManager = manager.GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bonus")
        {
            Bonus bonus = collision.GetComponent<Bonus>();           
            
            if(bonus.bonusGun == "Bomb")
            {
                spawnManager.ApplyExplosive();
                audioManager.PlayBombSound();
            }
            else if (bonus.bonusGun == "Money")
            {
                money.ChangeMoney(bonus.bonusMoney);
                audioManager.PlayMoneySound();
            }
            else
            {
                audioManager.PlayGetBonusSound();
                gun.ChangeGun(bonus.bonusGun);
            }

            Destroy(collision.gameObject);        
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            manager.Lose();
        }
    }
}
