using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FishCounter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI fishCounter;
    public float fishCount;

    private void Update()
    {
        fishCounter.text = fishCount.ToString();
    }
}
