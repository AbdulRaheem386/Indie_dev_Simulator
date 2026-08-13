using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game_Review : MonoBehaviour
{
    public Computer_Use computer_Use;

    public GameObject Review_Panel;

    public TextMeshProUGUI Gamenametext;
    public TextMeshProUGUI Gamenamecustomtext;
    public TextMeshProUGUI Gamegeneretext;
    public TextMeshProUGUI Gameideatext;

    public void Panel_review()
    {
        Gamenametext.text = "Game Name: " + computer_Use.customgamename;
        Gamenamecustomtext.text = "Game Name: " + computer_Use.customgamename;
        Gamegeneretext.text = "Game Genre: " + computer_Use.gamegenre;
        Gameideatext.text = "Game Idea: " + computer_Use.gameidea;

        Review_Panel.SetActive(true);
    }
}
