using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState { MoveToAppearPoint = 0, Phase01 }
public class EnemyBoss : MonoBehaviour
{
    [SerializeField] float bossAppearPoint = 2.5f;
    BossState bossState = BossState.MoveToAppearPoint;
    Movement movement;
    BossWeapon bossWeapon;

    void Awake()
    {
        movement = GetComponent<Movement>();
        bossWeapon = GetComponent<BossWeapon>();
    }

    public void ChangeState(BossState newstate)
    {
        StopCoroutine(bossState.ToString());
        bossState = newstate;
        StartCoroutine(bossState.ToString());
    }

    IEnumerator MoveToAppearPoint()
    {
        movement.MoveTo(Vector3.down);

        while (true)
        {
            if(transform.position.y <= bossAppearPoint)
            {
                movement.MoveTo(Vector3.zero);
                ChangeState(BossState.Phase01);
            }

            yield return null;
        }
    }

    IEnumerator Phase01()
    {
        bossWeapon.StartFiring(AttackType.CircleFire);
        yield return new WaitForSeconds(1);
    }
}
