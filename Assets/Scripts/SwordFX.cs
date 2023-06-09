using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFX : MonoBehaviour
{
    [SerializeField] private GameObject sword;
    [SerializeField] private float fireForce;
    [SerializeField] private Transform SwordFXposition;

    private int attackCount;
    private float attackTimer;
    private void Start()
    {
        attackCount = 5;
        attackTimer = 0.3f;
    }
    public void Shoot()
    {
        //attackTimer -= Time.deltaTime;
        //if (attackTimer < 0 && attackCount > 0)
        //{
            GameObject Sword = Instantiate(sword, SwordFXposition.position, Quaternion.identity);
            Rigidbody2D swordVelocity = Sword.GetComponent<Rigidbody2D>();
            swordVelocity.velocity = new Vector2(fireForce * 1, swordVelocity.velocity.y); 
            attackTimer = 0.3f;
            attackCount -= 1;
            Shoot();
        //}
    }       
}
