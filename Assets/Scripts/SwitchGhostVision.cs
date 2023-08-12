using UnityEngine.InputSystem;
using UnityEngine;

public class SwitchGhostVision : MonoBehaviour
{
    GhostVisionController ghostVision;

    void Awake()
    {
        ghostVision = GetComponent<GhostVisionController>();   
    }

    public void OnGhostVision(InputValue value)
    {
        if (value.isPressed)
        {
            ghostVision.SwitchVision(true);
        }
        else
        {
            ghostVision.SwitchVision(false);
        }
        Debug.Log(value.isPressed);
    }
}
