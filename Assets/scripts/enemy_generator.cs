using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemy_generator : MonoBehaviour
{
    public float distance = 60f;
    public float interval = 20f;
    public float angel = 60f;                   
    private float max_hori_offset;
    private float max_verti_offset;
    private float hori_offset;
    private float verti_offset;
    private float shadow_verti_offset;
    public GameObject enemy;
    public GameObject shadow;
    private GameObject cur_enemy;
    private GameObject cur_shadow;
    private GameObject plane;
    private player_control script;
    public float x = -1.5f;
    public float y = -4f;
    private float cur_x;
    private float cur_y;
    private float shadow_cur_x;
    private float shadow_cur_y;
    public float shadow_diff = 0.2f;
    // Spawning the Enemies.
    void Start()
    {   
        plane = GameObject.Find("plane");
        script = plane.GetComponent<player_control>();
        max_hori_offset = script.max_hori_offset;
        max_verti_offset = script.max_verti_offset;
        shadow_verti_offset= script.shadow_verti_offset;
        float num_of_enemy = Mathf.Ceil(distance/interval);
        for (int i = 1; i < num_of_enemy; i++)
        {
            hori_offset = Random.Range(-max_hori_offset, max_hori_offset);
            verti_offset = Random.Range(0f, max_verti_offset);
            cur_x = x + hori_offset * Mathf.Cos(angel * Mathf.Deg2Rad) + i * interval * Mathf.Sin(angel * Mathf.Deg2Rad);
            cur_y = y + verti_offset - hori_offset * Mathf.Sin(angel * Mathf.Deg2Rad) + i * interval * Mathf.Cos(angel * Mathf.Deg2Rad) + shadow_diff * Mathf.Cos(angel * Mathf.Deg2Rad);
            shadow_cur_x = cur_x + shadow_diff * Mathf.Sin(angel * Mathf.Deg2Rad); ;
            shadow_cur_y = y + shadow_verti_offset - hori_offset * Mathf.Sin(angel * Mathf.Deg2Rad) + i * interval * Mathf.Cos(angel * Mathf.Deg2Rad); 
            //Instantiate(enemy, new Vector3(cur_x, cur_y, 0f), transform.rotation);
            cur_enemy = Instantiate(enemy, transform, worldPositionStays: false);
            cur_enemy.transform.position = new Vector3(cur_x, cur_y, 0f);
            cur_shadow = Instantiate(shadow, transform, worldPositionStays: false);
            cur_shadow.transform.position = new Vector3(shadow_cur_x, shadow_cur_y, 0f);
        }
    }

    void Update()
    {
        
    }
}
