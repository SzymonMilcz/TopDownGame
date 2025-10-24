using Unity.VisualScripting;
using UnityEngine;

public class ShootingEnemyBehaviour : MonoBehaviour
{
    bool PlayerDetected = false;
    float detectionSize = 10F;
    Vector2 detectionOriginOffset = Vector2.zero;
    Vector2 detectionOrigin;
    public LayerMask PlayerLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PlayerDetectionCheck()
    {
        detectionOrigin = new Vector2(transform.localPosition.x, transform.localPosition.y);
        Debug.Log(Physics2D.CircleCast(detectionOrigin, detectionSize, detectionOriginOffset, 0F, PlayerLayer));
    }
}
