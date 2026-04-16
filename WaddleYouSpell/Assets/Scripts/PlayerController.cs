using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{


    private bool canJump;
    private bool canSlide;
    public float jumpVelocity;
    private Rigidbody2D rb;
    private float lastJumpTime;
    private float lastSlideTime;
    private float elapsedJumpTime;
    private float elapsedSlideTime;
    private bool isRotationFixed;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canJump = true;
        canSlide = true;
        isRotationFixed = false;


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Vertical") > 0 && canJump)
        {
            rb.velocity = Vector2.up * jumpVelocity;
            canJump = false;
            lastJumpTime = Time.time;
        }
        if(Input.GetAxis("Vertical") < 0 && canSlide)
        {
            rb.SetRotation(90);
            canSlide = false;
            isRotationFixed = false;
            lastSlideTime = Time.time;
        }

        elapsedJumpTime = Time.time - lastJumpTime;
        elapsedSlideTime = Time.time - lastSlideTime;

        if (elapsedJumpTime > 1) canJump = true;
        if (elapsedSlideTime > 1 && !isRotationFixed) {
            rb.SetRotation(0);
            isRotationFixed = true;
        }
        if (elapsedSlideTime > 2) canSlide = true;
        

    }
}
