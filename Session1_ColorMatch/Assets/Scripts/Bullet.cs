using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 0.5f;

    private Vector2 dir;
   
    // Update is called once per frame
    void Update()
    {
        if (dir != null)
        {            
            transform.Translate(dir * bulletSpeed);
        }        
    }

    public void SetDirection(Vector2 currDir,Vector2 canPos)
    { 
        dir = currDir;
        transform.position = canPos;
    }
}

