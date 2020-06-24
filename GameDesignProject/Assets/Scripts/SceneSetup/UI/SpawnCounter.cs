using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameController.instance.SetupSpawnCounter(gameObject);
    }
}
