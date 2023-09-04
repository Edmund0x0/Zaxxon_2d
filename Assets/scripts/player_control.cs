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
    public float hori_offset;
    public float verti_offset;
    private float cur_x;
    private float cur_y;
    private float cdtime = 0.5f;
    private float shield_cdtime = 1f;
    public bool activateShield = true;
    public bool shouldDrain = false;

    // public GameObject bullet;
    public GameObject Fuel;
    public GameObject ShieldGage;
    public GameObject shield;
    private GameObject new_shield;
    public GameObject gas;
    private GameObject new_gas;

    private fuel_gage gain_fuel;
    private shield_gage prop_shield;
    public game_management manager;
    public life_points life_manager;

    private SpriteRenderer plane_sprite_render;
    public Sprite neutral_plane;
    public Sprite upper_plane;
    public Sprite lower_plane;

    private GameObject shadow;
    public float shadow_verti_offset = -0.8f;
    public float shadow_diff = 0.2f;
    private float shadow_cur_x;
    private float shadow_cur_y;

    // Setting Properties
    void Start()
    {

        life_manager = life_points.instanceLife;
        manager = game_management.instance;
        ShieldGage = GameObject.Find("Shield");
        prop_shield = ShieldGage.GetComponent<shield_gage>();
        x = transform.position.x;
        y = transform.position.y;
        hori_offset = 0f;
        verti_offset = max_verti_offset;
        plane_sprite_render = GameObject.Find("/plane/plane_sprite").GetComponent<SpriteRenderer>();
        shadow = GameObject.Find("/plane/plane_shadow");
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
        if (Input.GetAxis("Vertical") > 0)
        {
            plane_sprite_render.sprite = upper_plane;
        } else if (Input.GetAxis("Vertical") < 0)
        {
            plane_sprite_render.sprite = lower_plane;
        } else
        {
            plane_sprite_render.sprite = neutral_plane;
        }
        if (verti_offset > max_verti_offset)
        {
            plane_sprite_render.sprite = neutral_plane;
            verti_offset = max_verti_offset;
        }
        if (verti_offset < 0f)
        {
            plane_sprite_render.sprite = neutral_plane;
            verti_offset = 0f;
        }
        cur_x = x + hori_offset * Mathf.Cos(angel * Mathf.Deg2Rad);
        cur_y = y + verti_offset - hori_offset * Mathf.Sin(angel * Mathf.Deg2Rad);
        transform.position = new Vector3(cur_x, cur_y, 0);
        shadow_cur_x = cur_x + shadow_diff * Mathf.Sin(angel * Mathf.Deg2Rad);
        shadow_cur_y = y + shadow_verti_offset - hori_offset * Mathf.Sin(angel * Mathf.Deg2Rad) + shadow_diff * Mathf.Cos(angel * Mathf.Deg2Rad);
        shadow.transform.position = new Vector3 (shadow_cur_x, shadow_cur_y, 0);
        cdtime -= Time.deltaTime;
        shield_cdtime -= Time.deltaTime;

        // cooldown time for shooting
        //if (cdtime < 0f)
        //{
        //    Shoot();
        //}

        if (shield_cdtime < 0f)
        {
            Shield();
        }


        if (shouldDrain)
        {
            DrainShield(prop_shield);
        }

        if (!shouldDrain)
        {
            GiveShield(prop_shield);
            activateShield = true;
        }


        // Debug.Log(String.Format("This is the shield Drain {0}", prop_shield.shieldGage));
    }

    // Player Shooting
    //public void shoot()
    //{
    //    if (input.getkeydown(keycode.space))
    //    {
    //        instantiate(bullet, transform.position, transform.rotation);
    //        cdtime = 0.5f;
    //    }
    //}

    void Shield()
    {
        if (Input.GetKey(KeyCode.Space) && activateShield)
        {
            new_shield = Instantiate(shield, transform, worldPositionStays: false);
            new_shield.transform.position = transform.position;
            activateShield = false;
            shouldDrain = true;
            shield_cdtime = 0f;

        }
        else if (Input.GetKey(KeyCode.Space) && prop_shield.shieldGage <= 0)
        {
            Destroy(GameObject.Find("shield(Clone)"));
            shield_cdtime = 2.0f;
            Debug.Log("Hello There");


        }
        else if (!Input.GetKey(KeyCode.Space))
        {
            if (GameObject.Find("shield(Clone)") != null)
            {
                Destroy(GameObject.Find("shield(Clone)"));
                activateShield = true;
                shield_cdtime = 0.5f;
            }

            shouldDrain = false;

        }

    }

    void DrainShield(shield_gage prop_shield)
    {
        if (prop_shield.shieldGage > 0f)
        {
            prop_shield.shieldGage -= prop_shield.consume_rate;
            Debug.Log(String.Format("This is the shield Drain {0}", prop_shield.shieldGage));
        }
    }

    void GiveShield(shield_gage prop_shield)
    {
        if (prop_shield.shieldGage < 1f)
        {
            prop_shield.shieldGage += prop_shield.consume_rate;
        }
    }

    // Collision Outcomes
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Fuel = GameObject.Find("Fuel");
        if (collision.gameObject.tag == "Enemy")
        {
            if (life_manager.life <= 0)
            {
                manager.Gameover();
            }

            new_gas = Instantiate(gas, collision.transform.parent, worldPositionStays: false);
            new_gas.transform.position = collision.transform.position;
            new_gas.GetComponent<gas_movement>().shadow = collision.gameObject.GetComponent<enemy_movement>().shadow;
            Destroy(collision.gameObject);
            life_manager.UpdateLife();
            Debug.Log("Get Hit");
        }

        if (collision.gameObject.tag == "Gas")
        {
            Destroy(collision.gameObject.GetComponent<gas_movement>().shadow);
            Destroy(collision.gameObject);
            gain_fuel = Fuel.GetComponent<fuel_gage>();
            gain_fuel.fuelGage += 0.35f;
            Debug.Log(gain_fuel);
            Debug.Log("Pick Gas");
        }

    }
}