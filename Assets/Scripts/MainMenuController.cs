using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
   
    [SerializeField] private Button upgradeSwordButton;
    [SerializeField] private Button upgradeBowButton;
    [SerializeField] private Button upgradePotionButton;
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button infoButton;
    [SerializeField] private GameObject infoPanel;

    [SerializeField] private Text textPlusSwordPower;
    [SerializeField] private Text textPlusBowPower;
    [SerializeField] private Text textPlusPotionPower;
    [SerializeField] private Text textPriceBowUpgrade;
    [SerializeField] private Text textPriceSwordUpgrade;
    [SerializeField] private Text textPricePotionUpgrade;  
    [SerializeField] private Text textCoinInfo;
    [SerializeField] private Text textBowPowerNow;
    [SerializeField] private Text textSwordPowerNow;
    [SerializeField] private Text textPotionPowerNow;

    [SerializeField] private AudioSource mainTheme;
    [SerializeField] private AudioSource click;
        
    public static float GoldCount = 0;
    public static float SwordPower = 2;
    public static float BowPower = 2;
    public static float PotionPower = 2;

    [SerializeField] private int plusSwordPower;
    [SerializeField] private int plusBowPower;
    [SerializeField] private int plusPotionPower;   
    [SerializeField] private int priceUpgrade;


    private void Start()
    {
        mainTheme.Play();
        infoPanel.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (GoldCount < priceUpgrade)
        {
           upgradeSwordButton.interactable = false;
           upgradeBowButton.interactable = false;
           upgradePotionButton.interactable = false;
        }

        textPlusSwordPower.text = "+" + plusSwordPower.ToString();
        textPlusBowPower.text = "+" + plusBowPower.ToString();
        textPlusPotionPower.text = "+" + plusPotionPower.ToString();

        textPriceSwordUpgrade.text = priceUpgrade.ToString();
        textPriceBowUpgrade.text = priceUpgrade.ToString();
        textPricePotionUpgrade.text = priceUpgrade.ToString();

        textCoinInfo.text = GoldCount.ToString();
        
        textBowPowerNow.text = BowPower.ToString();
        textSwordPowerNow.text = SwordPower.ToString();
        textPotionPowerNow.text = PotionPower.ToString();
    }

    public void StartGamePressed()
    {
        SceneManager.LoadScene(1);
        click.Play();
        mainTheme.Stop();
    }

    public void UpgradeBowPressed()
    {
        GoldCount -= priceUpgrade;
        priceUpgrade += 1;
        BowPower += plusBowPower;

        click.Play();
    }
    
    public void UpgradeSwordPressed()
    {
        GoldCount -= priceUpgrade;
        priceUpgrade += 1;
        SwordPower += plusSwordPower;
        click.Play();
    }
    
    public void UpgradePotionPressed()
    {
        GoldCount -= priceUpgrade;
        priceUpgrade += 1;
        PotionPower += plusPotionPower;
        click.Play();
    }  
    
    public void InfoButtonPressed()
    {
        infoPanel.SetActive(true);
        upgradeSwordButton.interactable = false;
        upgradeBowButton.interactable = false;
        upgradePotionButton.interactable = false;
        startGameButton.interactable = false;
        infoButton.interactable = false;

        click.Play();
    }    
    
    public void BackButtonPressed()
    {
        upgradeSwordButton.interactable = true;
        upgradeBowButton.interactable = true;
        upgradePotionButton.interactable = true;
        startGameButton.interactable = true;
        infoButton.interactable = true;
        infoPanel.SetActive(false);
        click.Play();
    }        
}
