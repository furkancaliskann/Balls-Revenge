using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterList : MonoBehaviour
{
    public List<ChapterItem> chapters = new List<ChapterItem>();


    void Awake()
    {
        CreateChapter("Chapter 1", new Vector3(-4,0,0), 3, 3, new List<int> { 20, 20}, new List<int> { 1, 1, 2}, 
            new List<EnemyName> { EnemyName.TutorialEasyBig, EnemyName.TutorialEasyBig, EnemyName.TutorialEasyBig, EnemyName.TutorialEasyBig },
            new List<float> { 0, 0, 0, 0 },
            new List<float> { 0, 0, -4, 4 },
            Maps.Empty);

        CreateChapter("Chapter 2", new Vector3(-4, 0, 0), 3, 4, new List<int> { 20, 20, 20 }, new List<int> { 1, 1, 2, 2 },
            new List<EnemyName> { EnemyName.TutorialEasyBig, EnemyName.TutorialEasyBig, EnemyName.TutorialEasyBig, EnemyName.TutorialEasyBig,
                EnemyName.TutorialEasyBig, EnemyName.TutorialEasyBig },
            new List<float> { 100, -100, -100, 100, -150, 150 },
            new List<float> { 0, 0, -4, 4, -3, 3 },
            Maps.Empty);

        CreateChapter("Chapter 3", new Vector3(0, 0, 0), 3, 3, new List<int> { 20, 20 }, new List<int> { 1, 2, 1 },
            new List<EnemyName> { EnemyName.EasyBig, EnemyName.EasyBig, EnemyName.EasyBig, EnemyName.MediumBig },
            new List<float> {},
            new List<float> {},
            Maps.Empty);

        CreateChapter("Chapter 4", new Vector3(0, 0, 0), 3, 4, new List<int> { 25, 40, 50 }, new List<int> { 2, 2, 2, 2 },
            new List<EnemyName> { EnemyName.EasyBig, EnemyName.EasyBig, EnemyName.EasyBig, EnemyName.MediumBig, EnemyName.EasyBig, EnemyName.MediumBig,
                EnemyName.MediumBig, EnemyName.MediumBig },
            new List<float> { 0, 0, 100, -100, 150, -150, Random.Range(-150, 150), Random.Range(-150, 150) },
            new List<float> { -2, 2, -4, 4, -4, 4, Random.Range(-6, 7), Random.Range(-6, 7) },
            Maps.Empty);

        CreateChapter("Chapter 5", new Vector3(-4, 0, 0), 3, 4, new List<int> { 20, 30, 30 }, new List<int> { 1, 1, 2, 1 },
            new List<EnemyName> { EnemyName.EasyBig, EnemyName.EasyBig,  EnemyName.EasyBig, EnemyName.EasyBig, EnemyName.MediumBig},
            new List<float> { -100, 100, -100, 100, -100 },
            new List<float> { -4, 4, -4, -4, 4 },
            Maps.SingleWall);

        CreateChapter("Chapter 6", new Vector3(-4, 0, 0), 3, 5, new List<int> { 20, 30, 40, 40 }, new List<int> { 1, 1, 2, 2, 2 },
            new List<EnemyName> { EnemyName.EasyBig, EnemyName.EasyBig, EnemyName.EasyBig, EnemyName.EasyBig, EnemyName.MediumBig, EnemyName.EasyBig,
                EnemyName.MediumBig, EnemyName.MediumBig },
            new List<float> { 100, -100, 100, -100, -100, 100, -100, 100 },
            new List<float> { -4, 4, -4, 4, -4, 4, -3, 3 },
            Maps.SingleWall);

        CreateChapter("Chapter 7", new Vector3(0, 0, 0), 3, 5, new List<int> { 20, 30, 30, 30 }, new List<int> { 1, 1, 2, 2, 2 },
            new List<EnemyName> { EnemyName.EasyBig, EnemyName.MediumBig, EnemyName.EasyBig, EnemyName.EasyBig, EnemyName.MediumBig, EnemyName.EasyBig,
                EnemyName.MediumBig, EnemyName.MediumBig },
            new List<float> { },
            new List<float> { },
            Maps.SingleWall);

        CreateChapter("Chapter 8", new Vector3(0, 0, 0), 3, 6, new List<int> { 35, 35, 40, 40, 45 }, new List<int> { 1, 1, 2, 2, 2, 1 },
            new List<EnemyName> { EnemyName.MediumBig, EnemyName.MediumBig, EnemyName.EasyBig, EnemyName.MediumBig, EnemyName.EasyBig, EnemyName.MediumBig,
                EnemyName.MediumBig, EnemyName.MediumBig, EnemyName.HardBig},
            new List<float> { },
            new List<float> { },
            Maps.SingleWall);

        CreateChapter("Chapter 9", new Vector3(-5.37f, 0, 0), 3, 3, new List<int> { 15, 30 }, new List<int> { 1, 2, 2 },
            new List<EnemyName> { EnemyName.EasyBig, EnemyName.MediumBig, EnemyName.EasyBig, EnemyName.EasyBig, EnemyName.MediumBig},
            new List<float> { 0, 0, 0, 0, 0},
            new List<float> { 0, 5.37f, -5.37f, 5.37f, -5.37f },
            Maps.DoubleWall);

        CreateChapter("Chapter 10", new Vector3(-5.37f, 0, 0), 3, 4, new List<int> { 25, 30, 35 }, new List<int> { 1, 2, 2, 3 },
            new List<EnemyName> { EnemyName.EasyBig, EnemyName.MediumBig, EnemyName.EasyBig, EnemyName.MediumBig, EnemyName.MediumBig, EnemyName.EasyBig,
                EnemyName.MediumBig, EnemyName.MediumBig, },
            new List<float> { 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<float> { 0, 5.37f, -5.37f, 5.37f, -5.37f, -5.37f, 0, 5.37f },
            Maps.DoubleWall);

        CreateChapter("Chapter 11", new Vector3(-5.37f, 0, 0), 3, 4, new List<int> { 60, 60, 60, }, new List<int> { 2, 2, 2, 3 },
            new List<EnemyName> { EnemyName.MediumBig, EnemyName.MediumBig, EnemyName.MediumBig, EnemyName.MediumBig, EnemyName.MediumBig, EnemyName.MediumBig,
            EnemyName.MediumBig, EnemyName.MediumBig, EnemyName.HardBig},
            new List<float> { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<float> { 0, 5.37f, -5.37f, 5.37f, -5.37f, 0, -5.37f, 0, 5.37f },
            Maps.DoubleWall);

        CreateChapter("Chapter 12", new Vector3(0, 0, 0), 3, 4, new List<int> { 55, 65, 65, }, new List<int> { 3, 3, 2, 3 },
            new List<EnemyName> { EnemyName.EasyBig, EnemyName.MediumBig, EnemyName.MediumBig, EnemyName.EasyBig, EnemyName.MediumBig, EnemyName.MediumBig,
            EnemyName.MediumBig, EnemyName.HardBig,
            EnemyName.EasyBig, EnemyName.MediumBig, EnemyName.HardBig},
            new List<float> { },
            new List<float> { },
            Maps.DoubleWall);

        CreateChapter("Chapter 13", new Vector3(0, 0, 0), 3, 4, new List<int> { 25, 25, 30 }, new List<int> { 2, 2, 3, 3 },
            new List<EnemyName> { EnemyName.EasyBig, EnemyName.EasyBig, EnemyName.EasyBig, EnemyName.EasyBig, EnemyName.EasyBig, EnemyName.EasyBig, EnemyName.EasyBig,
            EnemyName.EasyBig, EnemyName.EasyBig, EnemyName.MediumBig},
            new List<float> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            new List<float> { -6, 6, -2, 2, -6, -2, 2, -2, 2, 6},
            Maps.TripleWall);

        CreateChapter("Chapter 14", new Vector3(0, 0, 0), 3, 4, new List<int> { 30, 35, 35 }, new List<int> { 2, 2, 3, 4 },
            new List<EnemyName> { EnemyName.EasyBig, EnemyName.EasyBig, EnemyName.EasyBig, EnemyName.MediumBig, EnemyName.EasyBig, EnemyName.MediumBig, EnemyName.MediumBig,
            EnemyName.EasyBig, EnemyName.MediumBig, EnemyName.EasyBig, EnemyName.MediumBig},
            new List<float> { -100, 100, 100, -100, -100, 100, 0, 100, 0, 0, -100 },
            new List<float> { -2, 6, -6, 2, -2, 2, 6, -6, -2, 2, 6},
            Maps.TripleWall);

        /*CreateChapter("Chapter 15", new Vector3(0, 0, 0), 3, 5, new List<int> { 30, 40, 55, 65 }, new List<int> { 2, 2, 3, 3, 4 },
            new List<EnemyName> { EnemyName.EasyBig, EnemyName.MediumBig, EnemyName.MediumBig, EnemyName.MediumBig, EnemyName.EasyBig, EnemyName.MediumBig, EnemyName.MediumBig,
            EnemyName.MediumBig, EnemyName.MediumBig, EnemyName.MediumBig, EnemyName.EasyBig, EnemyName.MediumBig, EnemyName.MediumBig, EnemyName.HardBig},
            new List<float> { 100, -100, 100, -100, 100, 100, -100, -100, 100, -100, -100, -100, 100, 100 },
            new List<float> { -2, 2, -6, 6, -6, 6, 2, 6, -2, 2, -2, -2, -6, 2 },
            Maps.TripleWall);*/

        CreateChapter("Chapter 15", new Vector3(0, 0, 0), 3, 1, new List<int> { }, new List<int> { 1 },
            new List<EnemyName> { EnemyName.EasyBig},
            new List<float> { },
            new List<float> { },
            Maps.TripleWall);

        CreateSurvivalChapter(100);
    }

    void CreateChapter(string chapterName, Vector3 playerPosition, float waveCounter, int waveCount, List<int> waveTime, List<int> numberOfEnemiesToSpawnThisWave, List<EnemyName> enemiesToSpawn, List<float> enemiesForce, List<float> spawnLocationsX, Maps map)
    {
        chapters.Add(new ChapterItem(chapterName, playerPosition, waveCounter, waveCount, waveTime, numberOfEnemiesToSpawnThisWave, enemiesToSpawn, enemiesForce, spawnLocationsX, map));
    }

    void CreateSurvivalChapter(int waveAmount)
    {
        List<int> waveTimeSurvival = new List<int>();
        List<int> numberOfEnemiesToSpawnThisWaveSurvival = new List<int>();
        List<EnemyName> enemiesToSpawnSurvival = new List<EnemyName>();

        for (int i = 0; i < waveAmount; i++)
        {
            if (i != waveAmount - 1)
                //waveTimeSurvival.Add(10);
                waveTimeSurvival.Add(CalculateWaveTime(i));

            List<EnemyName> a;

            a = CreateEnemiesForSurvival(i);

            enemiesToSpawnSurvival.AddRange(a);

            numberOfEnemiesToSpawnThisWaveSurvival.Add(a.Count);
            
        }

        CreateChapter("Chapter 16", new Vector3(0, 0, 0), 3, waveAmount, waveTimeSurvival, numberOfEnemiesToSpawnThisWaveSurvival, enemiesToSpawnSurvival, new List<float> { }, new List<float> { }, Maps.Empty);
    }

    List<EnemyName> CreateEnemiesForSurvival(int wave)
    {
        int enemyCount;

        if (wave < 5) enemyCount = Random.Range(1, 4);
        else if (wave >= 5 && wave < 10) enemyCount = Random.Range(2, 4);
        else if (wave >= 10 && wave < 20) enemyCount = Random.Range(2, 4);
        else if (wave >= 20 && wave < 30) enemyCount = Random.Range(2, 5);
        else if (wave >= 30 && wave < 40) enemyCount = Random.Range(2, 5);
        else if (wave >= 40 && wave < 50) enemyCount = Random.Range(3, 5);
        else if (wave >= 50 && wave < 60) enemyCount = Random.Range(3, 6);
        else if (wave >= 60 && wave < 70) enemyCount = Random.Range(3, 6);
        else if (wave >= 70 && wave < 80) enemyCount = Random.Range(4, 7);
        else if (wave >= 80 && wave < 90) enemyCount = Random.Range(4, 7);
        else if (wave >= 90 && wave < 100) enemyCount = Random.Range(5, 7);
        else enemyCount = Random.Range(5, 8);

        return TakeEnemiesByDifficulty(wave, enemyCount);
    }

    List<EnemyName> TakeEnemiesByDifficulty(int wave, int enemyCount)
    {
        List<EnemyName> enemies = new List<EnemyName>();


        for (int i = 0; i < enemyCount; i++)
        {
            if (wave < 5) enemies.Add(GetEnemy(Random.Range(0, 2)));
            else if (wave >= 5 && wave < 10) enemies.Add(GetEnemy(Random.Range(1, 3)));
            else if (wave >= 10 && wave < 20) enemies.Add(GetEnemy(Random.Range(1, 3)));
            else if (wave >= 20 && wave < 30) enemies.Add(GetEnemy(Random.Range(1, 4)));
            else if (wave >= 30 && wave < 40) enemies.Add(GetEnemy(Random.Range(1, 4)));
            else if (wave >= 40 && wave < 50) enemies.Add(GetEnemy(Random.Range(2, 5)));
            else if (wave >= 50 && wave < 60) enemies.Add(GetEnemy(Random.Range(2, 5)));
            else if (wave >= 60 && wave < 70) enemies.Add(GetEnemy(Random.Range(2, 6)));
            else if (wave >= 70 && wave < 80) enemies.Add(GetEnemy(Random.Range(3, 6)));
            else if (wave >= 80 && wave < 90) enemies.Add(GetEnemy(Random.Range(3, 7)));
            else if (wave >= 90 && wave < 100) enemies.Add(GetEnemy(Random.Range(3, 7)));
            else enemies.Add(GetEnemy(Random.Range(4, 7)));
        }

        return enemies;
    }

    EnemyName GetEnemy(int randomNumber)
    {
        switch(randomNumber)
        {
            case 0: return EnemyName.TutorialEasyBig;
            case 1: return EnemyName.EasyBig;
            case 2: return EnemyName.EasySmall;
            case 3: return EnemyName.MediumBig;
            case 4: return EnemyName.MediumSmall;
            case 5: return EnemyName.HardBig;
            case 6: return EnemyName.HardSmall;
            default: return EnemyName.TutorialEasyBig;
        }
    }

    int CalculateWaveTime(int wave)
    {
        if (wave < 5) return 20;
        else if (wave >= 5 && wave < 10) return 25;
        else if (wave >= 10 && wave < 20) return 35;
        else if (wave >= 20 && wave < 30) return 45;
        else if (wave >= 30 && wave < 40) return 55;
        else if (wave >= 40 && wave < 50) return 65;
        else if (wave >= 50 && wave < 60) return 75;
        else if (wave >= 60 && wave < 70) return 85;
        else if (wave >= 70 && wave < 80) return 95;
        else if (wave >= 80 && wave < 90) return 105;
        else if (wave >= 90 && wave < 100) return 115;
        else return 125;
    }


    public ChapterItem ReturnChapter(string chapterName)
    {
        ChapterItem result = chapters.Find(x => x.chapterName == chapterName);
        if (result == null) return null;
        else return new ChapterItem(result.chapterName, result.playerPosition, result.waveCounter, result.waveCount, result.waveTime, result.numberOfEnemiesToSpawnThisWave,
            result.enemiesToSpawn, result.enemiesForce, result.spawnLocationsX, result.map);
    }

}
