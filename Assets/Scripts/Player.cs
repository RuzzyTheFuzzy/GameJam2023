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
    private Quaternion newRotation;
    private Quaternion oldRotation;
    private float lerpTimer;

    private Vector3 cameraOffset;

    private void Start( )
    {
        lerpTimer = moveTime;
        cameraOffset = playerCamera.transform.position - transform.position;
    }

    private void Update( )
    {
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

                oldRotation = transform.rotation;
                newRotation = Quaternion.LookRotation( ( position - transform.position ).normalized );
            }
        }
        else
        {
            lerpTimer += Time.deltaTime;
            transform.position = Vector3.Lerp( oldPosition, newPosition, lerpTimer / moveTime );
            transform.rotation = Quaternion.Lerp( oldRotation, newRotation, lerpTimer / moveTime );
        }

        playerCamera.transform.position = transform.position + cameraOffset;
    }
}