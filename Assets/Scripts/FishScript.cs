using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    public float speed;

    [SerializeField]
    private GameObject fireWorksVFX;

    public float IsExplosed;

    private void Start()
    {
        Destroy(gameObject, 8);
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (IsExplosed >= 1)
        {
            Instantiate(fireWorksVFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
