using UnityEngine;

public class ShootingEnemyBehaviour : MonoBehaviour
{
    public float health;
    public Rigidbody2D projectile;
    Rigidbody2D instantiatedProjectile;
    public Vector2 aimVector;
    public SpriteRenderer selfSprite;
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
        instantiatedProjectile = Instantiate(projectile, gameObject.transform);
        instantiatedProjectile.linearVelocity = aimVector * 6f;
    }

    void HealthCheck(float damageValue)
    {
        health = health - damageValue;
        damagedColorTimer = Time.time + 0.3f; 
        if (health <= 0)
        {
            transform.DetachChildren();
            Destroy(gameObject);
        }
    }
}
