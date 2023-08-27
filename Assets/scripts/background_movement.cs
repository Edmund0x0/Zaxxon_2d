using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_movement : MonoBehaviour
{
    public float velocity = 0.1f;
    private float x;
    private float y;
    public float angel = 60f;
    
    // Setting Properites
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
    }

    // Movement for the background
    void Update()
    {   
        x -= Time.deltaTime * velocity * Mathf.Sin(angel * Mathf.Deg2Rad);
        y -= Time.deltaTime * velocity * Mathf.Cos(angel * Mathf.Deg2Rad);
        transform.position = new Vector3(x, y, 0);
    }
}
