using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowObstacle : MonoBehaviour
{
    [SerializeField] private float shrinkTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < 0.1f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player On Platform");
            transform.localScale += transform.localScale * (-shrinkTime/100);
        }
    }
}
