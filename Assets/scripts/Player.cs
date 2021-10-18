using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
{
    public float movementSpeed = 10f;
    Rigidbody2D rb;
    public float movement = 1f; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {      
        mobileMove(Input.GetAxis("Horizontal"));  
    }
    private void FixedUpdate() 
    {       
         int i = 0 ;
       
        while(i < Input.touchCount)
        {
            if(Input.GetTouch (i).position.x > Screen.width / 2){
                mobileMove(1f);
            }

            if(Input.GetTouch (i).position.x < Screen.width / 2){
                mobileMove(-1f);
            }
            ++i;
        }      
    }

    private void mobileMove(float horizontalInput)
    {
        Vector2 velocity =rb.velocity;
        velocity.x = horizontalInput*movementSpeed; 
        rb.velocity =velocity;
    }


}
