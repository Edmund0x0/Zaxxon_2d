using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using UnityEngine.Windows;
using UnityEngine.SceneManagement;

public class finish_tutorial_game : MonoBehaviour
{
    void Update()
    {
        FinishTutorialGame();
    }

    void FinishTutorialGame()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Game");
        }
    }
}