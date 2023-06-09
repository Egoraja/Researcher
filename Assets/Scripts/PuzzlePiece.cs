using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] private GameObject roguePlayer;
    [SerializeField] private GameObject audioController;
    private BoxCollider2D puzzleBody;
    [SerializeField] private GameObject puzzleManager;
    private bool isDragging;
    private Vector2 offset;    
    private string tag;
    private string nameObject;

    private void Start()
    {
        tag = gameObject.tag;
        puzzleBody = GetComponent<BoxCollider2D>();
        
    }

    private void Update()
    {
        if (isDragging == false) return;
        Vector2 mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - offset;
        transform.position = mousePosition;
    }
    /// <summary>
    /// «ахват и перемещение пазла, отключение коллайдера
    /// </summary>
    private void OnMouseDown()
    {
        isDragging = true;                   
        puzzleBody.enabled = false;            
        audioController.GetComponent<AudioController>().PickUpPlay();            
        offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;                                  
    }
    /// <summary>
    /// ќтпускаем пазл и возвращаем на место
    /// </summary>
    private void OnMouseUp()
    {
        isDragging = false;
        puzzleBody.enabled = true;
        puzzleBody.isTrigger = false;
        audioController.GetComponent<AudioController>().DropPlay();
        StartCoroutine(Timer());
    }    
    /// <summary>
    /// ѕроверка на совпадение пазла, при совпадении сообщаем бонус за совпадение, в генеральном массиве присваеваем нулевые значени€
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.CompareTag(tag) == gameObject.CompareTag(tag))
        {            
            int bonus = 0;
            if (gameObject.CompareTag("Sword")) bonus = 1;
            if (gameObject.CompareTag("Bow")) bonus = 2;
            if (gameObject.CompareTag("Potion")) bonus = 3;
            if (gameObject.CompareTag("Coin")) bonus = 4;            
            nameObject = gameObject.name;
            int puzzleType = int.Parse(nameObject);                      
            Destroy(collision.gameObject,0.1f); 
            roguePlayer.gameObject.GetComponent<PuzzleManager>().Success(puzzleType, bonus);
        }                                                
    }

    private IEnumerator Timer()
    {              
        yield return new WaitForSeconds(0.15f);
        transform.position = puzzleManager.GetComponent<PuzzleManager>().bornPlace[int.Parse(gameObject.name)].transform.position;               
    }   
}
