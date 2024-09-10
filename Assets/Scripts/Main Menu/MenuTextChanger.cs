using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuTextChanger : MonoBehaviour
{
    public Text menuText;
    public List<string> texts = new List<string>();
    public List<string> remainedTexts = new List<string>();

    public string selectedWord;

    public float sayac, maxSayac, maxDeleteSayac;
    public float newWordLatency, newWordLatencyMax;

    public bool wordIsDeleting;

    void Awake()
    {
        texts.Add("I hope you have fun!");
        texts.Add("Thanks 4 playing my game <3");
        texts.Add("You can buy and upgrade weapons from the store.");
        texts.Add("Each weapon has different characteristics.");
        texts.Add("Red colored enemies are the hardest.");
        texts.Add("Survival mode has unlimited waves. Maybe it doesn't have -_-");
        texts.Add("You must not touch the balls!");

        sayac = maxSayac = 0.1f;
        maxDeleteSayac = 0.05f;
        newWordLatency = newWordLatencyMax =  3f;

        wordIsDeleting = false;
    }

    void FixedUpdate()
    {
        if (newWordLatency > 0) newWordLatency -= Time.fixedDeltaTime;
        else
        {
            if (sayac > 0) sayac -= Time.fixedDeltaTime;

            else
            {
                if (wordIsDeleting)
                {
                    DeleteWord();
                    sayac = maxDeleteSayac;
                }
                else
                {
                    if (selectedWord == "")
                    {
                        if (remainedTexts.Count == 0) AddToRemainedTextList();
                        else
                        {
                            int selectedIndex = Random.Range(0, remainedTexts.Count);
                            selectedWord = remainedTexts[selectedIndex];
                            remainedTexts.RemoveAt(selectedIndex);
                        }
                            
                    }
                    else
                    {
                        WriteWord();
                        sayac = maxSayac;
                    }
                }
            }
        }

        
        
    }

    void AddToRemainedTextList()
    {
        for (int i = 0; i < texts.Count; i++)
        {
            remainedTexts.Add(texts[i]);
        }
    }

    void DeleteWord()
    {
        if(menuText.text == "")
        {
            wordIsDeleting = false;
            newWordLatency = newWordLatencyMax;
            return;
        }

        string oldWord = menuText.text;
        string newWord = "";

        for (int i = 0; i < oldWord.Length - 1; i++)
        {
            newWord += oldWord[i];
        }

        UpdateText(newWord);
    }

    void WriteWord()
    {
        if (menuText.text == selectedWord)
        {
            selectedWord = "";
            wordIsDeleting = true;
            newWordLatency = newWordLatencyMax;
            return;
        }

        string word = menuText.text;

        word += selectedWord[word.Length];

        UpdateText(word);
    }

    void UpdateText(string text)
    {
        menuText.text = text;
    }
}
