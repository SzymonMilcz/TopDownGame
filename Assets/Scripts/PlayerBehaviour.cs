using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    InputAction moveAction;
    InputAction attackAction;
    public Slider healthSlider;
    public Rigidbody2D rb;
    public SpriteRenderer selfSprite;
    public Animator animator;
    public float health; //Value is made public for testing purposes; it can be seen in the editor if it's public
    float maxHealth;
    float mercyInvincible = 0; //Value used to grant temporary invulnerability after taking damage, roughly for one second
    bool recentlyTookDamage = false;
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
        maxHealth = health;
        healthSlider.maxValue = health;
        healthSlider.value = health; 
        cam = Camera.main;
    }

    void Update()
    {
        //Velocity achieved via copying the moveValue is too slow, so it is increased threefold
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
            animator.SetFloat("X", moveValue.x);
            animator.SetFloat("Y", moveValue.y);
            rb.linearVelocityX = moveValue.x * 3;
            rb.linearVelocityY = moveValue.y * 3;  
            
        if (attackAction.IsPressed())
        {
            Attack();
        }
        if (mercyInvincible < Time.time && recentlyTookDamage == true)
        {
            selfSprite.color = Color.white;
            recentlyTookDamage = false;

        }
    }

    public void HealthCheck(float damageValue)
    {
        if (mercyInvincible < Time.time)
        {
            health = health - damageValue;
            healthSlider.value = health;
            Debug.Log("Current health: " + health);
            mercyInvincible = Time.time + 1F;
            selfSprite.color = Color.red;
            recentlyTookDamage = true;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void ReceiveHealth(float healValue)
    {
        health = health + healValue;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        healthSlider.value = health;
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
