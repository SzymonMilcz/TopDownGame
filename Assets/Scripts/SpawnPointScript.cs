using UnityEngine;

public class SpawnPointScript : MonoBehaviour
{
    public Rigidbody2D triangle;
    float spawnTimer = 0;

    float spawnPointCount;

    void Start()
    {
        spawnTimer = Time.time + 0.5f;
    }

    public void receivePoints(float pointsReceived)
    {
        spawnPointCount = pointsReceived;
    }

    void Update()
    {
        if (spawnTimer < Time.time && spawnPointCount > 0)
        {
            Instantiate(triangle, transform.position, Quaternion.identity, transform);
            spawnTimer = Time.time + 5;
            spawnPointCount-= 25;
            
        }
        if (spawnPointCount <= 0 && transform.childCount == 0)
            {
                Destroy(gameObject);
            }
    }
}
