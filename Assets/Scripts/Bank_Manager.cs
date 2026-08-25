using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bank_Manager : MonoBehaviour
{
    public TextMeshProUGUI bankbalanceUI;

    public int bankbalance = 0;
    void Start()
    {
        bankbalance = PlayerPrefs.GetInt("bankbalance", 0);
        UpdateUI();
    }

    public void Addmoney(int amount)
    {
        bankbalance += amount;

        PlayerPrefs.SetInt("bankbalance", bankbalance);
        PlayerPrefs.Save();

        UpdateUI();
    }

    public void UpdateUI()
    {
        bankbalanceUI.text = "$" + bankbalance;
    }

    public void Submoney(int amount)
    {
        bankbalance -= amount;

        PlayerPrefs.SetInt("bankbalance", bankbalance);
        PlayerPrefs.Save();

        UpdateUI();
    }
}
