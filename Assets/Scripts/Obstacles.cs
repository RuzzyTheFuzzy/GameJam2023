using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Obstacles : MonoBehaviour
{
    public Vector3 direction;
    [SerializeField] private float speed;
    [SerializeField] private float respawnDistance;

    private Vector3 startPos;

    private void Start( )
    {
        startPos = transform.position;
        speed = Random.Range( 1.4f, 7f );
    }

    void Update()
    {
        transform.position += direction * ( speed * Time.deltaTime );

        if ( Vector3.Distance( transform.position, startPos ) >= respawnDistance )
        {
            transform.position = startPos;
        }
    }
}
