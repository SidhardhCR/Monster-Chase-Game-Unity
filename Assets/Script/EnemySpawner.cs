using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;

    private GameObject spwanedMonsters;

    [SerializeField]
    private Transform rightPos, leftPos;

    private int randomIndex;
    private int randomSide;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonster());
    }

    IEnumerator SpawnMonster()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            spwanedMonsters = Instantiate(monsterReference[randomIndex]);

            if (randomSide == 0)
            {
                spwanedMonsters.transform.position = leftPos.position;
                spwanedMonsters.GetComponent<Monster>().speed = Random.Range(4, 10);
            }
            else
            {
                spwanedMonsters.transform.position = rightPos.position;
                spwanedMonsters.GetComponent<Monster>().speed = -Random.Range(4, 10);
                spwanedMonsters.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }

}
