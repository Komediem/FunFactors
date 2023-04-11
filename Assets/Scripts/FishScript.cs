using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    public float speed;
    public float IsExplosed = 0;

    [SerializeField]
    private GameObject fireWorksVFX;


    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        Fireworks();
    }

    private void Start()
    {
        Destroy(gameObject, 8);
    }

    private void Fireworks()
    {
        //Debug.Log(IsExplosed);

        if(IsExplosed == 2)
        {
            Instantiate(fireWorksVFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
