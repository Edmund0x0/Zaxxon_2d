using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class shield : MonoBehaviour
{
    public float velocity = 0.1f;
    private float x;
    private float y;
    public float angel = 60f;
    public float lifetime = 3f;

    public player_control control;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, lifetime);
        //GetComponent<player_control>().activateShield = false;
    }

    // Update is called once per frame
    void Update()
    {
 
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Shield")
        {
            if (collision.gameObject.tag == "EnemyBullet")
            {
                Destroy(collision.gameObject);
            }
        }

    }
}
