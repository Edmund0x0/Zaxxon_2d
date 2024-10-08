using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

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
    private int random_enemy = 0;

    public List<GameObject> numbers;

    public GameObject shadow;
    public List<GameObject> enemy;
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
            if (i % 2 == 0)
            {
                spawn_enemy_left(i);
                spawn_enemy_right(i);
            }
            else
            {
                spawn_enemy_mid(i);
            }
        }
    }

    void Update()
    {
        
    }

    void spawn_enemy_left(int i)
    {
        hori_offset = Random.Range(-max_hori_offset, 0f);
        verti_offset = Random.Range(max_verti_offset/2f, max_verti_offset);
        verti_offset = Mathf.Round(verti_offset);
        cur_x = x + hori_offset * Mathf.Cos(angel * Mathf.Deg2Rad) + i * interval * Mathf.Sin(angel * Mathf.Deg2Rad);
        cur_y = y + verti_offset - hori_offset * Mathf.Sin(angel * Mathf.Deg2Rad) + i * interval * Mathf.Cos(angel * Mathf.Deg2Rad) + shadow_diff * Mathf.Cos(angel * Mathf.Deg2Rad);
        shadow_cur_x = cur_x + shadow_diff * Mathf.Sin(angel * Mathf.Deg2Rad); ;
        shadow_cur_y = y + shadow_verti_offset - hori_offset * Mathf.Sin(angel * Mathf.Deg2Rad) + i * interval * Mathf.Cos(angel * Mathf.Deg2Rad);
        //Instantiate(enemy, new Vector3(cur_x, cur_y, 0f), transform.rotation);
        random_enemy = Random.Range(0, enemy.Count);
        Debug.Log(enemy.Count);
        Debug.Log("This is the Random Range " + random_enemy);
        cur_enemy = Instantiate(enemy[random_enemy], transform, worldPositionStays: false);
        cur_enemy.transform.position = new Vector3(cur_x, cur_y, 0f);
        cur_shadow = Instantiate(shadow, transform, worldPositionStays: false);
        cur_shadow.transform.position = new Vector3(shadow_cur_x, shadow_cur_y, 0f);
        cur_enemy.GetComponent<enemy_movement>().shadow = cur_shadow;
        cur_enemy.GetComponent<enemy_movement>().verti_offset = verti_offset;
        int k = (int)Mathf.Round(verti_offset);
        generate_number(k, cur_enemy.transform);
    }

    void spawn_enemy_mid(int i)
    {
        hori_offset = Random.Range(-max_hori_offset, max_hori_offset);
        verti_offset = Random.Range(0f, max_verti_offset);
        verti_offset = Mathf.Round(verti_offset);
        cur_x = x + hori_offset * Mathf.Cos(angel * Mathf.Deg2Rad) + i * interval * Mathf.Sin(angel * Mathf.Deg2Rad);
        cur_y = y + verti_offset - hori_offset * Mathf.Sin(angel * Mathf.Deg2Rad) + i * interval * Mathf.Cos(angel * Mathf.Deg2Rad) + shadow_diff * Mathf.Cos(angel * Mathf.Deg2Rad);
        shadow_cur_x = cur_x + shadow_diff * Mathf.Sin(angel * Mathf.Deg2Rad); ;
        shadow_cur_y = y + shadow_verti_offset - hori_offset * Mathf.Sin(angel * Mathf.Deg2Rad) + i * interval * Mathf.Cos(angel * Mathf.Deg2Rad);
        //Instantiate(enemy, new Vector3(cur_x, cur_y, 0f), transform.rotation);
        random_enemy = Random.Range(0, enemy.Count);
        Debug.Log(enemy.Count);
        Debug.Log("This is the Random Range " + random_enemy);
        cur_enemy = Instantiate(enemy[random_enemy], transform, worldPositionStays: false);
        cur_enemy.transform.position = new Vector3(cur_x, cur_y, 0f);
        cur_shadow = Instantiate(shadow, transform, worldPositionStays: false);
        cur_shadow.transform.position = new Vector3(shadow_cur_x, shadow_cur_y, 0f);
        cur_enemy.GetComponent<enemy_movement>().shadow = cur_shadow;
        cur_enemy.GetComponent<enemy_movement>().verti_offset = verti_offset;
        int k = (int)Mathf.Round(verti_offset);
        generate_number(k, cur_enemy.transform);
    }

    void spawn_enemy_right(int i)
    {
        hori_offset = Random.Range(0f, max_hori_offset);
        verti_offset = Random.Range(0f, max_verti_offset/2f);
        verti_offset = Mathf.Round(verti_offset);
        cur_x = x + hori_offset * Mathf.Cos(angel * Mathf.Deg2Rad) + i * interval * Mathf.Sin(angel * Mathf.Deg2Rad);
        cur_y = y + verti_offset - hori_offset * Mathf.Sin(angel * Mathf.Deg2Rad) + i * interval * Mathf.Cos(angel * Mathf.Deg2Rad) + shadow_diff * Mathf.Cos(angel * Mathf.Deg2Rad);
        shadow_cur_x = cur_x + shadow_diff * Mathf.Sin(angel * Mathf.Deg2Rad); ;
        shadow_cur_y = y + shadow_verti_offset - hori_offset * Mathf.Sin(angel * Mathf.Deg2Rad) + i * interval * Mathf.Cos(angel * Mathf.Deg2Rad);
        //Instantiate(enemy, new Vector3(cur_x, cur_y, 0f), transform.rotation);
        random_enemy = Random.Range(0, enemy.Count);
        Debug.Log(enemy.Count);
        Debug.Log("This is the Random Range " + random_enemy);
        cur_enemy = Instantiate(enemy[random_enemy], transform, worldPositionStays: false);
        cur_enemy.transform.position = new Vector3(cur_x, cur_y, 0f);
        cur_shadow = Instantiate(shadow, transform, worldPositionStays: false);
        cur_shadow.transform.position = new Vector3(shadow_cur_x, shadow_cur_y, 0f);
        cur_enemy.GetComponent<enemy_movement>().shadow = cur_shadow;
        cur_enemy.GetComponent<enemy_movement>().verti_offset = verti_offset;
        int k = (int)Mathf.Round(verti_offset);
        generate_number(k, cur_enemy.transform);
    }

    void generate_number(int i, Transform transform)
    {
        GameObject new_num = Instantiate(numbers[i], transform, worldPositionStays: false);
        new_num.transform.position = new Vector3(transform.position.x + 0.25f, transform.position.y + 1.5f, 0f);
        
    }
}
