using UnityEngine;

public class GhostVisionController : MonoBehaviour
{
    [SerializeField]
    Camera playerCamera;
    [SerializeField] LayerMask ghostLayer;

    float maxGhostVision = 100f;
    float ghostVision;

    [SerializeField]
    float ghostVisionReduceRate = 10f;

    bool ghostVisionStatus;

    void Start()
    {
        ghostVision = maxGhostVision;
    }

    void Update()
    {
        ReduceVisionPoints();
    }

    private void ReduceVisionPoints()
    {
        if (ghostVisionStatus)
        {
            ghostVision -= ghostVisionReduceRate * Time.deltaTime;

            if (ghostVision < 0)
            {
                ghostVision = 0;
                ghostVisionStatus = false;

                SwitchGhostLayer(ghostVisionStatus);
            }
            Debug.Log($"Ghost vision: {ghostVision}");
        }
    }

    public void SwitchVision(bool visionStatus)
    {
        ghostVisionStatus = visionStatus;
        SwitchGhostLayer(ghostVisionStatus);
    }

    void SwitchGhostLayer(bool visionStatus)
    {
        int currentCullingMask = playerCamera.cullingMask;
        int ghostLayer = LayerMask.NameToLayer("Ghost Object");
        int newCullingMask;

        if (visionStatus)
        {
            newCullingMask = currentCullingMask | (1 << ghostLayer);
        }
        else
        {
            newCullingMask = currentCullingMask & ~(1 << ghostLayer);
        }

        playerCamera.cullingMask = newCullingMask;
    }
}
