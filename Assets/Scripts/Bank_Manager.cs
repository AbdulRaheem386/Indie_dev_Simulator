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
        UpdateUI();
    }

    public void Addmoney(int amount)
    {
        bankbalance += amount;
        UpdateUI();
    }

    public void UpdateUI()
    {
        bankbalanceUI.text = "$" + bankbalance;
    }
}
