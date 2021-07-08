using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameController.instance.SetupPlayerLives(gameObject);
    }
}
