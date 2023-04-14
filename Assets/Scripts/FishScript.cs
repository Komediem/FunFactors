using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    public float speed;

    [SerializeField]
    private GameObject fireWorksVFX;

    private void Start()
    {
        Destroy(gameObject, 8);
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public void Firework()
    {
        if (transform.position.y >= 2)
        {
            Instantiate(fireWorksVFX, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("Firework");
            Destroy(gameObject);
        }
    }
}
