using UnityEngine;

public class ChaserBehavior : MonoBehaviour
{
    public float health;
    public float contactDamage;
    public Rigidbody2D self;
    public SpriteRenderer selfSprite;
    Vector3 damageAndVelocity;
    float damagedColorTimer;


    void Update ()
    {
        if (damagedColorTimer > Time.time)
        {
            selfSprite.color = Color.red;
        }
        else
        {
            selfSprite.color = Color.white;
        }
    }
    void Attack(Vector2 aimVector)
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

    void HealthCheck(float damageValue)
    {
        health = health - damageValue;
        damagedColorTimer = Time.time + 1; 
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
