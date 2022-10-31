using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamager : MonoBehaviour
{
    public int amount;
    
    public AudioSource audioImpact;
   // public AudioClip impact;

    void Start() {
        audioImpact = GetComponentInParent<AudioSource>();
    }

    void OnTriggerEnter(Collider other) {
        //print("SWING AND A HIT");
        //audioImpact.PlayOneShot(impact);
        audioImpact.Play();
        other.GetComponent<Health>().TakeDamage(amount);
    }
}