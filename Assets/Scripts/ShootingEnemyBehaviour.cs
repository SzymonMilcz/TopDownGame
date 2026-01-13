using UnityEngine;

public class ShootingEnemyBehaviour : MonoBehaviour
{
    public float health;
    public Rigidbody2D projectile;
    Rigidbody2D instantiatedProjectile;
    public Vector2 aimVector;
    
    void Attack(Vector2 aimVector)
    {
        instantiatedProjectile = Instantiate(projectile, gameObject.transform);
        instantiatedProjectile.linearVelocity = aimVector * 6f;
    }

    void HealthCheck(float damageValue)
    {
        health = health - damageValue;
        if (health <= 0)
        {
            transform.DetachChildren();
            Destroy(gameObject);
        }
    }
}
