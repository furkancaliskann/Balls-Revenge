using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    SpawnManager spawnManager;

    Rigidbody2D rb;
    public Text healthText;

    public EnemyItem enemyItem;


    void Awake()
    {
        spawnManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<SpawnManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        EditText();
    }

    void Update()
    {
        if (enemyItem.health <= 0)
        {
            if(enemyItem.spawnCount > 0)
            {
                spawnManager.SpawnEnemy(enemyItem.name, transform.position, enemyItem.spawnCount - 1);
            }
            
            spawnManager.DestroyEnemy(gameObject);
        }


        if (rb.velocity.magnitude > enemyItem.jumpHeight) { rb.velocity = rb.velocity.normalized * enemyItem.jumpHeight; }
    }

    public void DecreaseHealth(int amount)
    {
        enemyItem.health -= amount;
        EditText();
    }

    private void EditText()
    {
        if (enemyItem.health < 0) enemyItem.health = 0;
        healthText.text = enemyItem.health.ToString();
    }

    public void StartRandomForce()
    {
        int x = Random.Range(-1, 2);

        rb.AddForce(new Vector2(x * 100, 0));
    }
}
