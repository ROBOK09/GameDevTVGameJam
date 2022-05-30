using UnityEngine;

public class MonsterGenerator : MonoBehaviour
{
    public GameObject Monster;
    public float MinSpeed;
    public float MaxSpeed;
    public float currentSpeed;
    public float speedMultipier;

    void Awake()
    {
        currentSpeed = MinSpeed;
        generateMonster();
    }

    public void GenerateNextMonsterWithGap()
    {
        float randomWait = Random.Range(0.1f, 1.2f);
        Invoke("generateMonster", randomWait);
    }
    
    void generateMonster()
    {
        GameObject MonsterIns = Instantiate(Monster, transform.position, transform.rotation);
        MonsterIns.GetComponent<MonsterScript>().monsterGenerator = this;
    }

    void Update()
    {
        if(currentSpeed < MaxSpeed)
        {
            currentSpeed += speedMultipier;
        }
    }
}
