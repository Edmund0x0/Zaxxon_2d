using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    public GameObject enemy_bullet_red;
    private float cdtime = 2f;
    private bool can_shoot = false;
    public float float_boundary = 0.1f;
    private float float_degree = 0f;
    public float float_velocity = 1f;
    private float x;
    private float y;
    private float delta_y;
    private float delta_degree;
    // Start is called before the first frame update
    void Start()
    {

    }

    // When bullets get spawned
    void Update()
    {
        x = transform.position.x;
        y = transform.position.y;
        delta_degree = float_velocity * Time.deltaTime;
        delta_y = (Mathf.Sin((float_degree + delta_degree) * Mathf.Deg2Rad) - Mathf.Sin(float_degree * Mathf.Deg2Rad)) * float_boundary;
        float_degree += delta_degree;
        transform.position = new Vector3(x, y + delta_y, 0);
        cdtime -= Time.deltaTime;
        if (cdtime < 0f)
        {
            Shoot();
        }
    }

    // Shooting the bullets
    void Shoot()
    {
        if (can_shoot)
        {
            Instantiate(enemy_bullet_red, transform.position, Quaternion.Euler(0, 0, 120));
            cdtime = 2f;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Enemy")
        {
            if (collision.gameObject.tag == "EnemyCanShoot")
            {
                Debug.Log("Touched");
                can_shoot = true;
                cdtime = 1f;
            }

        }

    }
}
