using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]float speed = 0.2f;
    [SerializeField]float health = 100;
    [SerializeField]Rigidbody2D rBody;
    Vector3 currMoveDir;
    private void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
       
       rBody.velocity = (transform.up*speed);  
      
    }

    
    public void RotateTowardsPlayer(float angle)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0.0f,0.0f,angle));
    }



}
