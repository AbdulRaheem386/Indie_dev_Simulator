using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes_Manager : MonoBehaviour
{
    public GameObject LoadingPanel;
    public GameObject Playbutton;
    public GameObject Quitbutton;

    public void Scene_Change()
    {
        LoadingPanel.SetActive(true);

        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Level_1");

        while (!operation.isDone)
        {
            yield return null;
        }
    }

    public void Level1_Cut2()
    {
        LoadingPanel.SetActive(true);

        StartCoroutine(LoadCut2());
    }

    IEnumerator LoadCut2()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Test");

        while (!operation.isDone)
        {
            yield return null;
        }
    }

    public void Cut2_CutSuccess()
    {
        LoadingPanel.SetActive(true);

        StartCoroutine(LoadCutSuccess());
    }

    IEnumerator LoadCutSuccess()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Cut_Success");

        while (!operation.isDone)
        {
            yield return null;
        }
    }

    public void Cut2_Cutfllop()
    {
        LoadingPanel.SetActive(true);

        StartCoroutine(LoadCutflop());
    }

    IEnumerator LoadCutflop()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Cut_Flop");

        while (!operation.isDone)
        {
            yield return null;
        }
    }

    public void Play_button()
    {
        LoadingPanel.SetActive(true);

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