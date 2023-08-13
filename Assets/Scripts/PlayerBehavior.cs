using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField]
    FirstPersonController firstPersonController;

    [SerializeField]
    StarterAssetsInputs starterAssetsInputs;

    public void KillPLayer()
    {
        DisablePlayerControls();
        Debug.Log("Killing player..");
    }

    private void DisablePlayerControls()
    {
        firstPersonController.enabled = false;
        starterAssetsInputs.enabled = false;
    }
}
