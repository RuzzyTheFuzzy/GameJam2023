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
    [SerializeField] private LayerMask hitLayer;
    [SerializeField] private GameObject deathSplashObject;
    [SerializeField] private ParticleSystem jumpParticleObject;

    private Vector3 newPosition;
    private Vector3 oldPosition;
    private Quaternion newRotation;
    private Quaternion oldRotation;
    private float lerpTimer;
    private Vector3 cameraOffset;
    private GameObject currentPlatform;

    private void Start( )
    {
        lerpTimer = moveTime;
        cameraOffset = playerCamera.transform.position - transform.position;
        oldRotation = Quaternion.identity;
        newRotation = Quaternion.identity;
        newPosition = transform.position;
    }

    private void Update( )
    {
        var ray = new Ray( newPosition, transform.up * -1 );

        if ( Physics.Raycast( ray, out RaycastHit hitInfo, 100, hitLayer ) )
        {
            currentPlatform = hitInfo.collider.gameObject;

            var playerPlatformPos = newPosition - currentPlatform.transform.position;

            var posY = newPosition.y;
            newPosition = Vector3Int.RoundToInt( playerPlatformPos ) + currentPlatform.transform.position;
            newPosition.y = posY;

            // Debug.Log( newPosition );
        }

        if ( lerpTimer >= moveTime )
        {
            var position = transform.position;

            if ( Input.GetKeyDown( "w" ) )
            {
                position.z += gridSize;
                StartCoroutine(SpawnJumpParticles());
            }
            else if ( Input.GetKeyDown( "a" ) )
            {
                position.x -= gridSize;
                StartCoroutine(SpawnJumpParticles());
            }
            else if ( Input.GetKeyDown( "s" ) )
            {
                position.z -= gridSize;
                StartCoroutine(SpawnJumpParticles());
            }
            else if ( Input.GetKeyDown( "d" ) )
            {
                position.x += gridSize;
                StartCoroutine(SpawnJumpParticles());
            }
            if ( position != transform.position )
            {
                oldPosition = transform.position;
                newPosition = position;
                lerpTimer = 0;

                oldRotation = transform.rotation;
                newRotation = Quaternion.LookRotation( ( position - transform.position ).normalized );
            }
            //If player isn't standing on platform, player dies
            if (!Physics.Raycast(transform.position,Vector3.up*-1, out RaycastHit rayHitInfo,10,hitLayer) )
            {
                    // Debug.Log("Not on solid ground");
                    StartCoroutine(PlayerDeath());
            }
        }


        lerpTimer += Time.deltaTime;
        transform.position = Vector3.Lerp( oldPosition, newPosition, lerpTimer / moveTime );
        transform.rotation = Quaternion.Lerp( oldRotation, newRotation, lerpTimer / moveTime );
        var position2 = transform.position;
        position2.y += jumpCurve.Evaluate( lerpTimer / moveTime );
        var transform1 = transform;
        var position1 = transform1.position;
        position1 = position2;
        transform1.position = position1;


        Vector3 camPosition = playerCamera.transform.position;
        camPosition.x = position1.x + cameraOffset.x;
        camPosition.z = position1.z + cameraOffset.z;


        playerCamera.transform.position = camPosition;

        Debug.DrawLine( position1, newPosition, Color.red );
    }
        private IEnumerator PlayerDeath()
    {
        Instantiate(deathSplashObject, transform.position,transform.rotation);
        Destroy(gameObject);
        yield break;
    }

    private IEnumerator SpawnJumpParticles()
    {
        Instantiate(jumpParticleObject, transform.position, transform.rotation);
        yield break;
    }
}
