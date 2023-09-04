using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Timeline;

public class bullet_movement : MonoBehaviour
{
    public float velocity = 0.1f;
    public float angel = 60f;
    public float verti_offset;
    private float x;
    private float y;
    public float lifetime = 5f;
    public GameObject gas;
    private GameObject new_gas;
    private GameObject enemy_bullet;
    public game_management manager;
    public score_board score_manager;
    public life_points life_manager;

    // Setting up Properties
    void Start()
    {
        manager = game_management.instance;
        score_manager = score_board.instanceScore;
        life_manager = life_points.instanceLife;
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
                if (detect_collision_playerBullet_enemy(collision.gameObject))
                {
                    new_gas = Instantiate(gas, collision.transform.parent, worldPositionStays: false);
                    new_gas.transform.position = collision.transform.position;
                    new_gas.GetComponent<gas_movement>().shadow = collision.gameObject.GetComponent<enemy_movement>().shadow;
                    Destroy(collision.gameObject);
                    Destroy(gameObject);
                    score_manager.addScoreEnemyKill(5);
                }
            }

            if (collision.gameObject.tag == "EnemyBulletRed" ||
                collision.gameObject.tag == "EnemyBulletBlue" ||
                collision.gameObject.tag == "EnemyBulletGreen")
            {
                if (detect_collision_playerBullet_enemyBullet(collision.gameObject))
                {
                    Destroy(collision.gameObject);
                }
            }
        }

        if (gameObject.tag == "EnemyBulletRed" ||
            gameObject.tag == "EnemyBulletBlue" ||
            gameObject.tag == "EnemyBulletGreen")
        {
            if (collision.gameObject.tag == "Player")
            {
                if (detect_collision_enemyBullet_player(collision.gameObject))
                {
                    if (life_manager.life <= 0)
                    {
                        manager.Gameover();
                    }
                    Destroy(gameObject);
                    life_manager.UpdateLife();
                    Debug.Log("Get Hit");
                }
            }
        }
    }

    bool detect_collision_enemyBullet_player(GameObject player)
    {
        return (Mathf.Abs(verti_offset - player.GetComponent<player_control>().verti_offset) < 1f);
    }

    bool detect_collision_playerBullet_enemy(GameObject enemy)
    {
        return (Mathf.Abs(verti_offset - enemy.GetComponent<enemy_movement>().verti_offset) < 1f);
    }
    bool detect_collision_playerBullet_enemyBullet(GameObject enemyBullet)
    {
        return (Mathf.Abs(verti_offset - enemyBullet.GetComponent<bullet_movement>().verti_offset) < 1f);
    }
}
