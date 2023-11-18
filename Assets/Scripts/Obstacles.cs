using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed;
    [SerializeField] private float respawnDistance;

    private Vector3 startPos;

    private void Start( )
    {
        startPos = transform.position;
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
