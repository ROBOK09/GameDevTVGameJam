using System.Collections;
using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public float JumpForce;
    float score;
    [SerializeField]
    bool isGrounded = false;
    bool isAlive = true;
    Rigidbody2D RB;
    public TMP_Text ScoreText;
    public GameObject gameOverPanel;
    [SerializeField] float timeToIncreaseGameSpeed = 1f;
    [SerializeField] float gameSpeedIncreaseMultiplier = 1f;
    private float currentTimeScale = 1f;
    private float initialTimeTime;

    private void Awake()
    {
        initialTimeTime = Time.time;
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
        currentTimeScale = Time.timeScale;
        Debug.Log(currentTimeScale);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded == true)
            {
                RB.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
            }
        }
        if(isAlive)
        {
            score = (Time.time - initialTimeTime) * 4;
            ScoreText.text = "Score : " + (int)score;
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
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
    }
}
