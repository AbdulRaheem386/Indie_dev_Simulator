using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gamo_Over : MonoBehaviour
{
    public GameObject GameOver_panel;
    public TextMeshProUGUI GameOvertext;

    public void Game_Over()
    {
        GameOver_panel.SetActive(true);

        GameOvertext.text = "Game Over";
    }
}
