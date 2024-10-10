using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 1f;
    public int health = 3;
    public GameObject plat;
    private GameObject rewardPrefab;
    void Start()
    {

    }

    void Update()
    {
        Movement();
        
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
            if (collision.gameObject.CompareTag("dmg1"))
            {
                health--;
                Destroy(collision.gameObject);


                if (health < 0)
                {
                    Debug.Log("bala 1 choca meteorito");
                    Destroy(this.gameObject);
                    Instantiate(plat, doko, Quaternion.identity);
                }

            }

            else if (collision.gameObject.CompareTag("dmg2"))
            {
                health -= 3;
                Destroy(collision.gameObject);

                if (health < 0)
                {
                    Debug.Log("bala 2 choca meteorito");
                    Destroy(this.gameObject);
                    Instantiate(plat, doko, Quaternion.identity);
                }

            }

            else if (collision.gameObject.CompareTag("enemy"))
            {
                Debug.Log("auto choca auto");
                Destroy(collision.gameObject);
                Destroy(this.gameObject);

            }
        }
    }
}