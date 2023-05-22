using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    private GameObject player = null;
    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            player.GetComponent<Player>();
            Pooler.Instance.DeSpawn(collision.gameObject);
            Pooler.Instance.DeSpawn(gameObject);
        }
    }
}
