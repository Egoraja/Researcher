using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimController : MonoBehaviour
{
    private Animator enemyAnim;
    [SerializeField] GameObject audioController;

    private void Start()
    {
        enemyAnim = GetComponent<Animator>();
        audioController.GetComponent<AudioController>();
    }
      
    public void GotHit()
    {
        enemyAnim.SetTrigger("Hit");

    }

    public void Dead()
    {
        enemyAnim.SetBool("Die", true);
    }

    public void Attack()
    {
        enemyAnim.SetTrigger("Attack");    
    }
}
