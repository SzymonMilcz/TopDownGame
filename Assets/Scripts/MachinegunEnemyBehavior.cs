using UnityEngine;

public class MachinegunEnemyBehavior : MonoBehaviour
{
    public float health;
    public bool PlayerDetected = false;
    float detectionSize = 20;
    Vector2 detectionOriginOffset = Vector2.zero;
    public Vector2 detectionOrigin;
    public Vector2 detectedObjectPosition;
    public LayerMask playerLayer;
    RaycastHit2D detectedObject;
    float detectionRefreshTimer = 3;
    float attackDelay = 3;
    bool shootingBurst = false;
    int attackCount = 5;
    public Rigidbody2D projectile;
    Rigidbody2D instantiatedProjectile;
    public Vector2 aimVector;

    void Start()
    {
        detectionRefreshTimer = Time.time + 1;
    }

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
            Debug.Log(aimVector);
            if (PlayerDetected == false)
            {
                PlayerDetected = true;
                detectionRefreshTimer += 3;
            }
            else if (shootingBurst == false && PlayerDetected == true)
            {
                aimVector = detectedObjectPosition - detectionOrigin;
                ShootProjectile();
                shootingBurst = true;
                detectionRefreshTimer += 3;
                attackCount = 5;
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

        while (attackCount > 0)
        {
            instantiatedProjectile = Instantiate(projectile, gameObject.transform);
            instantiatedProjectile.linearVelocity = aimVector * 1.2f;
            attackDelay = Time.time + 0.2F;
            attackCount--;
        }
        if (attackCount == 0)
        {
            shootingBurst = false;
            detectionRefreshTimer = Time.time + 3;
        }
    }

    void HealthCheck(float damageValue)
    {
        health = health - damageValue;
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
}

