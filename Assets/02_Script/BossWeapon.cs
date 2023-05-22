using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AttackType { CircleFire = 0, }
public class BossWeapon : MonoBehaviour
{
    [SerializeField] GameObject bossBulletPrefab;

    public void StartFiring(AttackType attackType)
    {
        StartCoroutine(attackType.ToString());
    }

    public void StopFiring(AttackType attackType)
    {
        StopCoroutine(attackType.ToString());
    }

    IEnumerator CircleFire()
    {
        float attackRate = 0.5f;
        int count = 30;
        float intervalAngle = 360 / count;
        float weightAngle = 0;

        while(true)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject item = Pooler.Instance.Spawn(bossBulletPrefab);
                item.transform.position = transform.position;
                float angle = weightAngle + intervalAngle * i;
                float x = Mathf.Cos(angle * Mathf.PI / 180.0f);
                float y = Mathf.Sin(angle * Mathf.PI / 180.0f);
                item.GetComponent<Movement>().MoveTo(new Vector2(x, y));
            }

            weightAngle += 1;

            yield return new WaitForSeconds(attackRate);
        }
    }

}
