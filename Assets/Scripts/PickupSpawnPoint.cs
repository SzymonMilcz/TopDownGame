using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject pickup;

    public void spawnHealthPickup()
    {
        Instantiate(pickup);
    }

    
}
