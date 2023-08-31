using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shield_gage : MonoBehaviour
{
    public float shieldGage = 1f;
    public float consume_rate = 0.001f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Slider>().value = shieldGage;
    }
}