using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    public GameObject enemy_bullet;
    private float cdtime =2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // When bullets get spawned
    void Update()
    {
        cdtime -= Time.deltaTime;
        if (cdtime < 0f)
        {
            //Shoot();
        }
    }

    // Shooting the bullets
    void Shoot()
    {
        Instantiate(enemy_bullet, transform.position, Quaternion.Euler(0, 0, 120));
        cdtime = 2f;
    }
}
