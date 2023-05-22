using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] StageData stageData;
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] GameObject EnemyPrefab1;
    [SerializeField] float spawnTime;
    [SerializeField] float spawnTime1;
    [SerializeField] int maxEnemy;
    [SerializeField] GameObject boss;

    private void Awake()
    {
        StartCoroutine("SpawnEnemy");
        StartCoroutine("SpawnEnemy1");
    }

    IEnumerator SpawnEnemy()
    {
        int currntEnemy = 0;

        while (true)
        {
            float positionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
            GameObject item = Pooler.Instance.Spawn(EnemyPrefab);
            item.transform.position = new Vector3(positionX, stageData.LimitMax.y + 1.0f, 0.0f);
            item.transform.rotation = Quaternion.identity;
            
            yield return new WaitForSeconds(spawnTime);

            currntEnemy++;
            if(currntEnemy == maxEnemy)
            {
                StartCoroutine("SpawnBoss");
                break;
            }
        }
    }

    IEnumerator SpawnEnemy1()
    {
        while(true)
        {
            int currentEnemy1 = 0;
            float positionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
            GameObject item = Pooler.Instance.Spawn(EnemyPrefab1);
            item.transform.position = new Vector3(positionX, stageData.LimitMax.y + 1.0f, 0.0f);
            item.transform.rotation = Quaternion.identity;

            yield return new WaitForSeconds(spawnTime1);

            currentEnemy1++;
            if (currentEnemy1 == maxEnemy)
            {
                StartCoroutine("SpawnBoss");
                break;
            }
        }
    }

    private IEnumerator SpawnBoss()
    {
        yield return null;
        boss.GetComponent<EnemyBoss>().ChangeState(BossState.MoveToAppearPoint);
    }
}
