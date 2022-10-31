using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailboxSpawning : MonoBehaviour
{
    
    public GameObject mailbox;
    private Vector3 spawnPosition;
    public GameObject[] spawnablePlatforms;

    public int startingMailboxes = 7; //mailboxes only spawn at start!


    void Start() 
    {
     
        //create list of spawnable platforms
        //go through each game object, check if name = platform, if so, add to list
        spawnablePlatforms = GameObject.FindGameObjectsWithTag("Platform");
        //put starting enemies into lv
        for (int i = 0; i < startingMailboxes; i++) {
            Spawn();
        }


    }

    void Spawn()
    {
        //selecting where to spawn enemy
        System.Random rand = new System.Random();
        int pick = rand.Next(0, spawnablePlatforms.Length);
        spawnPosition = new Vector3(spawnablePlatforms[pick].transform.position.x, spawnablePlatforms[pick].transform.position.y, 500);
        
        //selecting which type of enemy to spawn
        
        Instantiate(mailbox, spawnPosition, Quaternion.Euler(0, 90, 0));
        //enemyPrefab.transform.Rotate(0, 90, 0);
    }
    
}
