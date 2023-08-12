using UnityEngine;

public class GhostVisionController : MonoBehaviour
{
    Camera playerCamera;

    float maxGhostVision = 100f;
    float ghostVision;

    [SerializeField]
    float ghostVisionReduceRate = 10f;

    [SerializeField]
    float ghostVisionRecoveryDelay = 2f;

    [SerializeField]
    float ghostVisionRecoveryRate = 5f;

    float timer;

    bool ghostVisionStatus;

    void Awake()
    {
        playerCamera = GetComponent<Camera>();
    }

    void Start()
    {
        ghostVision = maxGhostVision;
    }

    void Update()
    {
        ReduceVisionPoints();
        HandleVisionRecharge();
    }

    private void HandleVisionRecharge()
    {
        if (!ghostVisionStatus)
        {
            timer += Time.deltaTime;

            if (timer > ghostVisionRecoveryDelay)
            {
                timer = ghostVisionRecoveryDelay;
                VisionRecharge();
            }
        }
        else
        {
            timer = 0;
            return;
        }
    }

    private void VisionRecharge()
    {
        ghostVision += Time.deltaTime * ghostVisionRecoveryRate;

        if (ghostVision > maxGhostVision)
        {
            ghostVision = maxGhostVision;
        }
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
