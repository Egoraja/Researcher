using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSetting : MonoBehaviour
{
    /// <summary>
    /// Управление противником
    /// </summary>
    [SerializeField] public float HealthLevel;
    [SerializeField] private GameObject playerController;
    [SerializeField] private GameObject audioController;
    [SerializeField] private Button readyToGo;
    [SerializeField] private int powerAttack;
    [SerializeField] private float timer;
    [SerializeField] private GameObject puzzleManager;
    private EnemyAnimController enemyAnim;
    private GameObject player;    
    private float timerAttack;
    private bool isAttack;
    private bool isDead;
    

    private void Start()
    {        
        enemyAnim = GetComponent<EnemyAnimController>();
        timerAttack = timer;
        isAttack = false;
        isDead = false;
    }
   
    private void FixedUpdate()
    {
        CheckIsAlive();
        Attack();
        if (isDead == true)
        {
            DeathBonus();           
        }
    }

    private void CheckIsAlive()
    {
        if (HealthLevel <= 0)        
        {
            isDead = true;                    
        }
    }

    private void DeathBonus()
    {
        enemyAnim.Dead();
        audioController.GetComponent<AudioController>().DeathPlay();
        Destroy(gameObject, 1.5f);
        StartCoroutine(ContinueTimer());      
    }

    public void GotDamage(float Damage)
    {
        HealthLevel = HealthLevel - Damage;
        enemyAnim.GotHit();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.gameObject;
            timerAttack = timer;
            isAttack = true;            
        }        
    }

    private void Attack()
    
    {
        if (HealthLevel > 0 && isAttack == true)
        {
          
            timerAttack -= Time.deltaTime;

            if (timerAttack < 0 && player.GetComponent<PlayerController>().HealthLevel > 0)
            {               
                enemyAnim.Attack();
                player.GetComponent<PlayerController>().GotDamage(powerAttack);
                audioController.GetComponent<AudioController>().KickPlay();
                timerAttack = timer;       
            }
        }       
    }

    private IEnumerator ContinueTimer()
    {
        yield return new WaitForSeconds(1f);
        
        readyToGo.interactable = true;
    }
}
