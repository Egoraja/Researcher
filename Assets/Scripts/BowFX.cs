using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowFX : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private float fireForce;
    [SerializeField] private Transform bowFXposition;

    private int attackCount;
    private float attackTimer;
    private void Start()
    {
        attackCount = 7;
        attackTimer = 0.3f;
    }
    public void Shoot()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer < 0 && attackCount > 0)
        { 
            GameObject newArrow = Instantiate(arrow, bowFXposition.position, Quaternion.identity);
            Rigidbody2D arrowVelocity = newArrow.GetComponent<Rigidbody2D>();    
            arrowVelocity.velocity = new Vector2(fireForce * 1, arrowVelocity.velocity.y);
            attackTimer = 0.3f;
            attackCount -= 1;
            Shoot();
        }              
    }    
}
