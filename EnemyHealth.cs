using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;

        //animator.SetTrigger("Injured");
        animator.SetTrigger("Injured");
        print(name + ": SHMACKED");

        if (currentHealth <= 0) {
            Die();
        }
  
    }

    void Die() {
        Debug.Log("Enemy killed!");
        //show death animation for 1-2 frames, then disappear
        animator.SetBool("IsDead", true);
        Destroy(gameObject, 3);

    }
    // Update is called once per frame
    void Update()
    {

    }
}
