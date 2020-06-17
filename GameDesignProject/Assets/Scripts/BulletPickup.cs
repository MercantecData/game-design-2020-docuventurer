using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPickup : MonoBehaviour
{
    public void OnTriggerEnter2D()
    {
        GameController.instance.SetBullets(GameController.instance.bullets + 1);

        Destroy(this);

    }
}
