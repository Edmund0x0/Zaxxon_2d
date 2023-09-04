using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gas_movement : MonoBehaviour
{
    public GameObject shadow;
    public float verti_offset;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        Invoke("show_gas", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void show_gas()
    {
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
    }
}
