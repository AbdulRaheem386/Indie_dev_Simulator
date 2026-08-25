using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Gamo_Over : MonoBehaviour
{
    public Scenes_Manager scenes_manager; 

    public GameObject GameOver_panel;
    public TextMeshProUGUI GameOvertext;
    public GameObject RestratButton;

    public void Game_Over()
    {
        GameOver_panel.SetActive(true);

        GameOvertext.text = "Game Over";
    }

    public void Restart()
    {
        scenes_manager.Scene_Change();
    }
}
