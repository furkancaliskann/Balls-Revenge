using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    SaveGame saveGame;
    Money money;
    SpawnManager spawnManager;
    WaveManager waveManager;
    AudioManager audioManager;
    Map map;

    public int chapterNo;

    public bool gameOver = false;
    public bool lose = false;
    

    public GameObject winMenu;
    public GameObject loseMenu;


    void Start()
    {
        saveGame = GetComponent<SaveGame>();
        money = GetComponent<Money>();
        spawnManager = GetComponent<SpawnManager>();
        waveManager = GetComponent<WaveManager>();
        audioManager = GetComponent<AudioManager>();
        map = GetComponent<Map>();

        SendChapterItemToOtherScripts();
    }

    void Update()
    {
        if (spawnManager.enemies.Count == 0 && spawnManager.chapter.enemiesToSpawn.Count == 0 && !lose)
        {
            if (!gameOver)
            {
                gameOver = true;
                Invoke(nameof(Win), 3f);
            }
        }
    }

    public void SendChapterItemToOtherScripts()
    {
        GameObject chapterSenderObject = GameObject.FindGameObjectWithTag("Chapter Sender");

        if (chapterSenderObject != null)
        {
            chapterNo = chapterSenderObject.GetComponent<ChapterSender>().chapterNumberToSend;

            ChapterList chapterList = GetComponent<ChapterList>();

            ChapterItem chapterItem = chapterList.ReturnChapter("Chapter " + chapterNo);

            spawnManager.chapter = waveManager.chapter = chapterItem;

            map.OpenMap(chapterItem.map);
        }
        else
        {
            chapterNo = 1;

            ChapterList chapterList = GetComponent<ChapterList>();

            ChapterItem chapterItem = chapterList.ReturnChapter("Chapter 1");

            spawnManager.chapter = waveManager.chapter = chapterItem;

            map.OpenMap(chapterItem.map);
        }
    }

    public void Win() // Called when there are no enemies left
    {
        if (lose) return;

        audioManager.PlayWinSound();
        saveGame.Save(chapterNo);

        if(chapterNo == 16)
        {
            saveGame.SaveSurvival(waveManager.waveNo);
        }
        else if (chapterNo == 15)
        {
            int allChapterOver = PlayerPrefs.GetInt("Chapters Finished", 0);

            if (allChapterOver == 0) 
            {
                PlayerPrefs.SetInt("Chapters Finished", 1);
                winMenu.GetComponentInChildren<Text>().text = "Congratulations!\n You have completely finished the chapters.";
            }
            else
                winMenu.GetComponentInChildren<Text>().text = "Mission Completed !";
        }
        else
        {
            winMenu.GetComponentInChildren<Text>().text = "Mission Completed !";
        }

        
        winMenu.SetActive(true);

        FreezeGame();
    }

    public void Lose() // Called when the game is lost
    {
        audioManager.PlayLoseSound();

        lose = true;

        if (chapterNo == 16)
        {
            saveGame.SaveSurvival(waveManager.waveNo - 1);
            loseMenu.GetComponentInChildren<Text>().text = "You Survived " + (waveManager.waveNo - 1) + " Waves!";
        }
        else
            loseMenu.GetComponentInChildren<Text>().text = "Mission Failed !";
        
        loseMenu.SetActive(true);

        FreezeGame();
    }

    public void FreezeGame() // Called when the game is over.
    {
        GameObject[] bonuses = GameObject.FindGameObjectsWithTag("Bonus");

        for (int i = 0; i < spawnManager.enemies.Count; i++)
        {
            spawnManager.enemies[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        }

        for (int i = 0; i < bonuses.Length; i++)
        {
            bonuses[i].GetComponent<Bonus>().enabled = false;
        }

        player.GetComponent<Gun>().enabled = player.GetComponent<Movement>().enabled = player.GetComponent<PlayerTrigger>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        spawnManager.enemies.Clear();
        spawnManager.chapter.enemiesToSpawn.Clear();
    }

    
}
