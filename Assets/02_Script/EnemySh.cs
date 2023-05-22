using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySh : MonoBehaviour
{
    [SerializeField] GameObject enemyBullet;
    void Start()
    {
        StartCoroutine(EnemyBullet());
    }

    IEnumerator EnemyBullet()
    {
        Instantiate(enemyBullet, transform.position, transform.rotation);
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(EnemyBullet());
    }
}
