﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bControl : MonoBehaviour
{

    public void MainScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ARScene()
    {
        SceneManager.LoadScene("AR");
    }
    public void Exit()
    {
        Application.Quit();
    }
}

