using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Player : MonoBehaviour
{
    Weapon weapon;
    [SerializeField] GameObject clearButton = null;
    [SerializeField] GameObject replayButton = null;
    [SerializeField] public float speed;
    [SerializeField] StageData stageData;
    [SerializeField] float clearScore;
    HP hp;


    [SerializeField] private int score;
    
    public int Score
    {
        set{ score = value; }
        get
        {
            if (score >= clearScore)
            {   
                switch(gameObject.scene.name)
                {
                    case "Stage01":
                        PlayerPrefs.SetInt("stage1", 1);
                        PlayerPrefs.SetInt("ClearIndex", 1);
                        break;
                    case "Stage02":
                        PlayerPrefs.SetInt("stage2", 1);
                        break;
                    case "Stage03":
                        PlayerPrefs.SetInt("stage3", 1);
                        break;
                    case "Stage04":
                        PlayerPrefs.SetInt("stage4", 1);
                        break;
                }
                clearButton.SetActive(true);
                speed = 0;
                GetComponent<Weapon>().enabled = false;
                /*GameObject.Find("EnemySpawner").SetActive(false);*/
                foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    enemy.GetComponent<Movement>().enabled = false;
                }
                return score;

            }
            return score;
        }
    }
    private void Awake()
    {
        weapon = GetComponent<Weapon>();
        hp = GetComponent<HP>();
    }
    private void Update()       
    {
        float x = Input.GetAxisRaw("Horizontal");
        

        Vector3 curpos = transform.position;
        Vector3 nextpos = new Vector3(x, 0, 0) * speed * Time.deltaTime;

        transform.position = curpos + nextpos;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            weapon.StartFiring();
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            weapon.StopFiring();
        }
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
                                         Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y), 0);
    }
}
