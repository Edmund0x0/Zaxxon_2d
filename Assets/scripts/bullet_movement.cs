using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class bullet_movement : MonoBehaviour
{
    public float velocity = 0.1f;
    public float angel = 60f;
    private float x;
    private float y;
    public float lifetime = 5f;
    public GameObject gas;
    private GameObject new_gas;
    private GameObject enemy_bullet;
    public game_management manager;
    public score_board score_manager;

    // Setting up Properties
    void Start()
    {
        manager =  game_management.instance;
        score_manager = score_board.instanceScore;
        x = transform.position.x;
        y = transform.position.y;
        Destroy(gameObject, lifetime);
    }

    // Direction of the bullets
    void Update()
    {
        x += Time.deltaTime * velocity * Mathf.Sin(angel * Mathf.Deg2Rad);
        y += Time.deltaTime * velocity * Mathf.Cos(angel * Mathf.Deg2Rad);
        transform.position = new UnityEngine.Vector3(x, y, 0);
    }

    // Collision outcomes
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "PlayerBullet")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                new_gas = Instantiate(gas, collision.transform.parent, worldPositionStays: false);
                new_gas.transform.position = collision.transform.position;
                Destroy(collision.gameObject);
                Destroy(gameObject);
                score_manager.addScoreEnemyKill();
            }

            if (collision.gameObject.tag == "EnemyBullet")
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
        if (gameObject.tag == "EnemyBullet")
        {
            if (collision.gameObject.tag == "Player")
            {
                manager.Gameover();
                Destroy(gameObject);
                Debug.Log("Get Hit");
            }
        }
    }
}
