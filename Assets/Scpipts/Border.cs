using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Debug.LogFormat("collision from border: {0}", other);
        Destroy(other.gameObject);
    }
}
