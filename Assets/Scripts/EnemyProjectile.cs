using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public int damageValue;
    public Collider2D projectileCollider;
    public LayerMask projectileLayer;
    public float projectileLifetime;
    void Start()
    {
        Physics2D.IgnoreLayerCollision(6, 6);
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
        if (touchedObj.gameObject.CompareTag("Player"))
        {
            touchedObj.gameObject.SendMessage("HealthCheck", damageValue);
            Destroy(gameObject);
        }
        if (touchedObj.gameObject.CompareTag("Enemy") || touchedObj.gameObject.CompareTag("Projectile"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), touchedObj.gameObject.GetComponent<Collider2D>());
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
 