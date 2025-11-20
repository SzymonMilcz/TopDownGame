using System.Threading.Tasks;
using UnityEngine;

public class MachinegunEnemyBehavior : MonoBehaviour
{
    public float health;
    public float attackDelay = 0.2f;
    public bool shootingBurst = false;
    public int attackCount = 0;
    public Rigidbody2D projectile;
    Rigidbody2D instantiatedProjectile;
    Vector2 storedAimVector;


    void Update()
    {
        if (shootingBurst == true && attackDelay < Time.time)
        {
            AttackAgain();
            attackDelay = Time.time + 0.2F;
        }
    }
    void Attack(Vector2 aimVector)
    {

        if (attackCount == 0 && shootingBurst == false)
        {
            attackCount = 5;
            shootingBurst = true;
            storedAimVector = aimVector;
        }
    }

    void AttackAgain()
    {
        if (attackCount > 0)
        {
            instantiatedProjectile = Instantiate(projectile, gameObject.transform);
            instantiatedProjectile.linearVelocity = storedAimVector * 4f;
            attackCount--;
            attackDelay = Time.time + 0.2F;
        }
        if (attackCount == 0 && shootingBurst == true)
        {
            shootingBurst = false;
        }
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

