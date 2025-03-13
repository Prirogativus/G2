using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int money = 500;

    void Start()
    {
        if (PlayerPrefs.HasKey("SavedMoney"))
        {
            money = PlayerPrefs.GetInt("SavedMoney");
        }
    }

    public void SpendMoney(int amount)
    {
        if (money >= amount)
        {
            money -= amount;
            SaveMoney();
        }
    }

    public void AddMoney(int amount)
    {
        money += amount;
        SaveMoney();
    }

    private void SaveMoney()
    {

        PlayerPrefs.SetInt("SaveMoney", money);
        PlayerPrefs.Save();
    }
}
