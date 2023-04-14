using System.Collections;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [SerializeField]
    private GameObject fish;
    [SerializeField]
    private Vector3 zoneSize;

    void Update()
    {
        StartCoroutine(Spawn());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, zoneSize);
    }

    IEnumerator Spawn()
    {
        GameObject instantiated = Instantiate(fish);
        
        instantiated.transform.position = new Vector3(Random.Range(transform.position.x - zoneSize.x / 2, transform.position.x + zoneSize.x / 2), Random.Range(transform.position.y - zoneSize.y / 2, transform.position.y + zoneSize.y / 2), 1);
        yield return new WaitForSeconds(3);
    }
}
