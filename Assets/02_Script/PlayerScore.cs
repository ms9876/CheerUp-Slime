using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] Player player;
    TextMeshProUGUI textScore;

    private void Awake()
    {
        textScore = GetComponent<TextMeshProUGUI>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Update()
    {
        textScore.text = "SCORE " + player.Score;
    }
}
