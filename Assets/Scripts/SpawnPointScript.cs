using UnityEngine;

public class SpawnPointScript : MonoBehaviour
{
    public Rigidbody2D enemyToSpawn;
    float spawnTimer = 0;
    float spawnPointCount;
    public float enemyPointValue;

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
        if (spawnTimer < Time.time && spawnPointCount > enemyPointValue)
        {
            Instantiate(enemyToSpawn, transform.position, Quaternion.identity, transform);
            spawnTimer = Time.time + 5;
            spawnPointCount-= enemyPointValue;
            
        }
        if (spawnPointCount <= enemyPointValue && transform.childCount == 0)
            {
                SendMessageUpwards("receiveSpawnerMessage");
                Destroy(gameObject);
            }
    }
}
