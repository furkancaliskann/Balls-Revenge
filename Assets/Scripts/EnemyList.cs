using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour
{
    public List<EnemyItem> enemies = new List<EnemyItem>();

    void Awake()
    {
        CreateEnemy(EnemyName.TutorialEasyBig, 1, 2, 10, 1, new List<float> { 1.3f, 1.5f }, Color.green, 5);

        CreateEnemy(EnemyName.EasyBig, 1, 4, 10, 1, new List<float> { 1.3f, 1.5f }, Color.green, 5);
        CreateEnemy(EnemyName.MediumBig, 4, 7, 10, 2, new List<float> { 1f, 1.3f, 1.5f }, Color.yellow, 10);
        CreateEnemy(EnemyName.HardBig, 7, 10, 10, 3, new List<float> { 0.9f, 1.1f, 1.3f, 1.5f}, Color.red, 15);

        CreateEnemy(EnemyName.EasySmall, 1, 4, 10, 1, new List<float> { 1.1f, 1.3f }, Color.green, 10);
        CreateEnemy(EnemyName.MediumSmall, 4, 7, 10, 2, new List<float> { 0.9f, 1.1f, 1.3f }, Color.yellow, 20);
        CreateEnemy(EnemyName.HardSmall, 7, 10, 10, 3, new List<float> { 0.7f, 0.9f, 1.1f, 1.3f }, Color.red, 40);
    }

    void CreateEnemy(EnemyName name, int minHealth, int maxHealth, int jumpHeight, int spawnCount, List<float> size, Color color, int moneyBonus)
    {
        enemies.Add(new EnemyItem(name, minHealth, maxHealth, jumpHeight, spawnCount, size, color, moneyBonus));
    }

    public EnemyItem ReturnEnemy(EnemyName name)
    {
        EnemyItem result = enemies.Find(x => x.name == name);
        if (result == null) return null;
        else
        {
            EnemyItem a = new EnemyItem(result.name, result.minHealth, result.maxHealth, result.jumpHeight, result.spawnCount, result.size, result.color, result.moneyBonus);
            a.health = Random.Range(result.minHealth, result.maxHealth);

            return a;
        }
    }


}
