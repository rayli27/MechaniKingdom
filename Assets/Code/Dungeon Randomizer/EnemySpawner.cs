using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;

    public static int roomHeight = 8;
    public static int roomWidth = 12;

    public int enemyCounter = 0;
    public static int maxEnemies = 8;

    public bool playerInRoom = false;
    // Start is called before the first frame update
    void Start()
    {
        enemyCounter = 0;
        spawnEnemies();
    }

    void spawnEnemies() {
        float randX = Random.Range(transform.position.x - roomWidth, transform.position.x + roomHeight);
        float randY = Random.Range(transform.position.y - roomHeight, transform.position.y + roomHeight);

        Vector3 pos = new Vector3(randX, randY);

        int randEnemy = Random.Range(0,2);

        GameObject enemy = Instantiate(enemies[randEnemy], pos, Quaternion.identity);
        enemyCounter++;

        if (enemyCounter < maxEnemies)
        {
            spawnEnemies();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerInRoom = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
