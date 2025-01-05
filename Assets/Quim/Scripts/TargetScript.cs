using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    private GameManager gameManager;
    private AudioSource audioSource;

    public int value;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        audioSource = transform.GetComponentInParent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet")){
            Destroy(collision.gameObject);
            audioSource.Play();
            gameManager.AddPoints(value);
        }
        else if(collision.gameObject.CompareTag("Arrow")){
            collision.gameObject.GetComponent<ArrowScript>().FixArrow();
            audioSource.Play();
            gameManager.AddPoints(value);
        }
    }
}
