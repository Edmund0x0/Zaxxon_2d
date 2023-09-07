using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fuel_gage : MonoBehaviour
{
    public float fuelGage = 1f;
    private game_management manager;
    private float consume_rate = 0.00008f;
    private void Start()
    {
        manager = game_management.instance;
    }
    // losing the gas
    void Update()
    {
        fuelGage -= consume_rate;
        GetComponent<Slider>().value = fuelGage;

        if (fuelGage > 1f)
        {
            fuelGage = 1f;
        }

        if (fuelGage < 0f)
        {
            manager.Gameover();
        }
    }
}
