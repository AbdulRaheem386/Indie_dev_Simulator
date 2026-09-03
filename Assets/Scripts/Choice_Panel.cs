using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Choice_Panel : MonoBehaviour
{
    public GameObject Choseoption;
    public Scenes_Manager scenes_manager;
    public Bank_Manager bank_manager;
    public GameObject RestratButton;

    public void choice()
    {
        Choseoption.SetActive(true);
        bank_manager.Submoney(2000);
    }

    public void Restart()
    {
        scenes_manager.Scene_Change();
    }
}
