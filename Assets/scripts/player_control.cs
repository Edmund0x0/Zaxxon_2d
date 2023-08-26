using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour
{
    // Start is called before the first frame update
    public float hori_velocity = 0.02f;
    public float verti_velocity = 0.02f;
    public float angel = 60f;
    private float x, y;
    public float max_hori_offset = 2.5f;
    public float max_verti_offset = 5f;
    private float hori_offset;
    private float verti_offset;
    private float cur_x;
    private float cur_y;
    public GameObject bullet;
    private float cdtime = 0.5f;
    void Start()
    {
        //float x = GetComponent<Transform>().position.x;
        x = transform.position.x;
        y = transform.position.y;
        hori_offset = 0f;
        verti_offset = max_verti_offset;
        //Vector3 new_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        hori_offset += hori_velocity * Input.GetAxis("Horizontal");
        if (hori_offset > max_hori_offset)
        {
            hori_offset = max_hori_offset;
        }
        if (hori_offset < -max_hori_offset)
        {
            hori_offset = -max_hori_offset;
        }
        verti_offset += verti_velocity * Input.GetAxis("Vertical");
        if (verti_offset > max_verti_offset)
        {
            verti_offset = max_verti_offset;
        }
        if (verti_offset < 0f)
        {
            verti_offset = 0f;
        }
        cur_x = x + hori_offset * Mathf.Cos(angel*Mathf.Deg2Rad);
        cur_y = y + verti_offset - hori_offset * Mathf.Sin(angel*Mathf.Deg2Rad);
        transform.position = new Vector3(cur_x, cur_y, 0);
        cdtime -= Time.deltaTime;

        if (cdtime < 0f)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, transform.rotation);
            cdtime = 0.5f;
        }
    }
}
