using UnityEngine.InputSystem;
using UnityEngine;

public class SwitchGhostVision : MonoBehaviour
{
    [SerializeField]
    GhostVisionController ghostVision;

    [SerializeField]
    float visionSwitchDelay = 1f;
    float timer;

    bool isButtonPressed;

    void Update()
    {
        SwitchVisionDelay();
    }

    private void SwitchVisionDelay()
    {
        if (!isButtonPressed)
        {
            timer += Time.deltaTime;

            if (timer > visionSwitchDelay)
            {
                timer = visionSwitchDelay;
            }
        }
        else
        {
            timer = 0;
        }
    }

    public void OnGhostVision(InputValue value)
    {
        if (value.isPressed && timer == visionSwitchDelay)
        {
            ghostVision.SwitchVision(true);
            isButtonPressed = true;
        }
        else
        {
            ghostVision.SwitchVision(false);
            isButtonPressed = false;
        }
        Debug.Log(value.isPressed);
    }

    //TODO:
    //Плавно проявляти містичні об'єкти
}
