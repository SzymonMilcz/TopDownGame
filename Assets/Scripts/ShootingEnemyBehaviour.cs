using Unity.VisualScripting;
using UnityEngine;

public class ShootingEnemyBehaviour : MonoBehaviour
{
    public bool PlayerDetected = false;
    float detectionSize = 100F;
    Vector2 detectionOriginOffset = Vector2.zero;
    Vector2 detectionOrigin;
    public LayerMask playerLayer;
    RaycastHit2D detectedObject;
    float detectionRefreshTimer = 3;
    public Rigidbody2D projectile;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        detectionRefreshTimer += Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (detectionRefreshTimer < Time.time)
        {
            PlayerDetectionCheck();
        }
    }

    void PlayerDetectionCheck()
    {
        detectionOrigin = new Vector2(transform.localPosition.x, transform.localPosition.y);
        detectedObject = Physics2D.CircleCast(detectionOrigin, detectionSize, detectionOriginOffset, 0F, playerLayer);
        if (detectedObject)
        {
            if (PlayerDetected == false)
            {
                PlayerDetected = true;
                detectionRefreshTimer += 3;
            }
            else
            {
                ShootProjectile();
                detectionRefreshTimer += 3;
            }            
            Debug.Log("Player found");
        }
        else
        {
            PlayerDetected = false;

        }
    }

    void ShootProjectile()
    {
        Instantiate(projectile, transform, transform);
    }
}
