using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class trampoline : MonoBehaviour
{
    public Animator trampolineAni;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            trampolineAni.SetTrigger("tram");
          
            Player.HP = Player.HP + 1;
            if (Player.HP > 10)
            {
                Player.HP = 10;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("player"))
            trampolineAni.SetTrigger("tramstop");
    }

    void OnCollisionStay(Collision collision)
    {



    }
}
