using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    Transform startPos;
    [SerializeField]
    Transform endPos;
    [SerializeField]
    float speed;

    float delta;
    // Start is called before the first frame update
    void Start()
    {
        delta = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (1 - delta) * startPos.position + delta * endPos.position;

        delta = Mathf.Cos(Time.time * speed) * 0.5f + 0.5f;
    }
}
