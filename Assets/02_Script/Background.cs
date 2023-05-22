using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] Transform target;

    [SerializeField] float scrollSize = 17.8f;
    void Update()
    {
        if (transform.position.x <= -scrollSize)
        {
            transform.position = target.transform.position + Vector3.right * scrollSize;
        }
    }
}
