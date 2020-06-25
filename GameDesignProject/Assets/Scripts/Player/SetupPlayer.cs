using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameController.instance.SetupPlayer(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
