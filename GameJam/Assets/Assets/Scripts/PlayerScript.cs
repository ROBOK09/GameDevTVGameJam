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

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        score = 0;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded == true)
            {
                RB.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
            }
        }
        if(isAlive)
        {
            score = Time.time * 4;
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
