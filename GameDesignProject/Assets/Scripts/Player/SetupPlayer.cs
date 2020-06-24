using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameController.instance.SetupPlayer(gameObject);
        print(transform.position.x);
        print(transform.position.y);
        print(transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
