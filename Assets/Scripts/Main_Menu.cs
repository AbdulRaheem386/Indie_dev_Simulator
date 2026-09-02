using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public Scenes_Manager scene_manager;
    public GameObject Playbutton;
    public GameObject Quitbutton;

    public void Play_button()
    {
        scene_manager.LoadingPanel.SetActive(true);

        StartCoroutine(LoadCutScene1());
    }

    IEnumerator LoadCutScene1()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("CutScene_1");

        while (!operation.isDone)
        {
            yield return null;
        }
    }

    public void Quit_Game()
    {
        Application.Quit();
    }

}
