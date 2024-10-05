using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greendrive : enemy
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public override void Movement()
    {
        transform.Translate(new Vector3(Mathf.Sin(Time.time * 20.0f), 1, 0) * speed * Time.deltaTime);
    }
}
