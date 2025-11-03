using Unity.VisualScripting;
using UnityEngine;

public class ShootingEnemyBehaviour : MonoBehaviour
{
    public bool PlayerDetected = false;
    float detectionSize = 10F;
    Vector2 detectionOriginOffset = Vector2.zero;
    public Vector2 detectionOrigin;
    public Vector2 detectedObjectPosition;
    public LayerMask playerLayer;
    RaycastHit2D detectedObject;
    float detectionRefreshTimer = 3;
    public Rigidbody2D projectile;
    Rigidbody2D instantiatedProjectile;
    public Vector2 aimVector;

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
        detectionOrigin = new Vector2(transform.position.x, transform.position.y);
        detectedObject = Physics2D.CircleCast(detectionOrigin, detectionSize, detectionOriginOffset, 0F, playerLayer);
        if (detectedObject)
        {
            detectedObjectPosition = new Vector2(detectedObject.transform.position.x, detectedObject.transform.position.y);
            aimVector = detectedObjectPosition - detectionOrigin;
            Debug.Log(aimVector);
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
        instantiatedProjectile = Instantiate(projectile, gameObject.transform);
        instantiatedProjectile.linearVelocity = aimVector * 1.2f;
    }
}
