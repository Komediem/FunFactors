using System.Collections;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [SerializeField]
    private GameObject fish;
    [SerializeField]
    private Vector3 zoneSize;

    private Timer timer;

    void Update()
    {
        timer = FindObjectOfType<Timer>();
        StartCoroutine(Spawn());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, zoneSize);
    }

    IEnumerator Spawn()
    {
        if(timer.preTimerIsActive == false)
        {
            GameObject instantiated = Instantiate(fish);

            instantiated.transform.position = new Vector3(Random.Range(transform.position.x - zoneSize.x / 2, transform.position.x + zoneSize.x / 2), Random.Range(transform.position.y - zoneSize.y / 2, transform.position.y + zoneSize.y / 2), 1);
            yield return new WaitForSeconds(3);
        }
    }
}
