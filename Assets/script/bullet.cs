using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        transform.Translate(Vector3.up * 5.0f * Time.deltaTime);
    }
}
