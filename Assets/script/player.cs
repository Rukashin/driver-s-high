using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 5.0f;
    public float fireRate = 1.5f;
    public int lives = 2;
    public float canFire = 0.0f;
    public GameObject BulletPref;
    public List<bullet> bullets;



    void Start()
    {

    }



    void Update()
    {
        Movement();
        CheckBoundaries();
        ChangeWeapon();
        //UseShields();
        Fire();
    }


    //-Metodos-//

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);

    }

    void CheckBoundaries()
    {
        var cam = Camera.main;
        float xMax = cam.orthographicSize * cam.aspect;
        if (transform.position.x > xMax)
        {
            transform.position = new Vector3(-xMax, transform.position.y, 0);
        }
        else if (transform.position.x < -xMax)
        {
            transform.position = new Vector3(xMax, transform.position.y, 0);
        }
    }

    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canFire)
        {
            Instantiate(BulletPref, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
            canFire = Time.time + fireRate;
        }
    }

    public void ChangeWeapon()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            BulletPref = bullets[0].gameObject;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            BulletPref = bullets[1].gameObject;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            BulletPref = bullets[2].gameObject;
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("enemy"))
            {
                Destroy(collision.gameObject);
                if (lives > 1)
                {
                    lives--;
                    Debug.Log("Lives: " + lives);

                }
                else
                {
                    lives--;
                    Destroy(this.gameObject);
                }
            }


        }
    }
}
