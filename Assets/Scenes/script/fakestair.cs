using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class fakestair : MonoBehaviour
{
    public Animator fakeAni;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            fakeAni.SetTrigger("fake");

            Player.HP = Player.HP + 1;
            if (Player.HP > 10)
            {
                Player.HP = 10;
            }
            
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
