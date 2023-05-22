using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [SerializeField] private Text stage1Text = null;
    private void Awake()
    {
        stage1Text.gameObject.SetActive(false);
    }
    private void Start()
    {
        StartCoroutine(stageTextEffect());
    }
    private IEnumerator stageTextEffect()
    {
        stage1Text.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        stage1Text.gameObject.SetActive(false);
    }
}
