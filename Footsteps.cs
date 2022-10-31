using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    Rigidbody rb;
    public AudioSource audioSource;
    public bool isMoving = false;
    PlayerMovement playerStats;

    public AudioClip steps;
    
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerMovement>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //if is grounded and have movement input
        if (playerStats.grounded == true && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))){
            isMoving = true;
        }
        else{
            isMoving = false;
        }

        if (isMoving && !audioSource.isPlaying){
            audioSource.PlayOneShot(steps);
        }
    }
}
