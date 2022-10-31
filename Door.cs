using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public Transform player;
    public string nextScene;

    public int interactRange = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= interactRange && Input.GetKey(KeyCode.E)){
            print("going to next scene");
            SceneManager.LoadScene(nextScene);
        }
    }
}
