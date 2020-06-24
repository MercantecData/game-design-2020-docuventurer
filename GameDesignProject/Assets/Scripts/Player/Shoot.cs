using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;

    //private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
            rigidbody.velocity = bullet.transform.up * 30;

            //audioSource.Play();

            Destroy(bullet, 10);
        }
    }

}