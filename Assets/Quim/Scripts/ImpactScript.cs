using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactScript : MonoBehaviour
{
    public GameObject bulletHolePrefab;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if(bulletHolePrefab != null)
            {
                GameObject bulletHole = Instantiate(bulletHolePrefab, collision.transform.position, bulletHolePrefab.transform.rotation, transform);
                /*Vector3 point = collision.contacts[0].point;
                Vector3 dir = -collision.contacts[0].normal;
                point -= dir;
                RaycastHit hitInfo;
                collision.collider.Raycast( new Ray( point, dir ), out hitInfo, 2 );
                Vector3 normal = hitInfo.normal;
                bulletHole.transform.rotation = Quaternion.Euler(normal * 180f);*/
                bulletHole.transform.rotation = transform.rotation;
            }
            Destroy(collision.gameObject);
            Debug.Log("Bullet is destroyed");
        }
        else if (collision.gameObject.CompareTag("Arrow"))
        {
            collision.gameObject.GetComponent<ArrowScript>().FixArrow();
        }
    }
}
