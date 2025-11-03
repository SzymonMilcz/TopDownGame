using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
public class PlayerBehaviour : MonoBehaviour
{
    InputAction moveAction;
    InputAction attackAction;
    public Rigidbody2D rb;
    public int health; //Value is made public for testing purposes; it can be seen in the editor if it's public
    private float mercyInvincible = 0; //Value used to grant temporary invulnerability after taking damage, roughly for one second
    Vector3 cursorPosition;
    private Camera cam;
    Vector2 shootingAngle;
    public Rigidbody2D projectile;
    Rigidbody2D instantiatedProjectile;
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
        rb.linearVelocityX = moveValue.x * 3;
        rb.linearVelocityY = moveValue.y * 3;
        if (attackAction.IsPressed())
        {
            Attack();
        }
    }

    public void HealthCheck(int damageValue)
    {
        if (mercyInvincible < Time.time)
        {
            health = health - damageValue;
            Debug.Log("Current health: " + health);
            mercyInvincible = Time.time + 1F;
            Debug.Log(Time.time);
        }
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }

    void Attack()
    {
        cursorPosition = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        shootingAngle = new Vector3(cursorPosition.x - transform.position.x, cursorPosition.y - transform.position.y, 0);
        instantiatedProjectile = Instantiate(projectile, transform);
    }
}
