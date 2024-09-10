using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    ChapterList chapterList;
    public Button[] chapters;
    public int currentChapter;

    int registeredChapterCount;

    int pageNo;
    public List<GameObject> pages = new List<GameObject>();

    public GameObject chapterSenderPrefab;

    void Start()
    {
        chapterList = GetComponent<ChapterList>();
        registeredChapterCount = chapterList.chapters.Count;
        GetCurrentChapter();

        DeleteSenders();
    }


    public void GetCurrentChapter()
    {
        currentChapter = PlayerPrefs.GetInt("Current Chapter", 1);

        OpenChapters(currentChapter);
    }

    void LockAllChapters()
    {
        for (int i = 0; i < chapters.Length; i++)
        {
            chapters[i].interactable = false;
            chapters[i].GetComponentInChildren<Text>().text = "Chapter " + (i + 1) + "\n(Locked)";
        }
    }

    void OpenChapters(int current)
    {
        LockAllChapters();

        for (int i = 0; i < current; i++)
        {
            if(chapters.Length > i)
            {
                chapters[i].interactable = true;
                chapters[i].GetComponentInChildren<Text>().text = "Chapter " + (i + 1);
            }
            

            if(i < current - 1)
            chapters[i].GetComponentsInChildren<Image>()[1].enabled = true;
        }

        pageNo = 0;
        OpenPage(pageNo);
    }

    public void LoadChapter(int number)
    {
        if (registeredChapterCount < number) return;

        GameObject sender = Instantiate(chapterSenderPrefab);
        sender.GetComponent<ChapterSender>().chapterNumberToSend = number;

        DontDestroyOnLoad(sender);

        SceneManager.LoadScene("Chapter", LoadSceneMode.Single);
    }

    public void OpenPreviousPage()
    {
        if (pageNo <= 0) return;

        pageNo--;

        OpenPage(pageNo);
    }

    public void OpenNextPage()
    {
        if (pageNo >= 1) return;

        pageNo++;

        OpenPage(pageNo);
    }
    void CloseAllPages()
    {
        for (int i = 0; i < pages.Count; i++)
        {
            pages[i].SetActive(false);
        }
    }
    void OpenPage(int pageNo)
    {
        CloseAllPages();

        pages[pageNo].SetActive(true);
    }

    public void DeleteSenders()
    {
        GameObject[] senders = GameObject.FindGameObjectsWithTag("Chapter Sender");

        for(int i = 0; i < senders.Length; i++)
        {
            Destroy(senders[i]);
        }
    }
}
