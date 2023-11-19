using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    [SerializeField] private GameObject playerObject;
    [SerializeField] private Canvas canvas;
    [SerializeField] private string levelName;
    [SerializeField] private string mainMenuName;

    private void Update( )
    {
        if ( !playerObject && !canvas.enabled )
        {
            canvas.enabled = true;
        }
    }

    public void Restart( )
    {
        SceneManager.LoadScene( levelName );
    }

    public void MainMenu( )
    {
        SceneManager.LoadScene( mainMenuName );
    }
}
