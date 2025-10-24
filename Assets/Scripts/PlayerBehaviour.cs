using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerBehaviour : MonoBehaviour
{
    InputAction moveAction;
    public Rigidbody2D rb;
    public int health; //Value is made public for testing purposes; it can be seen in the editor if it's public
    private float mercyInvincible = 0; //Value used to grant temporary invulnerability after taking damage, roughly for one second
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        health = 100;
    }

    void Update()
    {
        //Velocity achieved via copying the moveValue is too slow, so it is increased threefold
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        rb.linearVelocityX = moveValue.x * 3;
        rb.linearVelocityY = moveValue.y * 3;
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
}
