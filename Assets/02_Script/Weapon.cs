using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] GameObject BulletPrefab1;
    [SerializeField] float attackRate = 0.1f;

    bool isBulletChange = true;

    public void StartFiring()
    {
        StartCoroutine("Attack");
    }

    public void StopFiring()
    {
        StopCoroutine("Attack");
    }

    IEnumerator Attack()
    {
        while(true)
        {
            GameObject bullet;
            if (isBulletChange)
            {
                bullet = BulletPrefab;
                isBulletChange = false;
            }
            else
            {
                bullet = BulletPrefab1;
                isBulletChange = true;
            }

            GameObject item = Pooler.Instance.Spawn(bullet);
            item.transform.position = transform.position;
            yield return new WaitForSeconds(attackRate);
        }
    }
}
