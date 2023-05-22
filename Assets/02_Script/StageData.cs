using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StageData : ScriptableObject
{
    [SerializeField] Vector2 limitMax;
    [SerializeField] Vector2 limitMin;

    public Vector2 LimitMax => limitMax;
    public Vector2 LimitMin => limitMin;
}
