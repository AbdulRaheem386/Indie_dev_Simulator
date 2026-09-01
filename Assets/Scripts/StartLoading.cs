using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartLoading : MonoBehaviour
{
    public Slider loadingBar;
    public TextMeshProUGUI loadingText;

    public float loadingSpeed = 0.2f;

    void Start()
    {
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Main_Menu");

        operation.allowSceneActivation = false;

        float displayedProgress = 0f;

        while (displayedProgress < 1f)
        {
            float targetProgress = Mathf.Clamp01(operation.progress / 0.9f);

            displayedProgress = Mathf.MoveTowards(
                displayedProgress,
                targetProgress,
                loadingSpeed * Time.deltaTime
            );

            if (loadingBar != null)
                loadingBar.value = displayedProgress;

            if (loadingText != null)
                loadingText.text = (displayedProgress * 100f).ToString("0") + "%";

            yield return null;

            // Scene completely loaded
            if (operation.progress >= 0.9f && displayedProgress >= 1f)
            {
                break;
            }
        }

        // 100% show karo
        if (loadingBar != null)
            loadingBar.value = 1f;

        if (loadingText != null)
            loadingText.text = "100%";

        // Animation ko thori der aur chalne do
        yield return new WaitForSeconds(10f);

        operation.allowSceneActivation = true;
    }
}