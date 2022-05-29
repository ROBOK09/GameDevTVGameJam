using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public MonsterGenerator monsterGenerator;

    void Update()
    {
        transform.Translate(Vector2.left * monsterGenerator.currentSpeed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnBecameVisible()
    {
        monsterGenerator.GenerateNextMonsterWithGap();
    }
}
