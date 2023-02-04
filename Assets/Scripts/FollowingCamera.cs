using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField]
    Transform player;

    void Update()
    {
        transform.position = player.transform.position + new Vector3(-1.0f, 0.0f, -5.0f);
    }
}
