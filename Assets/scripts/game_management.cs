using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_management : MonoBehaviour
{
    public static game_management instance;

    private void Awake()
    {
        instance = this;
    }

    // restart scene
    public void Gameover()
    {
        SceneManager.LoadScene("Over");
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
