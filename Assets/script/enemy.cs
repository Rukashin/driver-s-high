using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 1f;
    public int health = 3;
    public GameObject plat;
    public GameObject cranium;
    private GameObject rewardPrefab;
    public gamemanager gamemanager;

    void Start()
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameController").GetComponent<gamemanager>();
    }

    void Update()
    {
        Movement();
        //Debug.Log(gamemanager.time);
    }

    public virtual void Movement()
    {
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 doko = transform.position;
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("plat"))
            {
                health--;
                Destroy(collision.gameObject);


                if (health < 0)
                {
                    //gamemanager.time = gamemanager.time + 5.0f;
                    Debug.Log("bala 1 choca meteorito");
                    Destroy(this.gameObject);
                    Instantiate(plat, doko, Quaternion.identity);
                    gamemanager.time = gamemanager.time + 50.0f;
                }

            }

            else if (collision.gameObject.CompareTag("cranium"))
            {
                health -= 3;
                Destroy(collision.gameObject);

                if (health < 0)
                {
                    Debug.Log("bala 2 choca meteorito");
                    Destroy(this.gameObject);
                    Instantiate(plat, doko, Quaternion.identity);
                    gamemanager.time = gamemanager.time + 50.0f;
                }

            }

            else if (collision.gameObject.CompareTag("enemy"))
            {
                Debug.Log("auto choca auto");
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                Instantiate(cranium, doko, Quaternion.identity);

            }

            else if (collision.gameObject.CompareTag("basura"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}