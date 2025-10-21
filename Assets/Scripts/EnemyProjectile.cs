using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public int damageValue; 
    void Start()
    {
        
    }

    void Update()
    {

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
 