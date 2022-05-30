using System.Collections;
using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float timeToIncreaseGameSpeed = 1f;
    [SerializeField] float gameSpeedIncreaseMultiplier = 1f;
    [SerializeField] AudioClip jumpSFX;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] AudioSource backgroundSFX;

    public float JumpForce;
    public TMP_Text ScoreText;
    public GameObject gameOverPanel;

    private float currentTimeScale = 1f;
    private float initialTime;
    private float score;
    private bool isGrounded = false;
    private bool isAlive = true;
    private Rigidbody2D RB;

    private void Awake()
    {
        initialTime = Time.time;
        RB = GetComponent<Rigidbody2D>();
        score = 0;
        Time.timeScale = 1;
        StartCoroutine(IncreaseGameSpeedOverTime());
    }

    private IEnumerator IncreaseGameSpeedOverTime()
    {
        while (true)
        {
            Time.timeScale += gameSpeedIncreaseMultiplier;
            yield return new WaitForSeconds(timeToIncreaseGameSpeed);
        }
    }

    public void StopOrResumeTime(bool toggleStopping)
    {
        if (toggleStopping)
        {
            currentTimeScale = Time.timeScale;
            Time.timeScale = 0f;
            StopCoroutine(IncreaseGameSpeedOverTime());
        }
        else
        {
            Time.timeScale = currentTimeScale;
            StartCoroutine(IncreaseGameSpeedOverTime());
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded == true)
            {
                isGrounded = false;
                backgroundSFX.PlayOneShot(jumpSFX);
                RB.AddForce(Vector2.up * JumpForce);
            }
        }
        if(isAlive)
        {
            score = (Time.time - initialTime) * 4;
            ScoreText.text = "Score - " + (int)score;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            if(isGrounded == false)
            {
                isGrounded = true;
            }
        }
        if (collision.gameObject.CompareTag("Monster"))
        {
            isAlive = false;
            backgroundSFX.clip = null;
            backgroundSFX.PlayOneShot(deathSFX);
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
    }
}
