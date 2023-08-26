using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_movement : MonoBehaviour
{
    public float velocity = 0.1f;
    public float angel = 60f;
    private float x;
    private float y;
    public GameObject gas;
    private GameObject new_gas;
    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        x += Time.deltaTime * velocity * Mathf.Sin(angel * Mathf.Deg2Rad);
        y += Time.deltaTime * velocity * Mathf.Cos(angel * Mathf.Deg2Rad);
        transform.position = new Vector3(x, y, 0);
    }

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
                Destroy(gameObject);
                Debug.Log("Get Hit");
            }
        }
    }
}
