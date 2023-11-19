using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Quiter : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    
    private void Start( )
    {
        DontDestroyOnLoad( gameObject );
    }

    private void Update( )
    {
        if ( Input.GetKey( KeyCode.Escape ) )
        {
            Application.Quit();
        }
        if ( Input.GetKey( KeyCode.Alpha0 ) )
        {
            if ( !audioSource.isPlaying )
            {
                audioSource.Play();
            }
        }
    }
}