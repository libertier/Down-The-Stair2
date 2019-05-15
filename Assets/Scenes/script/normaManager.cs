using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normaManager : MonoBehaviour
{
    public float upSpeed = 1;

    void Start()
    {
        
       
    }

    
    void Update()
    {

        transform.Translate(0, upSpeed * Time.deltaTime, 0);
    }
}
