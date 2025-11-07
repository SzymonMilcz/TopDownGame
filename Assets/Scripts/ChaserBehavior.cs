using UnityEngine;

public class ChaserBehavior : MonoBehaviour
{
    public float health;
    public float contactDamage;
    public Rigidbody2D self;
    public bool PlayerDetected = false;
    float detectionSize = 20;
    Vector2 detectionOriginOffset = Vector2.zero;
    public Vector2 detectionOrigin;
    public Vector2 detectedObjectPosition;
    public LayerMask playerLayer;
    RaycastHit2D detectedObject;
    public float detectionRefreshTimer;
    public Vector2 aimVector;
    Vector3 damageAndVelocity;
    void Start()
    {
        detectionRefreshTimer = Time.time + 1;
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
            aimVector.Normalize();
            Debug.Log(aimVector);
            if (PlayerDetected == false)
            {
                PlayerDetected = true;
                detectionRefreshTimer += 3;
            }
            else
            {
                AttackPlayer();
                detectionRefreshTimer += 3;
            }
        }
        else
        {
            PlayerDetected = false;
        }
    }

    void AttackPlayer()
    {
        self.AddForce(aimVector * 1200);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            damageAndVelocity.z = contactDamage;
            collision.gameObject.SendMessage("HeavyDamage", damageAndVelocity);
        }

        if (collision.gameObject.CompareTag("Projectile"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        }
        else
        {
            self.linearVelocity = self.linearVelocity * -1;
        }
    }
}
