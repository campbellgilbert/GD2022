using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update() 
    {
        //print("Current health of " + this.name + ": " + currentHealth);
        if (currentHealth <= 0) {
            //print("O NOES");
            Die();
        }
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;

        //animator.SetTrigger("Injured");
        animator.SetTrigger("Injured");
        //print("THAT HURTED :(");
  
    }

    void Die() {
        Debug.Log("Enemy killed!");
        //show death animation for 1-2 frames, then disappear
        animator.SetBool("IsDead", true);
        Destroy(gameObject, 0.5f);
        //GetComponent<Collider>().enabled = false;
        //this.enabled = false;
        //Destroy(this);

    }
}
