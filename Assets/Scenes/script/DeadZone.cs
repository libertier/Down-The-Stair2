using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            Player.HP = Player.HP - 3;
            if (Player.HP < 0 || Player.HP == 0)
            {
                Player.isDead = true;
                Player.HP = 0;
            }
        }
    }
}
