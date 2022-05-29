using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public MonsterGenerator monsterGenerator;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * monsterGenerator.currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("nextLine"))
        {
            monsterGenerator.GenerateNextMonsterWithGap();
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }
    }
}
