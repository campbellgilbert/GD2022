using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //character stats
    private int speed = 20;
    private Rigidbody rb;
    private float jumpForce = 9.0f;
    public int jumps = 0;

    //interaction with extra jump powerup to increase jumpsMax
    int maxJumps = 1;
    bool direction = true; //true = face right / false = face left
    
    Animator animator; 

    Vector3 jump;
    public bool grounded = true;
    public AudioSource audioSource;
    public AudioClip steps;

    void Start()
    {
        print("Initializing...");
        //initialize rigidbody
        rb = GetComponent<Rigidbody>();
        transform.Rotate(0, 90, 0); //to show in proper direction first
        //Character mailman = new Character();

        jump = new Vector3(0.0f, 14.0f, 0.0f); 
        animator = GetComponent<Animator>(); 

        //audioSource = GetComponent<AudioSource>();

    }   

    //froze rotation in player rigidbody so does not tilt unintentionally
    void Update()
    {
        rb.AddForce(Physics.gravity * 5 * rb.mass);

        if (Input.GetMouseButtonDown(0)) {
            animator.SetTrigger("Attack");
        } 

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            //print("Moving left");
            animator.SetBool("Moving", true);
            if (direction == false) {
                direction = true;
                transform.Rotate(0, 180, 0);
            }
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            //print("Moving right");
            animator.SetBool("Moving", true);
            if (direction == true){
                direction = false;
                transform.Rotate(0, 180, 0);
            }
            transform.Translate(0, 0, speed * Time.deltaTime);
        } 
        else {
            //print("not moving");
            animator.SetBool("Moving", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded) {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            rb.AddForce(Vector3.up * jumpForce * 3);
            grounded = false;
            animator.SetBool("Jumping", true);
            animator.SetBool("Grounded", false);
        } else {
            animator.SetBool("Jumping", false);
        }

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Platform") {
            animator.SetBool("Grounded", true);
            grounded = true;
        }
        
    }
    
    //collision with ground / enemy resets jumps
    //touching ground resets jumps
    void OnTriggerEnter(Collider other){
        if (other.gameObject.name == "Ground"){
            jumps = 0;
        }
        
    }
    //first jump is when not on platform, so second jump is off platform
    void OnTriggerExit(Collider other){
        if (other.gameObject.name == "Ground"){
            jumps = maxJumps;
        }
    }


}