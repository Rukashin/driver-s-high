using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class cranium : bullet
{
    private float tiempo = 1;

    // Update is called once per frame
    void Update()
    {
        Movement();
        //CheckBoundaries();
    }

    public override void Movement()
    {
        transform.Translate(new Vector3(-1, 0.25f, 0) * speed * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
            Debug.Log("Collided with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("enemy"))
        {
            //gamemanager.AddScore(10);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

    void CheckBoundaries()
    {
        var cam = Camera.main;
        float xMax = cam.orthographicSize * cam.aspect;
        if (transform.position.x > xMax)
        {
            transform.position = new Vector3(-xMax + 3, transform.position.y, 0);

        }
        else if (transform.position.x < -xMax + 3)
        {
            transform.position = new Vector3(xMax, transform.position.y, 0);
            Debug.Log(tiempo);
            tiempo -= Time.deltaTime;
            if (tiempo < 0.00f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
