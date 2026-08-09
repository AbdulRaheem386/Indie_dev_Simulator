using StarterAssets;
using System.Collections;
using TMPro;
using UnityEngine;

public class Computer_Use : MonoBehaviour
{
    public GameObject objectiveText;
    private bool playerNear = false;
    public float moveSpeed = 3f;
    public GameObject mainCanva;
    private GameObject currentpanel;

    [Header("Camera")]
    public Transform PlayerCamera;
    public Transform PCViewPoint;
    public FirstPersonController firstPersonController;
    public StarterAssetsInputs starterAssetsInputs;
    private Vector3 originalCameraPosition;
    private Quaternion originalCameraRotation;
    
    [Header("Computer_Panels")]
    public GameObject Email;
    public GameObject Unity;
    public GameObject Desktop;
    public GameObject actionPanel;
    public GameObject RPGPanel;
    public GameObject simulationPanel;
    public GameObject strategyPanel;
    public GameObject puzzlePanel;
    public GameObject horrorPanel;
    public GameObject racingPanel;
    public GameObject endlessPanel;
    public GameObject customPanel;

    [Header("Game_Name")]
    public GameObject GameName;
    public TMP_InputField gameNameInput;
    public string gamename;
    public GameObject CustomGameName;
    public TMP_InputField customgameNameInput;
    public string customgamename;
    public GameObject Gamegenere;
    public TMP_InputField gamegenreinput;
    public string gamegenre;
    public GameObject Gameidea;
    public TMP_InputField gameideainput;
    public string gameidea;

    [Header("Computer_Buttons")]
    public GameObject useButton;
    public GameObject exitButton;
    public GameObject CloseEmailButton;
    public GameObject OpenEmailButton;
    public GameObject OpenEmailButton2;
    public GameObject OpenUnityButton;
    public GameObject CloseUnityButton;
    public GameObject action_button;
    public GameObject RPG_button;
    public GameObject simulation_button;
    public GameObject strategy_button;
    public GameObject puzzle_button;
    public GameObject horror_button;
    public GameObject racing_button;
    public GameObject endless_button;
    public GameObject backtoUnityButton;
    public GameObject BorderButton1;
    public GameObject BorderButton2;
    public GameObject BorderButton3;
    public GameObject custombackbutton;

    [Header("Glow Borders")]
    public GameObject Glow1;
    public GameObject Glow2;
    public int glowselected;



    void Start()
    {
        useButton.SetActive(false);
        exitButton.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;
            useButton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger Enter: " + other.name);
        if (other.CompareTag("Player"))
        {
            playerNear = false;
            useButton.SetActive(false);
        }
    }

    // Is function ko button ke OnClick se call karenge
    public void UseComputer()
    {
        if (!playerNear)
            return;

        useButton.SetActive(false);
        objectiveText.SetActive(false);
        mainCanva.SetActive(false);

        originalCameraPosition = PlayerCamera.position;
        originalCameraRotation = PlayerCamera.rotation;

        StartCoroutine(MoveCamera());

        firstPersonController.enabled = false;
        starterAssetsInputs.enabled = false;

        // Input values reset
        starterAssetsInputs.move = Vector2.zero;
        starterAssetsInputs.look = Vector2.zero;
        starterAssetsInputs.jump = false;
        starterAssetsInputs.sprint = false;
    }

    IEnumerator MoveCamera()
    {
        while (Vector3.Distance(PlayerCamera.position, PCViewPoint.position) > 0.02f)
        {
            PlayerCamera.position = Vector3.Lerp(PlayerCamera.position, PCViewPoint.position, Time.deltaTime * moveSpeed);
            PlayerCamera.rotation = Quaternion.Lerp(PlayerCamera.rotation, PCViewPoint.rotation, Time.deltaTime * moveSpeed);

            yield return null;
        }

        PlayerCamera.position = PCViewPoint.position;
        PlayerCamera.rotation = PCViewPoint.rotation;

        Debug.Log("Camera Reached");
        exitButton.SetActive(true);
        CloseEmailButton.SetActive(true);
    }

    public void ExitComputer()
    {
        StartCoroutine(ReturnCamera());

        firstPersonController.enabled = true;
        starterAssetsInputs.enabled = true;

        if (exitButton != null)
            exitButton.SetActive(false);
        mainCanva.SetActive(true);
    }


    IEnumerator ReturnCamera()
    {
        while (Vector3.Distance(PlayerCamera.position, originalCameraPosition) > 0.02f)
        {
            PlayerCamera.position = Vector3.Lerp(
                PlayerCamera.position,
                originalCameraPosition,
                Time.deltaTime * moveSpeed
            );

            PlayerCamera.rotation = Quaternion.Lerp(
                PlayerCamera.rotation,
                originalCameraRotation,
                Time.deltaTime * moveSpeed
            );

            yield return null;
        }


        PlayerCamera.position = originalCameraPosition;
        PlayerCamera.rotation = originalCameraRotation;

        Debug.Log("Camera Returned");
    }

