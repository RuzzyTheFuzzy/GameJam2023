using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Camera playerCamera;
    [SerializeField] private float gridSize;
    [SerializeField] private float moveTime;

    private Vector3 newPosition;
    private Vector3 oldPosition;
    private float lerpTimer;

    private void Start( )
    {
        lerpTimer = moveTime;
    }

    private void Update( )
    {
        Debug.Log(lerpTimer);
        
        if ( lerpTimer >= moveTime )
        {
            var position = transform.position;
            if ( Input.GetKeyDown( "w" ) )
            {
                position.z += gridSize;
            }
            else if ( Input.GetKeyDown( "a" ) )
            {
                position.x -= gridSize;
            }
            else if ( Input.GetKeyDown( "s" ) )
            {
                position.z -= gridSize;
            }
            else if ( Input.GetKeyDown( "d" ) )
            {
                position.x += gridSize;
            }

            if ( position != transform.position )
            {
                oldPosition = transform.position;
                newPosition = position;
                lerpTimer = 0;
            }

        }
        else
        {
            lerpTimer += Time.deltaTime;
            transform.position = Vector3.Lerp( oldPosition, newPosition, lerpTimer / moveTime );
        }
    }
}
