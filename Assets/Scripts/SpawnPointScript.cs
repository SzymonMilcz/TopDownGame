using UnityEngine;

public class SpawnPointScript : MonoBehaviour
{
    public Rigidbody2D triangle;
    float spawnTimer = 0;
    public int spawnCount;

    void Start()
    {
        spawnTimer = Time.time;
    }

    void Update()
    {
        if (spawnTimer < Time.time && spawnCount > 0)
        {
            Instantiate(triangle, transform.position, Quaternion.identity);
            spawnTimer = Time.time + 5;
            spawnCount--;
            if (spawnCount <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
