using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicFire : MonoBehaviour
{
    Vector3 startPos;
    Vector3 endPos;
    
    void Start()
    {
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        endPos = new Vector3(12.0f, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.Lerp(startPos, endPos, 3.5f * Time.deltaTime);
    }
}
