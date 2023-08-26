using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_movement : MonoBehaviour
{
    public float velocity = 0.1f;
    private float x;
    private float y;
    public float angel = 60f;
    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {   
        x -= Time.deltaTime * velocity * Mathf.Sin(angel * Mathf.Deg2Rad);
        y -= Time.deltaTime * velocity * Mathf.Cos(angel * Mathf.Deg2Rad);
        transform.position = new Vector3(x, y, 0);
    }
}
