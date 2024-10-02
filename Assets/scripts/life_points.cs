using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class life_points : MonoBehaviour
{
    public static life_points instanceLife { get; private set; }
    public int life { get; private set; } = 3;


    private void Awake()
    {
        instanceLife = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLife()
    {
        if (life != 0)
        {
            Destroy(GameObject.Find(String.Format("LifePoint{0}", life)));
            life -= 1;
        }
    }
}
