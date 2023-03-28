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
    [SerializeField]
    private GameObject SplashVFX;


    private FishCounter fishCounter;

    void Start()
    {
        fishCounter = FindObjectOfType<FishCounter>();
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

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("water"))
        {
            FindObjectOfType<AudioManager>().Play("Splash");
            Instantiate(SplashVFX, transform.position, transform.rotation);
        }
    }

    public void Explosion()
    {
        GameObject explosion = Instantiate(explosionVFX, transform.position, transform.rotation);
        Destroy(explosion, 1);
        //scoreCount();
        knockBack();
        FindObjectOfType<AudioManager>().Play("Explosion");
        Destroy(gameObject);
    }

    void knockBack()
    {
        Vector3 ExplosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(ExplosionPos, radius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(power, ExplosionPos, radius, 3.0f);
                fishCounter.fishCount++;
            }
        }
    }

    /*void scoreCount()
    {
        Vector3 ExplosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(ExplosionPos, radius);

        foreach (Collider hit in colliders)
        {
            if(hit.CompareTag("fish"))
            {
                
            }
        }
    }*/
}
