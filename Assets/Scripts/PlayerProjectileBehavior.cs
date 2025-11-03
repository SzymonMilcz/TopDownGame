using UnityEngine;

public class PlayerProjectileBehavior : MonoBehaviour
{
    public int damageValue;
    public Collider2D projectileCollider;
    public LayerMask projectileLayer;
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

    void OnCollisionEnter2D(Collision2D touchedObj)
    {
        if (touchedObj.gameObject.CompareTag("Enemy"))
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
 