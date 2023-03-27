using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXSparklesScript : MonoBehaviour
{
    [SerializeField]
    private Transform SparklesLocation;
    [SerializeField]
    private float t;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = SparklesLocation.position;

        Vector3 a = transform.position;
        Vector3 b = SparklesLocation.position;
        transform.position = Vector3.Lerp(a, b, t);
    }
}
