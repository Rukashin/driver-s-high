using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 5.0f;
    public float verticalspd = 0f;
    public float upspd = 2.0f;
    public float dwnspd = 2.5f;
    public float revrsspd = 3.0f;
    public float fireRate = 1.5f;
    public int lives = 2;
    public float canFire = 0.0f;
    public GameObject BulletPref;
    public List<bullet> bullets;
    public int platns = 10;
    public int theCranium = 3;
    public int lulos = 1;
    public int spatk = 1;
    public float turbo;
    public float tiempo;
    public float score = 0;
    public audiomanager audioManager;
    public AudioSource actualAudio;
    public int actualWeapon = 0;



    void Start()
    {

    }



    void Update()
    {
        Movement2();
        CheckBoundaries();
        ChangeWeapon();
        //UseShields();
        Fire();
        score += Time.deltaTime * 15;

    }


    //-Metodos-//

    /*
    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);

    }
    */

    void Movement2()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Movimiento vertical constante
        transform.Translate(Vector3.up * verticalspd * Time.deltaTime);

        if (verticalInput > 0) // Movimiento hacia arriba
        {
            transform.Translate(Vector3.up * upspd * verticalInput * Time.deltaTime);
        }
        else if (verticalInput < 0) // Movimiento hacia abajo
        {
            transform.Translate(Vector3.down * dwnspd * -verticalInput * Time.deltaTime);
        }
        // Verificar si el botón de acelerar es presionado
        if ((Input.GetKey(KeyCode.O)) && (turbo > 0)) // Cambia 'Space' si deseas otro botón
        {
            turbo -= Time.deltaTime * 3;
            transform.Translate(Vector3.down * revrsspd * Time.deltaTime);
            if (turbo == 0)
            {
                return;
            }
        }
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
    }

    void CheckBoundaries()
    {
        var cam = Camera.main;
        float xMax = cam.orthographicSize * cam.aspect;
        if (transform.position.x > xMax)
        {
            transform.position = new Vector3(-xMax+3, transform.position.y, 0);

        }
        else if (transform.position.x < -xMax+3)
        {
            transform.position = new Vector3(xMax, transform.position.y, 0);
        }
    }

    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canFire)
        {
            //Instantiate(BulletPref, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
            //canFire = Time.time + fireRate;

            switch(BulletPref.name)
            {
                
                case "bullet1":
                    if (platns > 1)
                    {
                        Instantiate(BulletPref, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
                        canFire = Time.time + fireRate;
                        platns -= 1;
                        actualAudio.Play();

                    }
                    break;
                case "energiabola":
                    if (lulos > 0)
                    {
                        var bullet1 = Instantiate(BulletPref, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
                        bullet1.GetComponent<energiabola>().direction = new Vector2(0, 1);
                        var bullet2 = Instantiate(BulletPref, transform.position + new Vector3(0.5f, 0.8f, 0), Quaternion.identity);
                        bullet2.GetComponent<energiabola>().direction = new Vector2(0.5f, 1);
                        var bullet3 = Instantiate(BulletPref, transform.position + new Vector3(-0.5f, 0.8f, 0), Quaternion.identity);
                        bullet3.GetComponent<energiabola>().direction = new Vector2(-0.5f, 1);
                        canFire = Time.time + fireRate;
                        lulos--;
                        actualAudio.Play();
                    }
                    break;
                case "cranium":
                    if (theCranium > 0)
                    {
                        Instantiate(BulletPref, transform.position + new Vector3(0, -0.8f, 0), Quaternion.identity);
                        canFire = Time.time + fireRate;
                        theCranium -= 1;
                        actualAudio.Play();
                    }

                    break;
                case "espatk":
                    if (spatk > 0)
                    {
                        Instantiate(BulletPref, transform.position + new Vector3(0, -0.8f, 0), Quaternion.identity);
                        canFire = Time.time + fireRate;
                        spatk -= 1;
                        actualAudio.Play();
                    }

                    break;
            }
        }

    }

    public void ChangeWeapon()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            BulletPref = bullets[0].gameObject;
            actualWeapon = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            BulletPref = bullets[1].gameObject;
            actualWeapon = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            BulletPref = bullets[2].gameObject;
            actualWeapon = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            BulletPref = bullets[3].gameObject;
            actualWeapon = 3;
        }
    }


    public void MasLulos()
    {
        if (platns > 20)
        {
            lulos++;
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

            else if (collision.gameObject.CompareTag("platano"))
            {
                platns = platns + 5;
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.CompareTag("cranium"))
            {
                theCranium ++;
                Destroy(collision.gameObject);

            }

            else if (collision.gameObject.CompareTag("camaron"))
            {
                turbo = turbo + 10f;
                Destroy(collision.gameObject);

            }
            else if (collision.gameObject.CompareTag("basura"))
            {
                Destroy(this.gameObject);
            }


        }
    }

    void OnTriggerEnter2D(Collider2D cosita)
    {
        if (cosita.gameObject.CompareTag("desacelerador"))
        {
            transform.Translate(Vector3.up * upspd * 25 * Time.deltaTime);
        }
    }
}
