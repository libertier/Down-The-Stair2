using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public static bool isDead;  
    Rigidbody2D playerRigidBody2D;
    public Animator playerAni;
    public SpriteRenderer playerSr;


    
    public static int HP =10;


    void Start()
    {
        isDead = false;
        playerRigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        bool isWalking = false;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (playerSr.flipX == true)
            {
                playerSr.flipX = false;
            }
            this.gameObject.transform.position += new Vector3(-0.03f, 0, 0);
            isWalking = true;
            playerAni.SetInteger("status", 1);
            //directionX = toLeft;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (playerSr.flipX == false)
            {
                playerSr.flipX = true;
            }

            this.gameObject.transform.position += new Vector3(0.03f, 0, 0);
            isWalking = true;
            playerAni.SetInteger("status", 1);
            //directionX = toRight;
        }
        if (isWalking)
        {
            if (playerAni.GetInteger("status") == 0)

                playerAni.SetInteger("status", 1);

        }
        else
        {
            if (playerAni.GetInteger("status") == 1)

                playerAni.SetInteger("status", 0);

        }
    }
    
    




    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("conveyor_right"))
        {
            this.gameObject.transform.position += new Vector3(0.02f, 0, 0);
            
        }
        if (other.gameObject.CompareTag("conveyor_left"))
        {
            this.gameObject.transform.position += new Vector3(-0.02f, 0, 0);

        }
        if (other.gameObject.CompareTag("trampoline"))
        {
            playerRigidBody2D.AddForce(new Vector2(0, 15), ForceMode2D.Impulse);

        }
    }
}
