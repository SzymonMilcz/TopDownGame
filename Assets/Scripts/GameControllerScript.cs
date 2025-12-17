using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    float spawnPointCount;
    float difficultyLevel = 1;

    void Start()
    {
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
