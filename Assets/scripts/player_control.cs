using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
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
    private float cdtime = 0.5f;
    private float shield_cdtime = 1f;
    public bool activateShield = true;

    public GameObject bullet;
    public GameObject Fuel;
    public GameObject shield;
    private GameObject new_shield;

    private fuel_gage gain_fuel;
    public game_management manager;

    

    // Setting Properties
    void Start()
    {
        //float x = GetComponent<Transform>().position.x;
        manager = game_management.instance;
        x = transform.position.x;
        y = transform.position.y;
        hori_offset = 0f;
        verti_offset = max_verti_offset;
        //Vector3 new_pos = transform.position;
    }

    // Movement of the Player
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
        shield_cdtime -= Time.deltaTime;

        // cooldown time for shooting
        if (cdtime < 0f)
        {
            Shoot();
        }

        if (shield_cdtime < 0f)
        {
            Shield();
        }
           
        Debug.Log(String.Format("This is the shield {0}", shield_cdtime));
        Debug.Log(activateShield);
        Debug.Log(cdtime);
    }

    // Player Shooting
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, transform.rotation);
            cdtime = 0.5f;
        }
    }

    void Shield()
    { 
        if (Input.GetKey(KeyCode.X) && activateShield)
        {
            new_shield = Instantiate(shield, transform, worldPositionStays: false);
            new_shield.transform.position = transform.position;
            activateShield = false;
            shield_cdtime = 0.5f;
        }
        else
        {
            if (GameObject.Find("shield(Clone)") != null)
            {
                Destroy(GameObject.Find("shield(Clone)"));
                activateShield = true;
            }
        }

    }

    // Collision Outcomes
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Fuel = GameObject.Find("Fuel");
        if (collision.gameObject.tag == "Enemy")
        {
            manager.Gameover();
            Destroy(collision.gameObject);
            Debug.Log("Run into enemy");
         }

        if (collision.gameObject.tag == "Gas")
        {
            Destroy(collision.gameObject);
            gain_fuel = Fuel.GetComponent<fuel_gage>();
            gain_fuel.fuelGage += 0.30f;
            Debug.Log(gain_fuel);
            Debug.Log("Pick Gas");
        }

    }
}
