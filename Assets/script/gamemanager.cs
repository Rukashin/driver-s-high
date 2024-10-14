using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using UnityEngine.UIElements;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class gamemanager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public GameObject turbo;
    public float time = 60.0f;
    public float spawnTime = 1.0f;
    public float enemyTime = 1.0f;
    public player player;
    public TextMeshProUGUI platanosText;
    //public TextMeshProUGUI theCraniumText;
    public TextMeshProUGUI Turbo;
    public TextMeshProUGUI Tiempo;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Vidas;
    public audiomanager audioManager;
    public AudioSource actualAudio;

    //[Header("UI")]
    public Image platimg;
    //public TextMeshProUGUI platanos;
    public List<Sprite> bulletsprites;

    public GameObject camaronvidas; // Prefab del icono de vida
    public Transform panelvidas; // Panel donde se mostrarán los iconos de vida
    //public int playerLives = 4; // Número de vidas del jugador
    private List<GameObject> iconovidas = new List<GameObject>();

    private Vector3[] spawnpositions = new Vector3[]
    {
        new Vector3(-2.37f, -5.0f, 0), // spots = 1
        new Vector3(-0.79f, -5.0f, 0), // spots = 2
        new Vector3(0.78f, -5.0f, 0), // spots = 3
        new Vector3(2.34f, -5.0f, 0),  // spots = 4
        new Vector3(3.97f, -5.0f, 0),  // spots = 5
        new Vector3(5.51f, -5.0f, 0)   // spots = 6
    };


    void Start()
    {
        UpdateLifeIcons();
    }


    void Update()
    {
        CreateEnemy();
        UpdateCanvas();
        time -= Time.deltaTime;
        TimeUp();
        Dificultad();
        ChangeBulletImage(player.actualWeapon);
    }


    void Dificultad()
    {
        if ((player.score > 500.0f)&&(spawnTime > 5.0f))
        {
            spawnTime--;
            Debug.Log("dificultad");
        }

        else if ((player.score > 3000.0f) && (spawnTime > 4.0f))
        {
            spawnTime--;
            Debug.Log("dificultad");
        }
    }
    void UpdateCanvas()
    {
        //Debug.Log(player.platns);
        platanosText.text = "X " + player.platns;
        //theCraniumText.text = "X " + player.theCranium;
        Turbo.text = player.turbo.ToString("F1");
        Tiempo.text = "T " + time.ToString("F1");
        Score.text = player.score.ToString("F0");
        Vidas.text = "Vidas " + player.lives.ToString();
    }


    public void ChangeBulletImage(int index)
    {
        //Debug.Log("ChangeBulletImage: " + index);
        platimg.sprite = bulletsprites[index];
        if (index == 0) 
            {
                platanosText.text = "X " + player.platns; 
            }
        else if (index == 1)
            {
                platanosText.text = "X " + player.theCranium; 
            }
        else if (index == 2)
        {
            platanosText.text = "X " + player.lulos; 
        }
        else if (index == 3) 
        {
            platanosText.text = "X " + player.spatk; 
        }
    }


    private void CreateEnemy()
    {
        enemyTime += Time.deltaTime;

        int dado = 1 + Random.Range(0, 6);  
        int spots = Random.Range(0, 6); // spots de 1 a 6
        Vector3 spawnposition = spawnpositions[spots]; // Resta 1 porque el array empieza en 0

        if ((dado < 2) && (enemyTime > spawnTime))
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnposition, Quaternion.identity);
            enemy.GetComponent<enemy>().gamemanager = this;
            //Instantiate(enemyPrefab, spawnposition, Quaternion.identity);
            Instantiate(turbo, spawnposition, Quaternion.identity);

            enemyTime = 0.0f;
        }
        else if ((dado > 2) && (dado < 6) && (enemyTime > spawnTime))
        {
            Debug.Log(dado);
            GameObject enemy = Instantiate(enemyPrefab2, spawnposition, Quaternion.identity);
            enemy.GetComponent<enemy>().gamemanager = this;
            //Instantiate(enemyPrefab2, spawnposition, Quaternion.identity);
            enemyTime = 0.0f;
        }
        else if ((dado > 4) && (enemyTime > spawnTime))
        {
            Debug.Log(dado);
            GameObject enemy = Instantiate(enemyPrefab3, spawnposition, Quaternion.identity);
            enemy.GetComponent<enemy>().gamemanager = this;
            //Instantiate(enemyPrefab3, spawnposition, Quaternion.identity);
            enemyTime = 0.0f;
        }
    }

    private void TimeUp()
    {
        if (time > 15.1f)
        {
            //Debug.Log("owo");
            gameObject.GetComponent<AudioSource>().enabled = false;

        }

        else if (time >= 0.01 && time <= 15.0)
        {
            //Debug.Log("uwu");
            gameObject.GetComponent<AudioSource>().enabled = true;
            //actualAudio.Play();

        }

        else if (time < 00.0f)
        {
            Debug.Log("uwu");
            SceneManager.LoadScene(0);
        }

        else if (player.lives < 0)
        {
            SceneManager.LoadScene(0);
        }

    }


    public void UpdateLifeIcons()
    {

        // Limpia el panel de vidas
        foreach (Transform child in panelvidas)
        {
            Destroy(child.gameObject);
        }

        // Crea la cantidad de iconos de vida según el número de vidas del jugador
        for (int i = 0; i < player.lives; i++) // Cambia 'lives' por el nombre de la variable que almacena las vidas del jugador
        {
            Instantiate(camaronvidas, panelvidas);
            Debug.Log(player.lives);
        }
    }


}





 