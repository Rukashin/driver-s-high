using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 5.0f;
    void Start()
    {
        
    }

    void Update()
    {
        Movement();
    }

    public virtual void Movement()
    {
        transform.Translate(Vector3.up * 5.0f * Time.deltaTime);
        //var direction = new Vector2(0, 1);
    }
}
