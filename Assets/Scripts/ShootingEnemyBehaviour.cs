using UnityEngine;

public class ShootingEnemyBehaviour : MonoBehaviour
{
    public float health;
    public Rigidbody2D projectile;
    Rigidbody2D instantiatedProjectile;
    public Vector2 aimVector;

    void Start()
    {
        
    }

    void Update()
    {
        
    }


    void Attack(Vector2 aimVector)
    {
        instantiatedProjectile = Instantiate(projectile, gameObject.transform);
        instantiatedProjectile.linearVelocity = aimVector * 4f;
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
