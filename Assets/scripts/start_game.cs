using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using UnityEngine.Windows;
using UnityEngine.SceneManagement;

public class start_game : MonoBehaviour
{
    void Update()
    {
        StartGame();
    }

    void StartGame()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Tutorial");
        }
    }
}