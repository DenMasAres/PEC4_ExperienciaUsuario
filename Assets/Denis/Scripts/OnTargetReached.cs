using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTargetReached : MonoBehaviour
{
    public float threshold = 0.02f;
    public Transform target;
    public UnityEvent onReached;
    private bool wasReached = false;

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if(distance < threshold && !wasReached)
        {
            wasReached = true;
            onReached.Invoke();
        }
        else if (distance >= threshold)
        {
            wasReached = false;
        }
    }
}
