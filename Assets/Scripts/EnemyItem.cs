using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyItem
{

    public EnemyName name;

    public int minHealth, maxHealth;
    public int health;

    public int jumpHeight;

    public int spawnCount;
    public List<float> size;

    public Color color;

    public int moneyBonus; // if the bonus comes


    public EnemyItem(EnemyName name, int minHealth, int maxHealth, int jumpHeight, int spawnCount, List<float> size, Color color, int moneyBonus)
    {
        this.name = name;
        this.minHealth = minHealth;
        this.maxHealth = maxHealth;
        this.jumpHeight = jumpHeight;
        this.spawnCount = spawnCount;
        this.size = size;
        this.color = color;
        this.moneyBonus = moneyBonus;
    }
}

public enum EnemyName
{
    TutorialEasyBig,

    EasyBig,
    MediumBig,
    HardBig,

    EasySmall,
    MediumSmall,
    HardSmall,
}
