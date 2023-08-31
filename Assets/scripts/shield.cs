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

    public GameObject ShieldGage;
    public GameObject Fuel;
    private shield_gage prop_shield;
    private fuel_gage gain_fuel;


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
 
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Shield")
        {
            if (collision.gameObject.tag == "EnemyBulletRed")
            {
                Destroy(collision.gameObject);
                Debug.Log("Red Bullet Hit");
            }
        }

        if (gameObject.tag == "Shield")
        {
            if (collision.gameObject.tag == "EnemyBulletBlue")
            {
                Destroy(collision.gameObject);
                prop_shield.shieldGage = 0;
                Debug.Log("Blue Bullet Hit");
            }
        }

        if (gameObject.tag == "Shield")
        {
            if (collision.gameObject.tag == "EnemyBulletGreen")
            {
                Destroy(collision.gameObject);
                gain_fuel.fuelGage -= 0.20f;
                Debug.Log("Green Bullet Hit");
            }
        }

    }
}
