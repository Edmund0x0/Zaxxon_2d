using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_hit : MonoBehaviour
{
    public static player_hit instanceHit { get; private set; }
    public bool can_hit = true;

    private void Awake()
    {
        instanceHit = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
