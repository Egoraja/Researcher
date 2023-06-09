using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellsController : MonoBehaviour
{
    [SerializeField] private AudioController audioController;
    [SerializeField] private Button swordAttackButton;
    [SerializeField] private Button bowAttackButton;
    [SerializeField] private Button potionButton;
    [SerializeField] private Text swordCountText;
    [SerializeField] private Text bowCountText;
    [SerializeField] private Text potionCountText;
    [SerializeField] private Text goldCountText;
    [SerializeField] private Text hPPEnemyText;
    [SerializeField] private Text hPPlayerText;
    [SerializeField] private Text bowPowerInfoText;
    [SerializeField] private Text swordPowerdInfoText;
    [SerializeField] private Text potionPowerInfoText;
    [SerializeField] private Image hPPlayerImg; 
    [SerializeField] private Image hPPEnemyImg;   

    private PlayerController playerController;    
    private GameObject enemyObject;
     
    private bool enemyInfo;   
    private float currentHealthPlayer;
    private float curentHealthEnemy;

    private float potionFXAdd;
    private float bowFXAdd;
    private float swordFXAdd;



    public float SwordAttackCount;
    public float BowAttackCount;
    public float PotionUseCount;
    

    
    private void Start()

    {
        potionFXAdd = MainMenuController.PotionPower;
        bowFXAdd = MainMenuController.BowPower;
        swordFXAdd = MainMenuController.SwordPower;

        
        playerController = GetComponent<PlayerController>();
        currentHealthPlayer = playerController.HealthLevel;
        swordAttackButton.interactable = false;
        bowAttackButton.interactable = false;
        potionButton.interactable = false;
        SwordAttackCount = 1;
        BowAttackCount = 1;
        PotionUseCount = 1;
}
    private void FixedUpdate()
    {
        if (playerController.ReadyToGo.interactable == true)
        {
            swordAttackButton.interactable = false;
            bowAttackButton.interactable = false;
            potionButton.interactable = false;
        }
        InfoHP();
        SpelsInfo();       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemyObject = collision.gameObject;
            enemyInfo = true;
            curentHealthEnemy = enemyObject.GetComponent<HealthSetting>().HealthLevel;
        }        
    }
    /// <summary>
    /// Информация о здоровье персонажей
    /// </summary>
    private void InfoHP()
    {
        if (enemyInfo == true)
        {
            swordAttackButton.interactable = true;
            bowAttackButton.interactable = true;
            potionButton.interactable = true;

            hPPEnemyText.text = enemyObject.GetComponent<HealthSetting>().HealthLevel.ToString();
            hPPEnemyImg.fillAmount = enemyObject.GetComponent<HealthSetting>().HealthLevel / curentHealthEnemy;

            if (enemyObject.GetComponent<HealthSetting>().HealthLevel <= 0)
            {
                hPPEnemyImg.fillAmount = 0;
                hPPEnemyText.text = 0.ToString();
                enemyInfo = false;
            }
        }
        else if (enemyInfo == false)
        {
            hPPEnemyImg.fillAmount = 0;
            hPPEnemyText.text = 0.ToString();

        }
        
        hPPlayerText.text = playerController.HealthLevel.ToString();
        hPPlayerImg.fillAmount = playerController.HealthLevel/currentHealthPlayer;

        if (playerController.HealthLevel <=0 )
        {
            hPPlayerImg.fillAmount = 0;
            hPPlayerText.text = 0.ToString();
        }
    }
   /// <summary>
   /// Информация и доступ к способностям
   /// </summary>
    private void SpelsInfo()
    {
        swordCountText.text =  SwordAttackCount.ToString();
        bowCountText.text =  BowAttackCount.ToString();;
        potionCountText.text = PotionUseCount.ToString();
        goldCountText.text = MainMenuController.GoldCount.ToString();

        bowPowerInfoText.text = MainMenuController.BowPower.ToString();
        swordPowerdInfoText.text = MainMenuController.SwordPower.ToString();
        potionPowerInfoText.text = MainMenuController.PotionPower.ToString();

        if (SwordAttackCount == 0) swordAttackButton.interactable = false;
        if (BowAttackCount == 0) bowAttackButton.interactable = false;
        if (PotionUseCount == 0) potionButton.interactable = false;
    }

    public void SwordAttackButtonPressed()
    {
        enemyObject.GetComponent<HealthSetting>().GotDamage(swordFXAdd);
        SwordAttackCount -= 1;
        audioController.GetComponent<AudioController>().AttackSwordPlay();
    }

    public void BowAttackButtonPressed()
    {
        enemyObject.GetComponent<HealthSetting>().GotDamage(bowFXAdd);
        BowAttackCount -= 1;
        audioController.GetComponent<AudioController>().AttackBowPlay();
    }

    public void PotionButtonPressed()
    {
        playerController.HealthLevel += potionFXAdd;
        PotionUseCount -= 1;
        audioController.GetComponent<AudioController>().HealthUpPlay();
    }

}
  
