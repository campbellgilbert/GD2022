using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSpawning : MonoBehaviour
{
    public GameObject door;
    private Vector3 spawnPosition;
    public GameObject[] spawnablePlatforms;

    void Start() 
    {

        GameObject platform = spawnablePlatforms[0];
        System.Random rand = new System.Random();

        int spawnPoint = rand.Next(0, 500);

        spawnPosition = new Vector3(spawnPoint, platform.transform.position.y, 500);

        Instantiate(door, spawnPosition, Quaternion.Euler(0, 90, 0));
        print("spawned door!");

        /*int pick = rand.Next(0, spawnablePlatforms.Length);
        //pick a random spot ON that platform
        GameObject pickedPlatform = spawnablePlatforms[pick];

        Vector3 objectSize = pickedPlatform.GetComponent<Collider>().bounds.size;
        int objPos = (int)pickedPlatform.transform.position.x;
        Debug.Log(objectSize.x);
        int spawnPoint = rand.Next(0, (int)objectSize.x) + objPos;

        print("spawnPoint" + spawnPoint);
        
        */


        //spawn in random, spawnable location 
        //InvokeRepeating("Spawn", spawnTime, spawnTime);
    }
    
}
    

