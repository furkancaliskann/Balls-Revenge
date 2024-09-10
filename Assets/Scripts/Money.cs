using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public int money;
    public Text moneyText;

    void Start()
    {
        GetMoney();
        UpdateMoneyText();
    }

    public void ChangeMoney(int changeAmount)
    {
        money += changeAmount;

        if (money < 0) money = 0;
        else if (money > 10000) money = 10000;

        UpdateMoneyText();
        SaveMoney();
    }

    public void ResetMoney()
    {
        money = 0;
        UpdateMoneyText();
        SaveMoney();
    }

    void UpdateMoneyText()
    {
        moneyText.text = money.ToString();
    }

    void GetMoney()
    {
        money = PlayerPrefs.GetInt("Money", 0);
    }

    public void SaveMoney()
    {
        PlayerPrefs.SetInt("Money", money);
    }


}
