using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            Player.HP = Player.HP +1;
            if (Player.HP > 10)
            {
                Player.HP = 10;
            }
        }
    }
}
