using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    float spawnPointCount;
    float difficultyLevel = 1;
    int spawnerAmount;

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
}
