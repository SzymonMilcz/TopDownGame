using UnityEngine;

public class PlayerProjectileBehavior : MonoBehaviour
{
    public int damageValue;
    public Collider2D projectileCollider;
    public float projectileLifetime;
    void Start()
    {
        projectileLifetime += Time.time;
    }

    void Update()
    {
        if (projectileLifetime < Time.time)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D touchedObj)
    {
        if (touchedObj.gameObject.CompareTag("Enemy"))
        {
            touchedObj.gameObject.SendMessage("HealthCheck", damageValue);
            Destroy(gameObject);
        }
        if (touchedObj.gameObject.CompareTag("Player") || touchedObj.gameObject.CompareTag("Projectile"))
        {
            Physics2D.IgnoreCollision(projectileCollider.GetComponent<Collider2D>(), touchedObj.gameObject.GetComponent<Collider2D>());
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
 