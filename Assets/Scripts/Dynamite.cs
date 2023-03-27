using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite : MonoBehaviour
{
    [SerializeField]
    private float explosionSpeed;
    [SerializeField]
    private float radius;
    [SerializeField]
    private float power;

    [SerializeField]
    private GameObject explosionVFX;

    void Start()
    {
        StartCoroutine(DynamiteTimer());
    }

    IEnumerator DynamiteTimer()
    {
        yield return new WaitForSeconds(explosionSpeed);
        Explosion();
    }

    public void Explosion()
    {
        GameObject explosion = Instantiate(explosionVFX, transform.position, transform.rotation);
        //Destroy(explosion, 3);
        knockBack();
        Destroy(gameObject);

        
    }

    void knockBack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(power, transform.position, radius);
            }
        }
    }
}
