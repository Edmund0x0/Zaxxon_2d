using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shield_gage : MonoBehaviour
{
    public float shieldGage = 1f;
    public float consume_rate = 0.40f;


    void Update()
    {
        GetComponent<Slider>().value = shieldGage;
    }
}
