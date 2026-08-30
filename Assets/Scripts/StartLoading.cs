using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartLoading : MonoBehaviour
{
    public Slider loadingBar;
    public TextMeshProUGUI loadingText;

    void Start()
    {
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("CutScene_1");
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            if(loadingBar != null)
            loadingBar.value = progress;

            if (loadingText != null)
            {
                loadingText.text = "Loading " +
                    (progress * 100f).ToString("0") + "%";
            }

            yield return new WaitForSeconds(1.5f);
            operation.allowSceneActivation = true;

            yield return null;
        }
    }
}