    public void CloseEmail()
    {
        Email.SetActive(false);
        CloseEmailButton.SetActive(false);
        Desktop.SetActive(true);
        OpenEmailButton.SetActive(true);
        OpenEmailButton2.SetActive(true);
        OpenUnityButton.SetActive(true);
        

        Debug.Log("Close Email Click");
    }

    public void OpenEmail()
    {
        Desktop.SetActive(false);
        OpenEmailButton.SetActive(false);
        OpenEmailButton2.SetActive(false);
        OpenUnityButton.SetActive(false);
        Email.SetActive(true);
        CloseEmailButton.SetActive(true);
    }

    public void OpenUnity()
    {
        Desktop.SetActive(false);
        OpenEmailButton.SetActive(false);
        OpenEmailButton2.SetActive(false);
        OpenUnityButton.SetActive(false);
        Unity.SetActive(true);
        CloseUnityButton.SetActive(true);
        GameName.SetActive(true);
        action_button.SetActive(true);
        RPG_button.SetActive(true);
        simulation_button.SetActive(true);
        strategy_button.SetActive(true);
        puzzle_button.SetActive(true);
        horror_button.SetActive(true);
        racing_button.SetActive(true);
        endless_button.SetActive(true);
        
    }

    public void CloseUnity()
    {
        Unity.SetActive(false);
        CloseUnityButton.SetActive(false);
        GameName.SetActive(false);
        action_button.SetActive(false);
        RPG_button.SetActive(false);
        simulation_button.SetActive(false);
        strategy_button.SetActive(false);
        puzzle_button.SetActive(false);
        horror_button.SetActive(false);
        racing_button.SetActive(false);
        endless_button.SetActive(false);
        Desktop.SetActive(true);
        OpenEmailButton.SetActive(true);
        OpenEmailButton2.SetActive(true);
        OpenUnityButton.SetActive(true);
    }

    public void GameNameSave(string name)
    {
        gamename = name;

        Debug.Log("Game name " + gamename);
    }

    public void CustomGAmeNameSave(string customname)
    {
        customgamename = customname;
    }

    public void GameGenreSave(string genre)
    {
        gamegenre = genre;
    }

    public void GameideaSave(string idea)
    {
        gameidea = idea;
    }

    public void backbutton()
    {
        actionPanel.SetActive(false);
        RPGPanel.SetActive(false);
        simulationPanel.SetActive(false);
        strategyPanel.SetActive(false);
        puzzlePanel.SetActive(false);
        horrorPanel.SetActive(false);
        racingPanel.SetActive(false);
        endlessPanel.SetActive(false);
        backtoUnityButton.SetActive(false);
        BorderButton1.SetActive(false);
        BorderButton2.SetActive(false);
        BorderButton3.SetActive(false);
        Glow1.SetActive(false);
        Glow2.SetActive(false);
        Unity.SetActive(true);
        CloseUnityButton.SetActive(true);
        GameName.SetActive(true);
        action_button.SetActive(true);
        RPG_button.SetActive(true);
        simulation_button.SetActive(true);
        strategy_button.SetActive(true);
        puzzle_button.SetActive(true);
        horror_button.SetActive(true);
        racing_button.SetActive(true);
        endless_button.SetActive(true);
    }

    public void action_panel()
    {
        Unity.SetActive(false);
        CloseUnityButton.SetActive(false);
        GameName.SetActive(false);
        action_button.SetActive(false);
        RPG_button.SetActive(false);
        simulation_button.SetActive(false);
        strategy_button.SetActive(false);
        puzzle_button.SetActive(false);
        horror_button.SetActive(false);
        racing_button.SetActive(false);
        endless_button.SetActive(false);
        actionPanel.SetActive(true);
        backtoUnityButton.SetActive(true);
        BorderButton1.SetActive(true);
        BorderButton2.SetActive(true);
        BorderButton3.SetActive(true);
        currentpanel = actionPanel;
    }

