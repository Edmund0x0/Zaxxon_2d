using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish_game : MonoBehaviour
{
    private game_management manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = game_management.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("finish");
        if (collision.gameObject.tag == "Player")
        {
            manager.Finish();
        }
    }
}
