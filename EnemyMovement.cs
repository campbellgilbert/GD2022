using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private Rigidbody rb;
    public Animator animator;
    bool direction = true; //true = right, false = left
    private int speed = 20;

    public Transform player;

    public int MaxAggroDist = 30; //edit distance start chasing
    public int MaxAttackDist = 2;
    public float attackRange = 1.0f;

    //combining enemy combat and enemy movement into one script?
    public Transform attackPoint;
    public int attackDamage = 40;
    public LayerMask enemyLayers;
    public LayerMask myLayer;

    bool attacking = false;

    //public AudioSource audioImpact;
    //public AudioClip impact;

    void Start()
    {
        //initialize rigidbody
        rb = GetComponent<Rigidbody>();
        transform.Rotate(0, 90, 0); //to show in proper direction first
        animator = GetComponent<Animator>(); 
        //audioImpact = GetComponent<AudioSource>();


    }   

     void Update()
    {
        if (animator.GetBool("IsDead")) {
            //if enemy has died
            //play animation, then disappear
            Destroy(gameObject);
        }
        rb.AddForce(Physics.gravity * rb.mass);

        //enemy AI currently very simple
        //can we add jump??

        //if in range
        //enemy.x < player.x -> enemy face right
        //true = right, false = left
        if (Vector3.Distance(transform.position, player.position) <= MaxAggroDist){

            //if within aggro distance but outside of attack distance
            if (Vector3.Distance(transform.position, player.position) > MaxAttackDist) {
                attacking = false;
                if (transform.position.x > player.position.x && direction == false){
                    print("turning left!");
                    transform.Rotate(0, 180, 0);
                    direction = true;
                }
                else if (transform.position.x < player.position.x && direction == true){
                    print("turning right!");
                    transform.Rotate(0, 180, 0);
                    direction = false;
                }
                //move towards player
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                animator.SetBool("Moving", true);

            } else if (Vector3.Distance(transform.position, player.position) <= MaxAttackDist) {
                //if within attacking distance
                //brief pause, then attack and remove player's health
                attacking = true;
                Smack();


            }
        } else {
            //outside of aggro and attack distance
            animator.SetBool("Moving", false);
            attacking = false;
        }

        if (attacking) {
            Smack();
        }
    }

    void Smack() {
        //stop moving
        animator.SetBool("Moving", false);
        //move slightly towards the player
        //play attack animation -- contactdamager will handle the actual attack & SFX
        animator.SetTrigger("Attack");
        print("MONCH");
        //bounce slightly back
        transform.Translate(0, 0, -1);




        //attack opponents in range of attack
        /*
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        //apply damage to those enemies
        foreach (Collider enemy in hitEnemies) {
            //audioImpact.PlayOneShot(impact);
            print("SMACKED: " + enemy.GetComponent<Health>().name);

            enemy.GetComponent<Health>().TakeDamage(attackDamage);
        }*/
        
    }

}