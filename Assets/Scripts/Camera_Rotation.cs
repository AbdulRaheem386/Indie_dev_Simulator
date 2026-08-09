using UnityEngine;
using StarterAssets;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Camera_Rotation : MonoBehaviour
{
    [Header("Look Settings")]
    public float lookSensitivity = 0.15f;

    [Header("Mobile Look Area")]
    [Range(0.1f, 0.9f)]
    public float lookStartPosition = 0.4f;

    private StarterAssetsInputs starterInputs;

    private Vector2 lastPosition;
    private bool isLooking;


    void Start()
    {
        starterInputs = FindObjectOfType<StarterAssetsInputs>();

        if (starterInputs == null)
        {
            Debug.LogError("StarterAssetsInputs not found!");
        }
    }


    void Update()
    {
        // =========================
        // PC MOUSE LOOK
        // =========================

        if (Mouse.current != null)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                lastPosition = Mouse.current.position.ReadValue();
                isLooking = true;
            }


            if (Mouse.current.leftButton.isPressed && isLooking)
            {
                Vector2 currentPosition = Mouse.current.position.ReadValue();

                Vector2 delta = currentPosition - lastPosition;

                lastPosition = currentPosition;


                starterInputs.LookInput(
                    delta * lookSensitivity
                );
            }


            if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                isLooking = false;
            }
        }



        // =========================
        // MOBILE TOUCH LOOK
        // =========================

        if (Touchscreen.current != null)
        {
            var touch = Touchscreen.current.primaryTouch;


            if (touch.press.wasPressedThisFrame)
            {
                Vector2 touchPos = touch.position.ReadValue();


                // Left side movement ke liye free
                if (touchPos.x > Screen.width * lookStartPosition)
                {
                    if (EventSystem.current == null ||
                        !EventSystem.current.IsPointerOverGameObject())
                    {
                        lastPosition = touchPos;
                        isLooking = true;
                    }
                }
            }


            if (touch.press.isPressed && isLooking)
            {
                Vector2 currentPos = touch.position.ReadValue();

                Vector2 delta = currentPos - lastPosition;

                lastPosition = currentPos;


                starterInputs.LookInput(
                    delta * lookSensitivity
                );
            }


            if (touch.press.wasReleasedThisFrame)
            {
                isLooking = false;

                starterInputs.LookInput(Vector2.zero);
            }
        }
    }
}