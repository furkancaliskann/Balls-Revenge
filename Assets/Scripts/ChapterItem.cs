using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterItem
{
    public string chapterName;

    public Vector3 playerPosition;

    public float waveCounter;

    public int waveCount;

    public List<int> waveTime;

    public List<int> numberOfEnemiesToSpawnThisWave;

    public List<EnemyName> enemiesToSpawn;


    public List<float> enemiesForce;
    public List<float> spawnLocationsX;

    public Maps map;


    public ChapterItem(string chapterName, Vector3 playerPosition, float waveCounter, int waveCount, List<int> waveTime, List<int> numberOfEnemiesToSpawnThisWave, List<EnemyName> enemiesToSpawn, List<float> enemiesForce, List<float> spawnLocationsX, Maps map)
    {
        this.chapterName = chapterName;
        this.playerPosition = playerPosition;
        this.waveCounter = waveCounter;
        this.waveCount = waveCount;
        this.waveTime = waveTime;
        this.numberOfEnemiesToSpawnThisWave = numberOfEnemiesToSpawnThisWave;
        this.enemiesToSpawn = enemiesToSpawn;
        this.enemiesForce = enemiesForce;
        this.spawnLocationsX = spawnLocationsX;
        this.map = map;
    }
}
