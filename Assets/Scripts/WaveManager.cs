using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    GameManager manager;
    SpawnManager spawnManager;
    AnimationManager animationManager;
    public ChapterItem chapter;
    AudioManager audioManager;

    public int waveNo;

    public Text levelNameText;
    public Text waveCounterText;

    int bestSurvivalWave;


    void Start()
    {
        manager = GetComponent<GameManager>();
        spawnManager = GetComponent<SpawnManager>();
        animationManager = GetComponent<AnimationManager>();
        audioManager = GetComponent<AudioManager>();

        waveNo = 0;

        bestSurvivalWave = PlayerPrefs.GetInt("Best Survival Wave", 0);

        if (manager.chapterNo == 16)
        {
            levelNameText.text = "Survival Mode\nYour Best : Wave " + bestSurvivalWave;
        }
            
        else
            levelNameText.text = chapter.chapterName;
    }

    void FixedUpdate()
    {
        if (manager.lose) return;

        if (chapter.waveCounter > 0)
        {
            if(spawnManager.enemies.Count == 0 && spawnManager.enemiesSpawnedForThisWave)
            {
                chapter.waveCounter -= Time.fixedDeltaTime * 5;
            }
            else
                chapter.waveCounter -= Time.fixedDeltaTime;

            UpdateWaveCounterText();
        }
        else
        {

            if (waveNo == chapter.waveCount) return;

            if(chapter.waveTime.Count > 0)
            {
                chapter.waveCounter = chapter.waveTime[0];
                chapter.waveTime.RemoveAt(0);
            }     

            StartNewWave();
        }
    }

    void StartNewWave()
    {
        spawnManager.enemiesSpawnedForThisWave = false;
        waveNo++;
        spawnManager.StartSpawnAnim();
        animationManager.NewWave();
        audioManager.PlayNewWaveSound();

    }

    public void UpdateLevelName()
    {
        if(manager.chapterNo == 16)
            levelNameText.text = "Survival Mode - " + "Wave " + waveNo + "\nYour Best : Wave " + bestSurvivalWave;
        else
            levelNameText.text = "Chapter " + manager.chapterNo + " - " + "Wave " + waveNo + " / " + (chapter.waveCount).ToString();
    }

    void UpdateWaveCounterText()
    {
        waveCounterText.text = "Next Wave : " + Mathf.RoundToInt(chapter.waveCounter).ToString();
    }
}
