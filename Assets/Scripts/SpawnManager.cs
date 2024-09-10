using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    GameManager manager;
    public ChapterItem chapter;
    EnemyList enemyList;
    AnimationManager animationManager;
    AudioManager audioManager;
    GunList gunList;
    Pause pause;

    public GameObject player;
    public GameObject enemyPrefab;
    public GameObject bonusPrefab;

    public List<GameObject> enemies;
    public bool enemiesSpawnedForThisWave;

    public List<Vector2> designatedLocations;
    public GameObject enemyWarningImage;

    public List<string> unlockedWeaponsList;


    void Awake()
    {
        manager = GetComponent<GameManager>();
        enemyList = GetComponent<EnemyList>();
        animationManager = GetComponent<AnimationManager>();
        audioManager = GetComponent<AudioManager>();
        gunList = GetComponent<GunList>();
        pause = GetComponent<Pause>();
    }

    void Start()
    {
        enemiesSpawnedForThisWave = false;

        player.transform.position = chapter.playerPosition;

        GetUnlockedWeaponsList();
    }

    void GetUnlockedWeaponsList()
    {
        for (int i = 1; i < 6; i++)
        {
            if (PlayerPrefs.GetInt(gunList.guns[i].gunName + " IsUnlocked", 0) == 1)
            {
                unlockedWeaponsList.Add(gunList.guns[i].gunName);
            }
        }
    }

    void DesignLocations(int amount)
    {
        if(chapter.spawnLocationsX.Count >= amount)
        {
            for (int i = 0; i < amount; i++)
            {
                designatedLocations.Add(new Vector2(chapter.spawnLocationsX[0], 12));

                Instantiate(enemyWarningImage, new Vector2(chapter.spawnLocationsX[0], 5), Quaternion.identity);

                chapter.spawnLocationsX.RemoveAt(0);

                Invoke(nameof(SpawnEnemy), 3f);
            }
        }
        else
        {
            for (int i = 0; i < amount; i++)
            {
                float x = Random.Range(-6.0f, 6.01f);
                float y = 12;

                designatedLocations.Add(new Vector2(x, y));

                Instantiate(enemyWarningImage, new Vector2(x, 5), Quaternion.identity);

                Invoke(nameof(SpawnEnemy), 3f);
            }
        }


       

        audioManager.PlayDangerSound();
    }

    void SpawnEnemy()
    {
        if (chapter.enemiesToSpawn.Count <= 0) return;

        EnemyItem enemyItem = enemyList.ReturnEnemy(chapter.enemiesToSpawn[0]);

        GameObject enemy = Instantiate(enemyPrefab, designatedLocations[0], Quaternion.identity);

        enemy.transform.localScale = new Vector3(enemyItem.size[enemyItem.spawnCount], enemyItem.size[enemyItem.spawnCount], enemyItem.size[enemyItem.spawnCount]);

        enemy.GetComponent<SpriteRenderer>().color = enemyItem.color;

        Enemy enemyCode = enemy.GetComponent<Enemy>();
        enemyCode.enemyItem = enemyItem;

        if (chapter.enemiesForce.Count > 0)
        {
            enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(chapter.enemiesForce[0], 0));
            chapter.enemiesForce.RemoveAt(0);
        }
        else
            enemyCode.StartRandomForce();


        enemies.Add(enemy);
        enemiesSpawnedForThisWave = true;

        chapter.enemiesToSpawn.RemoveAt(0);
        designatedLocations.RemoveAt(0);
    }

    public void SpawnEnemy(EnemyName name, Vector2 pos, int spawnCount)
    {
        EnemyItem enemyItem = enemyList.ReturnEnemy(name);
        EnemyItem enemyItem2 = enemyList.ReturnEnemy(name);

        enemyItem.spawnCount = spawnCount;
        enemyItem2.spawnCount = spawnCount;

        GameObject enemy = Instantiate(enemyPrefab, pos, Quaternion.identity);
        GameObject enemy2 = Instantiate(enemyPrefab, pos, Quaternion.identity);

        enemy.transform.localScale = new Vector3(enemyItem.size[spawnCount], enemyItem.size[spawnCount], enemyItem.size[spawnCount]);
        enemy2.transform.localScale = new Vector3(enemyItem2.size[spawnCount], enemyItem2.size[spawnCount], enemyItem2.size[spawnCount]);

        enemy.GetComponent<SpriteRenderer>().color = enemyItem.color;
        enemy2.GetComponent<SpriteRenderer>().color = enemyItem2.color;

        Enemy enemyCode = enemy.GetComponent<Enemy>();
        Enemy enemyCode2 = enemy2.GetComponent<Enemy>();

        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = enemy2.GetComponent<Rigidbody2D>();

        enemyCode.enemyItem = enemyItem;
        enemyCode2.enemyItem = enemyItem2;

        rb.AddForce(new Vector2(-100, 300));
        rb2.AddForce(new Vector2(100, 300));

        enemies.Add(enemy);
        enemies.Add(enemy2);

    }

    public void DestroyEnemy(GameObject enemy)
    {
        int spawnChange = Random.Range(0, 101);

        enemies.Remove(enemy);

        if (spawnChange >= 60)
            SpawnBonus(enemy.transform.position, enemy.GetComponent<Enemy>().enemyItem.moneyBonus);
        Destroy(enemy);

        audioManager.PlayBalloonPopSound();
    }

    public void SpawnBonus(Vector2 pos, int bonusMoney)
    {
        List<string> newList = new List<string>();

        int moneyBombOrGuns = Random.Range(0, 101);

        if(unlockedWeaponsList.Count == 0)
        {
            if (moneyBombOrGuns < 80) newList.Add("Money");
            else if (moneyBombOrGuns >= 80) newList.Add("Bomb");
        }
        else
        {
            if (moneyBombOrGuns < 50) newList.Add("Money");
            else if (moneyBombOrGuns >= 50 && moneyBombOrGuns < 65) newList.Add("Bomb");
            else if (moneyBombOrGuns >= 65) newList.AddRange(unlockedWeaponsList);
        }
        
        

        int number = Random.Range(0, newList.Count);

        GameObject bonusObject = Instantiate(bonusPrefab, pos, Quaternion.identity);

        SpriteRenderer renderer = bonusObject.GetComponent<SpriteRenderer>();
        renderer.sprite = Resources.Load<Sprite>(newList[number]);
        renderer.size = new Vector2(0.75f, 0.75f);

        Bonus bonusCode = bonusObject.GetComponent<Bonus>();

        bonusCode.bonusGun = newList[number];
        bonusCode.bonusMoney = bonusMoney;
        bonusCode.pause = pause;
        bonusObject.SetActive(true);
    }

    public void StartSpawnAnim()
    {
        if (chapter.enemiesToSpawn.Count == 0 || manager.lose) return;

        animationManager.RaiseWallInvoke();
        Invoke(nameof(StartEnemyLocations), 3.4f);
    }
    public void StartEnemyLocations()
    {
        if (manager.lose) return;

        DesignLocations(chapter.numberOfEnemiesToSpawnThisWave[0]);
        chapter.numberOfEnemiesToSpawnThisWave.RemoveAt(0);

        Invoke(nameof(StopSpawnEnemy), 5f);
    }
    public void StopSpawnEnemy()
    {
        if (manager.lose) return;
        animationManager.LowerWall();
    }

    public void ApplyExplosive()
    {
        animationManager.PlayCameraAnimation();

        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].GetComponent<Enemy>().DecreaseHealth(100);
        }
    }

    
}
