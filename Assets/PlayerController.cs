using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Movement vars")]
    [SerializeField] public int playerPower;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float attackSpeed;
    [SerializeField] public float HealthLevel;

    [Header("Setting")]
    [SerializeField] GameObject youWonPanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] private GameObject audioController;    
    [SerializeField] public Button ReadyToGo;
    [SerializeField] public int BonusCount;


    private PuzzleManager puzzleManager;
    private GameObject enemyobject;   
    private Animator playerAnim;
    private Rigidbody2D playerBody;
    private float timerAttack;
    public bool IsRunning;
    private bool isAttacking;

    
    private void Start()
    {
        playerAnim = GetComponent<Animator>();
        gameOverPanel.SetActive(false);
        youWonPanel.SetActive(false);
        puzzleManager = GetComponent<PuzzleManager>();
        ReadyToGo.interactable = true;
        timerAttack = attackSpeed;        
        playerBody = GetComponent<Rigidbody2D>();
        IsRunning = false;
        isAttacking = false;    
       
    }
    /// <summary>
    /// «апуск движени€ в игре до бо€ и получени€ бонусных пазлов
    /// </summary>
    public void PressReadyToGo()
    {
        IsRunning = true;
        ReadyToGo.interactable = false;
        puzzleManager.AddBonus(BonusCount);
    }
    /// <summary>
    /// ѕолучение информации о столкновении с противником или достижением финиша.
    /// ѕолучение данных противника
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.CompareTag("Enemy"))
        {
            IsRunning = false;
            isAttacking = true;
            enemyobject = collision.gameObject;
            timerAttack = attackSpeed;           
        }
        if (collision.CompareTag("Finish"))
        {
            audioController.GetComponent<AudioController>().PlayerWonPlay();
            youWonPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void FixedUpdate()
    {
        AttackAndRun();
        CheckIsAlive();
    }

    private void PlayerMovement(float Speed)
    {       
        playerBody.velocity = (Vector2.right * Speed);
    }
    /// <summary>
    /// ”слови€ движени€ игрока, атаки
    /// </summary>
    private void AttackAndRun()
    {
        if (IsRunning == true)
        {         
            playerAnim.SetBool("Run", true);
            PlayerMovement(playerSpeed);
            isAttacking = false;            
        }

        if (IsRunning == false)
        {
            playerAnim.SetBool("Run", false);
        }

        if (isAttacking == true && ReadyToGo.interactable == false)
        {
        
            timerAttack -= Time.deltaTime;
            if (timerAttack < 0)
            {
                StartCoroutine(AttackTimer(enemyobject));
                timerAttack = attackSpeed;
            }
        }

    }

    public void GotDamage(int Damage)
    {
        HealthLevel -= Damage;
        playerAnim.SetTrigger("GotHit");
    }

    private void CheckIsAlive()
    {
        if (HealthLevel <= 0)
        {
            playerAnim.SetBool("Death", true);          
            isAttacking = false;
            StartCoroutine(DeathTimer());
        }
    }


    IEnumerator AttackTimer(GameObject Enemy)
    {
        yield return new WaitForSeconds(0.1f);
        playerAnim.SetTrigger("Attack");
        Enemy.GetComponent<HealthSetting>().GotDamage(playerPower);
        audioController.GetComponent<AudioController>().AttackSwordPlay();
        StopAllCoroutines();
    }

    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(3);
        audioController.GetComponent<AudioController>().GameOverPlay();
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        StopAllCoroutines();
    }
}
