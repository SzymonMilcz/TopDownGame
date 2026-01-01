using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    float spawnPointCount;
    float difficultyLevel = 1;
    int spawnerAmount;
    int depletedSpawnerCount = 0;

    void Start()
    {
        spawnerAmount = transform.childCount;
        spawnPointCount = difficultyLevel * 100;
        foreach (var tg in GetComponentsInChildren<SpawnPointScript>())
        {
            tg.receivePoints(spawnPointCount / transform.childCount);
        }
    }


    void distributePoints()
    {
        SendMessage("receivePoints", spawnPointCount / transform.childCount);
    }

    void receiveSpawnerMessage()
    {
        depletedSpawnerCount++;
        if (depletedSpawnerCount == spawnerAmount)
        {
            Debug.Log("Room Clear!");
        }
    }
}
