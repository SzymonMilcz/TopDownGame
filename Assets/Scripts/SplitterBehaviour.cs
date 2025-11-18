using UnityEngine;

public class SplitterBehaviour : MonoBehaviour
{
    public float health;
    public bool PlayerDetected = false;
    float detectionSize = 20;
    public Vector2 detectionOrigin;
    public Vector2 detectedObjectPosition;
    public LayerMask playerLayer;
    RaycastHit2D detectedObject;
    float detectionRefreshTimer = 3;
    public Rigidbody2D projectile;
    Rigidbody2D instantiatedProjectileOne;
    Rigidbody2D instantiatedProjectileTwo;
    public Vector2 aimVectorOne;
    public Vector2 aimVectorTwo;

    void Start()
    {
        detectionRefreshTimer = Time.time + 0.5f;
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
        detectedObject = Physics2D.CircleCast(detectionOrigin, detectionSize, Vector2.zero, 0F, playerLayer);
        if (detectedObject)
        {
            detectedObjectPosition = new Vector2(detectedObject.transform.position.x, detectedObject.transform.position.y);
            aimVectorOne = detectedObjectPosition * 1.3f - detectionOrigin; //this does not work properly, value difference between aimvector one and two can vary wildly based on how close the player is to being on the same X or Y coordinate of the enemy
            aimVectorOne.Normalize();
            aimVectorTwo = detectedObjectPosition * 0.7f - detectionOrigin;
            aimVectorTwo.Normalize();
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
        instantiatedProjectileOne = Instantiate(projectile, gameObject.transform);
        instantiatedProjectileOne.linearVelocity = aimVectorOne * 4f;
        instantiatedProjectileTwo = Instantiate(projectile, gameObject.transform);
        instantiatedProjectileTwo.linearVelocity = aimVectorTwo * 4f;
    }

    void HealthCheck(float damageValue)
    {
        health = health - damageValue;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
