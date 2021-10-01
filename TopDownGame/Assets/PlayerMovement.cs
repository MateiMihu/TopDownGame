using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 20f;
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 movement; 
    Vector2 mousePos;
    public float direction;
    public Animator animator;


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        
    }

    void FixedUpdate()
    {   
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x)*Mathf.Rad2Deg+180;
        animator.SetFloat("Speed",1);

        if(angle>225 && angle<315)
            direction = 3;
        
        if(angle>45 && angle<135)
            direction = 1;

        if(angle>135 && angle<225)
            direction = 2;

        if(angle>315 && angle<360){
            direction = 4;
        }
        if(angle>0 && angle<45){
            direction = 4;
        }
        
        animator.SetFloat("angle",direction);
        // rb.rotation = angle;
        rb.MovePosition(rb.position + movement*moveSpeed*Time.fixedDeltaTime);
        
        
    }
    
}
