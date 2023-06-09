using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{    
    [SerializeField] private AudioSource kickAudio;
    [SerializeField] private AudioSource pickUpAudio;
    [SerializeField] private AudioSource dropAudio;
    [SerializeField] private AudioSource attackSword;
    [SerializeField] private AudioSource attackBow;
    [SerializeField] private AudioSource healthUp;
    [SerializeField] private AudioSource coinCollect;
    [SerializeField] private AudioSource mainTheme;
    [SerializeField] private AudioSource gameProcess;
    [SerializeField] private AudioSource playerWon;
    [SerializeField] private AudioSource gameOver;
    [SerializeField] private AudioSource enemyNear;
    [SerializeField] private AudioSource deathAudio;



    public void Start()
    {
        mainTheme.Play();
    }
    public void GameProcessPlay()
    {
        gameProcess.Play();
    }
    public void KickPlay()
    {
        kickAudio.Play();
    }
    public void PickUpPlay()
    {
        pickUpAudio.Play();   
    }

    public void DropPlay()
    {
        dropAudio.Play();
    }

    public void  AttackSwordPlay()
    {
        attackSword.Play();
    }
    public void AttackBowPlay()
    {
        attackBow.Play();
    }
    public void HealthUpPlay()
    {
        healthUp.Play();
    }
    public void CoinCollectPlay()
    {
        coinCollect.Play();
    }

    public void PlayerWonPlay()
    {
        playerWon.Play();
    }
    public void GameOverPlay()
    {
        gameOver.Play();
    }

    public void DeathPlay()
    {
        deathAudio.Play();
    }
    
}
