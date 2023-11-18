using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed;

    public GameObject playerMoving;
    
    void Update()
    {
        transform.position += direction * ( speed * Time.deltaTime );
        if ( playerMoving )
            playerMoving.transform.position += direction * ( speed * Time.deltaTime );
    }
}
