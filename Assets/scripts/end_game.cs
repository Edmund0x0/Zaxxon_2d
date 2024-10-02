using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using UnityEngine.Windows;
using UnityEngine.SceneManagement;

public class end_game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EndGame();
    }

    void EndGame()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Start");
        }
    }
}