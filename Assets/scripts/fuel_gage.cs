using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fuel_gage : MonoBehaviour
{
    public float fuelGage = 1f;

    // losing the gas
    void Update()
    {
        fuelGage -= 0.0001f;
        GetComponent<Slider>().value = fuelGage;

    }
}
