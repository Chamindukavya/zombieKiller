using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
   
    public FixedJoystick joystick;
    private Animator anim;
    private SpriteRenderer sr;
     public float speed = 5.0f;

     private string WALK_ANIMATION = "walk";

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        walk();
    }

    void walk()
    {
        float horizontal = joystick.Horizontal;
        
        transform.position += new Vector3(horizontal, 0, 0) * Time.deltaTime * speed;
        animatePlayerHorizontal(horizontal);
    }
    
    void animatePlayerHorizontal(float horizontalValue)
    {
        if (horizontalValue != 0)
        {
            if (horizontalValue > 0)
            {
                sr.flipX = false; 
            }
            else if (horizontalValue < 0) 
            {
                sr.flipX = true; 
            }
            anim.SetBool(WALK_ANIMATION, true); 
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }
}
