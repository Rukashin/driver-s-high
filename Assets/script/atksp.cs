using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



public class atksp : bullet
{
    public Vector2 direction;
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
        transform.Translate(new Vector3(Mathf.Sin(Time.time * 25.0f), 1, 0) * speed  * Time.deltaTime);
        //transform.Translate(direction * speed * Time.deltaTime);

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
}