    public void RPG_panel()
    {
        Unity.SetActive(false);
        CloseUnityButton.SetActive(false);
        GameName.SetActive(false);
        action_button.SetActive(false);
        RPG_button.SetActive(false);
        simulation_button.SetActive(false);
        strategy_button.SetActive(false);
        puzzle_button.SetActive(false);
        horror_button.SetActive(false);
        racing_button.SetActive(false);
        endless_button.SetActive(false);
        actionPanel.SetActive(false);
        RPGPanel.SetActive(true);
        backtoUnityButton.SetActive(true);
        BorderButton1.SetActive(true);
        BorderButton2.SetActive(true);
        BorderButton3.SetActive(true);
        currentpanel = RPGPanel;
    }
    public void Simulationpanel()
    {
        Unity.SetActive(false);
        CloseUnityButton.SetActive(false);
        GameName.SetActive(false);
        action_button.SetActive(false);
        RPG_button.SetActive(false);
        simulation_button.SetActive(false);
        strategy_button.SetActive(false);
        puzzle_button.SetActive(false);
        horror_button.SetActive(false);
        racing_button.SetActive(false);
        endless_button.SetActive(false);
        actionPanel.SetActive(false);
        simulationPanel.SetActive(true);
        backtoUnityButton.SetActive(true);
        BorderButton1.SetActive(true);
        BorderButton2.SetActive(true);
        BorderButton3.SetActive(true);
        currentpanel = simulationPanel;
    }
    public void Strategypanel()
    {
        Unity.SetActive(false);
        CloseUnityButton.SetActive(false);
        GameName.SetActive(false);
        action_button.SetActive(false);
        RPG_button.SetActive(false);
        simulation_button.SetActive(false);
        strategy_button.SetActive(false);
        puzzle_button.SetActive(false);
        horror_button.SetActive(false);
        racing_button.SetActive(false);
        endless_button.SetActive(false);
        actionPanel.SetActive(false);
        strategyPanel.SetActive(true);
        backtoUnityButton.SetActive(true);
        BorderButton1.SetActive(true);
        BorderButton2.SetActive(true);
        BorderButton3.SetActive(true);
        currentpanel = strategyPanel;
    }
    public void Puzzlepanel()
    {
        Unity.SetActive(false);
        CloseUnityButton.SetActive(false);
        GameName.SetActive(false);
        action_button.SetActive(false);
        RPG_button.SetActive(false);
        simulation_button.SetActive(false);
        strategy_button.SetActive(false);
        puzzle_button.SetActive(false);
        horror_button.SetActive(false);
        racing_button.SetActive(false);
        endless_button.SetActive(false);
        actionPanel.SetActive(false);
        puzzlePanel.SetActive(true);
        backtoUnityButton.SetActive(true);
        BorderButton1.SetActive(true);
        BorderButton2.SetActive(true);
        BorderButton3.SetActive(true);
        currentpanel = puzzlePanel;
    }
    public void Horrorpanel()
    {
        Unity.SetActive(false);
        CloseUnityButton.SetActive(false);
        GameName.SetActive(false);
        action_button.SetActive(false);
        RPG_button.SetActive(false);
        simulation_button.SetActive(false);
        strategy_button.SetActive(false);
        puzzle_button.SetActive(false);
        horror_button.SetActive(false);
        racing_button.SetActive(false);
        endless_button.SetActive(false);
        actionPanel.SetActive(false);
        horrorPanel.SetActive(true);
        backtoUnityButton.SetActive(true);
        BorderButton1.SetActive(true);
        BorderButton2.SetActive(true);
        BorderButton3.SetActive(true);
        currentpanel = horrorPanel;
    }
    public void Racingpanel()
    {
        Unity.SetActive(false);
        CloseUnityButton.SetActive(false);
        GameName.SetActive(false);
        action_button.SetActive(false);
        RPG_button.SetActive(false);
        simulation_button.SetActive(false);
        strategy_button.SetActive(false);
        puzzle_button.SetActive(false);
        horror_button.SetActive(false);
        racing_button.SetActive(false);
        endless_button.SetActive(false);
        actionPanel.SetActive(false);
        racingPanel.SetActive(true);
        backtoUnityButton.SetActive(true);
        BorderButton1.SetActive(true);
        BorderButton2.SetActive(true);
        BorderButton3.SetActive(true);
        currentpanel = racingPanel;
    }
    public void Endlesspanel()
    {
        Unity.SetActive(false);
        CloseUnityButton.SetActive(false);
        GameName.SetActive(false);
        action_button.SetActive(false);
        RPG_button.SetActive(false);
        simulation_button.SetActive(false);
        strategy_button.SetActive(false);
        puzzle_button.SetActive(false);
        horror_button.SetActive(false);
        racing_button.SetActive(false);
        endless_button.SetActive(false);
        actionPanel.SetActive(false);
        endlessPanel.SetActive(true);
        backtoUnityButton.SetActive(true);
        BorderButton1.SetActive(true);
        BorderButton2.SetActive(true);
        BorderButton3.SetActive(true);
        currentpanel = endlessPanel;
    }

    public void custom_Panel()
    {
        Glow1.SetActive(false);
        Glow2.SetActive(false);
        BorderButton1.SetActive(false);
        BorderButton2.SetActive(false);
        BorderButton3.SetActive(false);

        if (currentpanel != null)
        {
            currentpanel.SetActive(false);
        }
        customPanel.SetActive(true);
        custombackbutton.SetActive(true);
        CustomGameName.SetActive(true);
        Gamegenere.SetActive(true);
        Gameidea.SetActive(true);
        

    }

    public void customback_button()
    {
        customPanel.SetActive(false);
        custombackbutton.SetActive(false);
        CustomGameName.SetActive(false);
        Gamegenere.SetActive(false);
        Gameidea.SetActive(false);

        if (currentpanel != null)
        {
            currentpanel.SetActive(true);
        }

        BorderButton1.SetActive(true);
        BorderButton2.SetActive(true);
        BorderButton3.SetActive(true);
        
    }

    public void glowselect(int id)
    {
        Glow1.SetActive(false);
        Glow2.SetActive(false);

        glowselected = id;

        if (id == 1)
            Glow1.SetActive(true);
        else if (id == 2)
            Glow2.SetActive(true);

        Debug.Log("Glow " + id);
    }
}