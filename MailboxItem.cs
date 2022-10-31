using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailboxItem : MonoBehaviour
{
    //public Transform player;
    public GameObject playerTest;
    public int interactRange = 10;

    public bool isOpen = false;

    Health playerStats;

    public AudioSource audioSource;
    public AudioClip open;
    
    // Start is called before the first frame update
    void Start()
    {
        playerTest = GameObject.Find("Player");
        playerStats = GetComponent<Health>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (!isOpen && Vector3.Distance(transform.position, player.position) <= interactRange && Input.GetKey(KeyCode.E)){
            isOpen = true;
            //heal 20 hp
            playerStats.currentHealth += 20;
            //open animation and leave open
        }    
        */

        //WORKS !!!
        if (!isOpen && Vector3.Distance(transform.position, playerTest.transform.position) <= interactRange && Input.GetKey(KeyCode.E)){
            isOpen = true;
            //heal 20 hp
            playerTest.GetComponent<Health>().currentHealth += 20;
            Debug.Log("Healed 20");
            audioSource.PlayOneShot(open);
            //open animation and leave open / sound
        }   
        

    }

    
}
