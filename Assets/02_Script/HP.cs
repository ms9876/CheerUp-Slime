using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField] GameObject replayButton = null;
    Player player;
    [SerializeField] float maxHP;
    [SerializeField] public float currentHP;
    private void Awake()
    {
        player = GetComponent<Player>();  
        currentHP = maxHP;
    }

    public void TakeDamge(float damge)
    {
        currentHP -= damge;

        if (currentHP <= 0)
        {
            Debug.Log("Die");
            replayButton.SetActive(true);
            player.speed = 0;
            GetComponent<Weapon>().enabled = false;
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                enemy.GetComponent<Movement>().enabled = false;
            }

        }
    }
}
