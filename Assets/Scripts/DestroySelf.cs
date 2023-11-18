using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    [SerializeField] private float timeToDestroy = 3f; 
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DestroySelfObject),timeToDestroy);
    }

    // Update is called once per frame

    void DestroySelfObject()
    {
        Destroy(gameObject);
    }
}
