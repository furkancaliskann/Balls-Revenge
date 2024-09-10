using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int damageAmount;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if(collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().DecreaseHealth(damageAmount);
            Destroy(gameObject);
        }
    }
}
