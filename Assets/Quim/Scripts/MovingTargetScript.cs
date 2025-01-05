using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTargetScript : MonoBehaviour
{
    private int direction = 1;
    private float speed = 0.1f;
    private float iY = -1.65f;
    private float fY = 0;

    void Update()
    {
        if (transform.localPosition.y < iY)
        {
            direction = 1;
        }
        else if (transform.localPosition.y > fY)
        {
            direction = -1;
        }
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + speed * direction * Time.deltaTime, transform.localPosition.z);
    }
}
