using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class gamemanager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public float spawnTime = 1.0f;
    public float enemyTime = 1.0f;
    public float spawnRadius = 1.0f;
    public player player;
    public LayerMask collisionMask;

    void Start()
    {

    }


    void Update()
    {
        CreateEnemy();
        //UpdateCanvas();
        //ChangeBulletImage(player.actualWeapon);
    }

    private void CreateEnemy()
        {

        enemyTime += Time.deltaTime;

        int enemigos = 1 + Random.Range(0, 6);
        if ((enemigos < 5) && (enemyTime > spawnTime))
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-6.0f, 6.0f), -5.0f, 0), Quaternion.identity);
            Vector3 desiredspot = enemyPrefab.transform.position;
            //CheckCan(desiredspot);
            enemyTime = 0.0f;
        }

        else if ((enemigos > 4) && (enemigos < 6) && (enemyTime > spawnTime))
        {
            Debug.Log(enemigos);
            Instantiate(enemyPrefab2, new Vector3(Random.Range(-6.0f, 6.0f), -5.0f, 0), Quaternion.identity);
            enemyTime = 0.0f;
        }


        else if ((enemigos == 6) && (enemyTime > spawnTime))
        {
            Debug.Log(enemigos);
            Instantiate(enemyPrefab3, new Vector3(Random.Range(-6.0f, 6.0f), -5.0f, 0), Quaternion.identity);
            enemyTime = 0.0f;
        }

        }


    /*
    private void CreateEnemy2()
        {
        enemyTime += Time.deltaTime;
        int enemigos = 1 + Random.Range(0, 6);

        // Genera una posición aleatoria en el eje X
        Vector3 spawnPosition = new Vector3(Random.Range(-7.0f, 7.0f), -5.0f, 0);

        // Verifica si el espacio está libre antes de instanciar el enemigo
        if (enemyTime > spawnTime && IsSpaceFree(spawnPosition, spawnRadius))
        {
            if (enemigos < 5)
            {
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }
            else if (enemigos > 4 && enemigos < 6)
            {
                Instantiate(enemyPrefab2, spawnPosition, Quaternion.identity);
            }
            else if (enemigos == 6)
            {
                Instantiate(enemyPrefab3, spawnPosition, Quaternion.identity);
            }

            enemyTime = 0.0f;  // Resetea el tiempo para el siguiente spawn
        }
    */

    /*
    [Header("UI")]
    public Image bulletImage;
    public List<Sprite> bulletSprites;
    public void ChangeBulletImage(int index)
    {
        Debug.Log("ChangeBulletImage: " + index);
        ChangeBulletImage().sprite = bulletSprites[index];
    }
    */

    /*
    private bool IsSpaceFree(Vector3 position, float radius)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, radius, collisionMask);
        return colliders.Length == 0;  // Retorna true si no hay colisiones
    }

    // Para visualizar el área de verificación en la escena
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(Random.Range(-7.0f, 7.0f), -5.0f, 0), spawnRadius);
    }
    */

    private void CheckCan(Vector3 desiredspot)
    {
        int maxattempts = 10;
        float spawnradius = 0.05f;
        Vector3 spot = desiredspot;
        for (int attempts = 0; attempts < maxattempts; attempts++)
        {
            Collider[] colliders = Physics.OverlapSphere(spot, spawnradius);

            if (colliders.Length == 0)
            {
                Instantiate(enemyPrefab, spot, Quaternion.identity);
                Debug.Log("Enemigo apareció en: " + spot);
                return;
            }

            spot = new Vector3(Random.Range(-7.0f, 7.0f), -4.0f, 0);
        }
        
        Debug.Log("Failed to find a valid spawn after" + maxattempts + "attempts");
    }
}
