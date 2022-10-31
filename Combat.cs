using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{

    Animator animator;
    public Transform attackPoint;
    public float attackRange;

    public int attackDamage = 40;

    public LayerMask enemyLayers;

    public LayerMask myLayer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); 

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Smack();
        } 

        
    }

    void Smack() {
        //play attack animation
        animator.SetTrigger("Attack");
        //attack opponents in range of attack

        print("Currently playing attack animation");
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        //apply damage to those enemies
        foreach (Collider enemy in hitEnemies) {
            print("SMACKED: " + enemy.GetComponent<Health>().name);
            enemy.GetComponent<Health>().TakeDamage(attackDamage);
            //print("ASMACKABITCH");
        }
        //if currently performing attack animation 
        
        
    }
    
 

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null){
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
