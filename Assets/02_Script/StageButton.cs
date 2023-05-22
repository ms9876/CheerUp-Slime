using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StageButton : MonoBehaviour
{
    public static StageButton instance;
    [SerializeField] GameObject stage02item;
    [SerializeField] GameObject stage03item;
    [SerializeField] GameObject stage04item;

    [SerializeField] private GameObject stagebutton1 = null;
    [SerializeField] private GameObject stagebutton2 = null;
    [SerializeField] private GameObject stagebutton3 = null;
    [SerializeField] private GameObject stagebutton4 = null;
    [SerializeField] private GameObject stagebuttonboss = null;

    int index = 0;

    private RectTransform Panel;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Multiple instance is running");
        }
        instance = this;
        
        index = PlayerPrefs.GetInt("ClearIndex");

        if (index == 0)
        {
            PlayerPrefs.SetInt("stage1", 0);
            PlayerPrefs.SetInt("stage2", 0);
            PlayerPrefs.SetInt("stage3", 0);
            PlayerPrefs.SetInt("stage4", 0);
            PlayerPrefs.SetInt("ClearIndex", 0);
        }

        stagebutton2.GetComponent<Button>().interactable = false;
        stagebutton3.GetComponent<Button>().interactable = false;
        stagebutton4.GetComponent<Button>().interactable = false;
        stagebuttonboss.GetComponent<Button>().interactable = false;
 
        Panel = GameObject.Find("Canvas/Panel").GetComponent<RectTransform>();
        if(PlayerPrefs.GetInt("stage1") == 1)
        {
            stagebutton2.GetComponent<Button>().interactable = true;
            stage02item.SetActive(true);
        }
        if (PlayerPrefs.GetInt("stage2") == 1)
        {
            stagebutton3.GetComponent<Button>().interactable = true;
            stage03item.SetActive(true);
        }
        if (PlayerPrefs.GetInt("stage3") == 1)
        {
            stagebutton4.GetComponent<Button>().interactable = true;
            stage04item.SetActive(true);
        }
        if(PlayerPrefs.GetInt("stage4") == 1)
        {
            stagebuttonboss.GetComponent<Button>().interactable = true;
        }
        
    }

    public void HowToPlay()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(Panel.DOAnchorPosY(-50, 0.5f));
        seq.Append(Panel.DOAnchorPosY(50, 0.6f));
        seq.Append(Panel.DOAnchorPosY(0, 0.3f));
    }

    public void HowToPlayExit()
    {
        Panel.DOAnchorPosY(1000, 0.5f);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            PlayerPrefs.SetInt("stage1", 0);
            PlayerPrefs.SetInt("stage2", 0); 
            PlayerPrefs.SetInt("stage3", 0); 
            PlayerPrefs.SetInt("stage4", 0);
            stagebutton2.GetComponent<Button>().enabled = false;
            stagebutton3.GetComponent<Button>().enabled = false;
            stagebutton4.GetComponent<Button>().enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefs.SetInt("ClearIndex", 0);

            Application.Quit();
        }
    }
}
