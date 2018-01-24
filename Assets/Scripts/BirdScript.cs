using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour {
    public float jumpForce = 00f;
    private Rigidbody2D rb;
    float forwardSpeed = 2f;
    public GameObject cam;
    public bool dead;
    private float final;
    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        dead = false;
        final = 50f;
       

    }

    // Update is called once per frame
    

    void Update() {
        /*
         * This method inside the update sequence allows us to check if the bird 
         * is still alive or not. If it isn't, then the game ends.
         */
        if (!dead) 
        {
            //This if methos allows the bird to jum based on the updates and FPS. 
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * jumpForce);
            }

            //Allows the bird to move forward.
            transform.Translate(Vector2.right * forwardSpeed * Time.deltaTime);
            
            //Allows the camera to move forward with the bird.
            cam.transform.Translate(Vector2.right * forwardSpeed * Time.deltaTime);

            //Allows the speed to gradually increase. Suggested by classmate. 
            forwardSpeed += Time.deltaTime;
        }

        //Checks if the bird is on the end or not. 
        check();
        
    }

    //Allows to act in case of a collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }


    //Allows to check if the bird has made it all the way through the end
    private void check()
    {
        if(transform.position.x >= final)
        {
            Die();
        }
    }


    //Kills the bird
    private void Die()
    {
        dead = true;
    }



}
