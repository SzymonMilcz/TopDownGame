using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
public class PlayerBehaviour : MonoBehaviour
{
    InputAction moveAction;
    InputAction attackAction;
    public Rigidbody2D rb;
    public float health; //Value is made public for testing purposes; it can be seen in the editor if it's public
    private float mercyInvincible = 0; //Value used to grant temporary invulnerability after taking damage, roughly for one second
    Vector3 cursorPosition;
    private Camera cam;
    Vector3 shootingAngle;
    public Rigidbody2D projectile;
    Rigidbody2D instantiatedProjectile;
    Vector3 projectileOrigin;
    public float shootingDelay;
    float currentShootingDelay;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        attackAction = InputSystem.actions.FindAction("Attack");
        health = 100;
        cam = Camera.main;
    }

    void Update()
    {
        //Velocity achieved via copying the moveValue is too slow, so it is increased threefold
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        if (rb.linearVelocityX < 7)
        {
            rb.AddForceX(moveValue.x * 8);
        }
        if (rb.linearVelocityY < 7)
        {
            rb.AddForceY(moveValue.y * 8);  
        }
        
        if (attackAction.IsPressed())
        {
            Attack();
        }
    }

    public void HealthCheck(float damageValue)
    {
        if (mercyInvincible < Time.time)
        {
            health = health - damageValue;
            Debug.Log("Current health: " + health);
            mercyInvincible = Time.time + 1F;
            Debug.Log(Time.time);
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void HeavyDamage(Vector3 damageReceived)
    {
        rb.AddForce(new Vector2(damageReceived.x, damageReceived.y) * 3);
        HealthCheck(damageReceived.z);
    }

    void Attack()
    {
        if (currentShootingDelay < Time.time)
        {
            cursorPosition = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            shootingAngle = new Vector3(cursorPosition.x - transform.position.x, cursorPosition.y - transform.position.y, 0);
            shootingAngle.Normalize();
            projectileOrigin = transform.position + shootingAngle;
            instantiatedProjectile = Instantiate(projectile, projectileOrigin, Quaternion.identity, transform);
            instantiatedProjectile.AddForce(shootingAngle * 200);
            currentShootingDelay = Time.time + shootingDelay;
        }
        
    }
}
