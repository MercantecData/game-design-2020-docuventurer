using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPickup : MonoBehaviour
{
    public AudioClip audioClip;

    public void OnTriggerEnter2D()
    {
        //GameController.instance.SetBullets(GameController.instance.bullets + 1);

        Destroy(this.gameObject);
        //var clip = GetComponentInChildren<AudioSource>().clip;
        AudioSource.PlayClipAtPoint(audioClip, transform.position);

    }
}
