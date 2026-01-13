using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float restoredHealthAmount;
    public Collider2D self;

    void OnTriggerEnter2D(Collider2D touchedObj)
    {
        if (touchedObj.gameObject.CompareTag("Player"))
        {
            touchedObj.gameObject.SendMessage("ReceiveHealth", restoredHealthAmount);
            Destroy(gameObject);
        }   
    }
}
