using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public bool PlayerDetected = false;
    public float detectionSize;
    Vector2 detectionOrigin;
    Vector2 detectedObjectPosition;
    public LayerMask playerLayer;
    RaycastHit2D detectedObject;
    public float detectionTimeAmount;
    float detectionRefreshTimer;
    Vector2 aimVector;

    void Update()
    {
        if (detectionRefreshTimer < Time.time)
        {
            PlayerDetectionCheck();
        }
    }

    void PlayerDetectionCheck()
    {
        detectionOrigin = new Vector2(transform.position.x, transform.position.y);
        detectedObject = Physics2D.CircleCast(detectionOrigin, detectionSize, Vector2.zero, 0F, playerLayer);
        if (detectedObject)
        {
            detectedObjectPosition = new Vector2(detectedObject.transform.position.x, detectedObject.transform.position.y);
            aimVector = detectedObjectPosition - detectionOrigin;
            aimVector.Normalize();
            if (PlayerDetected == false)
            {
                PlayerDetected = true;
                detectionRefreshTimer = Time.time + 0.5f;
            }
            else
            {
                SendMessage("Attack", aimVector);
                detectionRefreshTimer = Time.time + detectionTimeAmount;
            }            
        }
        else
        {
            PlayerDetected = false;
        }
    }
}
