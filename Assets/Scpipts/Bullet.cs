using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() == null)
        {
            Target target = other.GetComponent<Target>();
            if (target != null)
            {
                target.Hit();
            }
            Border border = other.GetComponent<Border>();
            if (border != null)
            {
                Destroy(gameObject);
            }
            //Debug.LogFormat("collision from bullet: {0}", other);
            Destroy(gameObject);
        }
    }

    private void TargetHit(Target target)
    {
        target.Hit();
        Debug.LogFormat("collision from bullet: {0}", target);
        Debug.Log("bullet desdtoyed");
    }
}
