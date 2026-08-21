using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes_Manager : MonoBehaviour
{
    public GameObject LoadingPanel;

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
}