using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 5.0f;
    private player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("enemy"))
            {
                player.score = player.score + 100;

            }

            else if (collision.gameObject.CompareTag("basura"))
            {
                Destroy(this.gameObject);
            }


        }
    }
}
