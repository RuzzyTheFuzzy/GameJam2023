using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float gridSize;
    [SerializeField] private float moveTime;
    [SerializeField] private AnimationCurve jumpCurve;
    [SerializeField] private float jumpHeight;
    [SerializeField] private LayerMask hitLayer;

    private Vector3 newPosition;
    private Vector3 oldPosition;
    private Quaternion newRotation;
    private Quaternion oldRotation;
    private float lerpTimer;
    private Vector3 cameraOffset;
    private Obstacles currentPlatform;

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
            var position = transform.position;
            position.y += jumpCurve.Evaluate( lerpTimer / moveTime ) * jumpHeight;
            transform.position = position;
        }

        Vector3 camPosition = playerCamera.transform.position;
        camPosition.x = transform.position.x + cameraOffset.x;
        camPosition.z = transform.position.z + cameraOffset.z;
        
        
        playerCamera.transform.position = camPosition;

        var ray = new Ray( transform.position, transform.up * -1 );

        if ( Physics.Raycast( ray, out RaycastHit hitInfo, 100, hitLayer ) )
        {
            if ( currentPlatform )
            {
                currentPlatform.playerMoving = null;
            }
            currentPlatform = hitInfo.collider.GetComponent<Obstacles>();
            currentPlatform.playerMoving = gameObject;
        }
        else
        {
            if ( currentPlatform )
            {
                currentPlatform.playerMoving = null;
            }
        }


    }
}