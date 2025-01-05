using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public Rigidbody rigidBody;
    public SphereCollider sphereCollider;

    public void FixArrow()
    {
        sphereCollider.enabled = false;
        Destroy(rigidBody);
    }
}
