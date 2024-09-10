using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour
{
    public void Save(int currentChapter)
    {
        if (currentChapter >= 16) return;

        if(PlayerPrefs.GetInt("Current Chapter", 1) < currentChapter + 1)
        PlayerPrefs.SetInt("Current Chapter", currentChapter + 1);
    }

    public void SaveSurvival(int wave)
    {
        int bestScore = PlayerPrefs.GetInt("Best Survival Wave", 0);

        if(wave > bestScore)
        {
            PlayerPrefs.SetInt("Best Survival Wave", wave);
        }
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
