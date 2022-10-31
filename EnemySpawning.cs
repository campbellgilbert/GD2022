using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject humanoidEnemy;
    public GameObject dogEnemy;
    private Vector3 spawnPosition;
    public GameObject[] spawnablePlatforms;

    public int numStartingEnemies = 5; //enemies that will be on the stage to begin with


    //for level 1: starting in 1 second, an enemy will be spawned every 3 seconds


    public float startTime = 10.0f;
    //public float endTime;
    public float spawnRate = 10.0f;

    void Start() 
    {
        spawnablePlatforms = GameObject.FindGameObjectsWithTag("Platform");
        
        //put starting enemies into lv
        for (int i = 0; i < numStartingEnemies; i++) {
            Spawn();
        }

        InvokeRepeating("Spawn", startTime, spawnRate);
        //spawn in random, spawnable location 
        //InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        //selecting where to spawn enemy
        System.Random rand = new System.Random();
        int pick = rand.Next(0, spawnablePlatforms.Length);
        spawnPosition = new Vector3(spawnablePlatforms[pick].transform.position.x, spawnablePlatforms[pick].transform.position.y, 500);
        
        //selecting which type of enemy to spawn
        GameObject enemyPrefab = humanoidEnemy;
        int whichEnemy = rand.Next(0, 2);

        if (whichEnemy == 0)
        {
            //slightly higher chance for human than dog enemy
            enemyPrefab = dogEnemy;
        }
        Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(0, 180, 0));
        //enemyPrefab.transform.Rotate(0, 90, 0);
    }
    
}
    

