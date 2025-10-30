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

    void OnCollisionEnter2D(Collision2D touchedObj)
    {
        if (touchedObj.gameObject.CompareTag("Player"))
        {
            touchedObj.gameObject.SendMessage("HealthCheck", damageValue);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
 