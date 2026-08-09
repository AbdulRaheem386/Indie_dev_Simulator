using System.Collections;
using UnityEngine;
using TMPro;

public class Starting_Text : MonoBehaviour
{
    [Header("UI")]
    public GameObject storyPanel;
    public TextMeshProUGUI storyText;
    public TextMeshProUGUI objectiveText;

    [Header("Story")]
    [TextArea(2, 5)]
    public string[] storyLines =
    {
        "Everyone starts somewhere...",
        "All I have is this small room and an old computer.",
        "Today, I begin my journey to become a successful game developer."
    };

    [Header("Typewriter Settings")]
    public float typingSpeed = 0.05f;   // Har letter ki speed
    public float lineDelay = 2f;        // Line complete hone ke baad wait

    void Start()
    {
        if (objectiveText != null)
            objectiveText.gameObject.SetActive(false);

        StartCoroutine(PlayStory());
    }

    IEnumerator PlayStory()
    {
        storyPanel.SetActive(true);

        foreach (string line in storyLines)
        {
            yield return StartCoroutine(TypeLine(line));
            yield return new WaitForSeconds(lineDelay);
        }

        storyPanel.SetActive(false);

        objectiveText.gameObject.SetActive(true);
        objectiveText.text = "Objective: Use your computer to develop your first game.";
    }

    IEnumerator TypeLine(string line)
    {
        storyText.text = "";

        foreach (char letter in line)
        {
            storyText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}