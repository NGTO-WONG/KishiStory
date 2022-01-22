using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Transform target;
    Vector3 offsetV3;

    // Start is called before the first frame update
    void Start()
    {
        offsetV3 = target.position - transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offsetV3;
    }
}
