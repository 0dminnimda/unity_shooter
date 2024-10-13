using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject target;
    public int minCord = -10;
    public int maxCord = 10;
    public float targetHeught = 0f;

    // Generate Targets
    void Start()
    {
        int numberOfTargets = Random.Range(10, 40);

        for (int i = 0; i < numberOfTargets; i++)
        {
            Instantiate(target,
                new Vector3(Random.Range(minCord, maxCord), targetHeught, Random.Range(minCord, maxCord)),
                transform.rotation);
        }
    }
}
