using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class PlayerMovementScript : MonoBehaviour
{
    public float moveSpeed = 5f; //the speed duh

    public Rigidbody2D rb; //player rigid body

    public Animator animator; //reference to the animator

    Vector2 movement;

    public DialgoueManager manager;

    void Start()
    {

    }

    // Update is called once per frame
    void Update() //input
    {
            if (manager.isActive == false)
        {
            animator.SetBool("forcedTransition", false);
            movement.x = Input.GetAxisRaw("Horizontal"); //tells us which horizontal direciton I am planning to face
            movement.y = Input.GetAxisRaw("Vertical");

            //Controls the animation, keep in note while animation is in process
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
        else
        { //supposed to force the character into an idle animation
            animator.SetBool("forcedTransition", true);
            animator.SetFloat("IdleX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("IdleY", Input.GetAxisRaw("Vertical"));
        }

        //idle animations setter
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("IdleX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("IdleY", Input.GetAxisRaw("Vertical"));

        }

    }

    void FixedUpdate() //movement
    {

        if(manager.isActive == false)
        {
           movement.Normalize(); //makes it so that diagonal walk is not faster
           rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); //moves the rigidbody
        }

    }
}
