using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class shield : MonoBehaviour
{
    public float velocity = 0.1f;
    private float x;
    private float y;
    public float verti_offset;
    public float angel = 60f;
    public float lifetime = 3f;

    public GameObject bullet;
    public GameObject ShieldGage;
    public GameObject Fuel;
    private shield_gage prop_shield;
    private fuel_gage gain_fuel;
    private GameObject cur_bullet;


    // Start is called before the first frame update
    void Start()
    {
        ShieldGage = GameObject.Find("Shield");
        Fuel = GameObject.Find("Fuel");
        gain_fuel = Fuel.GetComponent<fuel_gage>();
        prop_shield = ShieldGage.GetComponent<shield_gage>();
        //Destroy(gameObject, lifetime);
        //GetComponent<player_control>().activateShield = false;
    }

    // Update is called once per frame
    void Update()
    {
        verti_offset = transform.parent.GetComponent<player_control>().verti_offset;
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (gameObject.tag == "Shield")
        {
            if (collision.gameObject.tag == "EnemyBulletRed")
            {
                if (detect_collision_shield_bullet(collision.gameObject))
                {
                    Destroy(collision.gameObject);
                    cur_bullet = Instantiate(bullet, transform.position, transform.rotation);
                    cur_bullet.GetComponent<bullet_movement>().verti_offset = verti_offset;
                    Debug.Log("Red Bullet Hit");
                }
            }
        }

        if (gameObject.tag == "Shield")
        {
            if (collision.gameObject.tag == "EnemyBulletBlue")
            {
                if (detect_collision_shield_bullet(collision.gameObject))
                {
                    Destroy(collision.gameObject);
                    cur_bullet = Instantiate(bullet, transform.position, transform.rotation);
                    cur_bullet.GetComponent<bullet_movement>().verti_offset = verti_offset;
                    prop_shield.shieldGage = 0;
                    Debug.Log("Blue Bullet Hit");
                }
            }
        }

        if (gameObject.tag == "Shield")
        {
            if (collision.gameObject.tag == "EnemyBulletGreen")
            {   
                if (detect_collision_shield_bullet(collision.gameObject))
                {
                    Destroy(collision.gameObject);
                    cur_bullet = Instantiate(bullet, transform.position, transform.rotation);
                    cur_bullet.GetComponent<bullet_movement>().verti_offset = verti_offset;
                    gain_fuel.fuelGage -= 0.20f;
                    Debug.Log("Green Bullet Hit");
                }
            }
        }

    }

    bool detect_collision_shield_bullet(GameObject bullet)
    {
        return (Mathf.Abs(verti_offset - bullet.GetComponent<bullet_movement>().verti_offset) < 0.5f);
    }
}
