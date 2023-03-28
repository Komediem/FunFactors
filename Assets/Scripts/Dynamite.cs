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
    private float rotateSpeed;

    [SerializeField]
    private GameObject explosionVFX;

    private FishScript fishScript;

    void Start()
    {
        StartCoroutine(DynamiteTimer());
    }

    private void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    IEnumerator DynamiteTimer()
    {
        yield return new WaitForSeconds(explosionSpeed);
        Explosion();
    }

    public void Explosion()
    {
        GameObject explosion = Instantiate(explosionVFX, transform.position, transform.rotation);
        Destroy(explosion, 1);
        knockBack();
        Destroy(gameObject);

        
    }

    void knockBack()
    {
        Vector3 ExplosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(ExplosionPos, radius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            fishScript.speed = 0;

            if (rb != null)
            {
                rb.AddExplosionForce(power, ExplosionPos, radius, 3.0f);
            }
        }
    }
}
