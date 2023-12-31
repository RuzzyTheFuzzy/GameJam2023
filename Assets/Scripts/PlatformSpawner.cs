using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private float spawnAmount;
    [SerializeField] private float spawnXOffset;

    void Start( )
    {
        for ( int i = 0; i < spawnAmount; i++ )
        {
            var newObstacle = Instantiate( platformPrefab );
            var position = transform.position;
            Obstacles obstacleComponent = newObstacle.GetComponent<Obstacles>();

            position.z += i;
            
            if ( i % 2 == 0 )
            {
                position.x += spawnXOffset;
                newObstacle.transform.position = position;
                obstacleComponent.direction.x = -1;
            }
            else if ( i % 2 == 1 )
            {
                position.x -= spawnXOffset;
                newObstacle.transform.position = position;
                obstacleComponent.direction.x = 1;
            }
            else
            {
                Debug.Log( "SHOULD NEVER HAPPEN!!! AAAA <3" );
            }
        }
    }
}