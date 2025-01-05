using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public AudioClip addPointsClip;
    public AudioClip turnOffClip;
    public AudioClip brokenClip;
    public AudioClip victoryClip;

    private AudioSource audioSource;
    private int score;
    private bool isScreenDead;
    private bool isHighScoreReached;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }

    public void AddPoints(int points)
    {
        score += points;
        if (!isScreenDead)
        {
            scoreText.text = "Score: " + score;
            if(score < 100)
            {
                audioSource.PlayOneShot(addPointsClip);
            }
            else if(!isHighScoreReached)
            {
                isHighScoreReached = true;
                StartCoroutine(EndingCoroutine());
            }
        }
    }

    private IEnumerator EndingCoroutine()
    {
        audioSource.PlayOneShot(victoryClip);
        yield return new WaitForSeconds(victoryClip.length);
        ExitGame();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (!isScreenDead)
            {
                scoreText.gameObject.SetActive(false);
                audioSource.PlayOneShot(turnOffClip);
                isScreenDead = true;
            }
            else
            {
                audioSource.PlayOneShot(brokenClip);
            }
        }
    }
}
