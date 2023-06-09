using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PuzzleManager : MonoBehaviour
{
    
    [SerializeField] public GameObject[] bornPlace; // ���� �������� ������
    [SerializeField] private GameObject[] puzzlePiece; //���� ������
    [SerializeField] private GameObject audioController;
    [SerializeField] private GameObject parentObject;
    [SerializeField] private int startsKit;
    [SerializeField] private int[] puzzlePlan; // ����������� ������, ������ ��� ������������ ������� ������
    private SpellsController spellsController;
    private Vector2[] puzzlePosition;    
    private Random random = new Random();

   /// <summary>
   /// ������������ ������������ �������, �������� ���������� ������ ������
   /// </summary>
    private void Awake()
    { 
        spellsController = GetComponent<SpellsController>(); 
        puzzlePosition = new Vector2[bornPlace.Length];
        puzzlePlan = new int[bornPlace.Length];         
        for (int i = 0; i < puzzlePosition.Length; i++)
        {
            puzzlePosition[i] = bornPlace[i].transform.position;
            puzzlePlan[i] = 0;
        }
        
        for (int i = 0; i <startsKit; i++)
        {
            int rnd = random.Next(puzzlePlan.Length);
            if (puzzlePlan[rnd] == 0) puzzlePlan[rnd] = random.Next(1, puzzlePiece.Length);
            else i -= 1;            
        }        
        FillingArea();       
    }

    /// <summary>
    /// ���������� ���� �������
    /// </summary>
    private void FillingArea()
    {
        for (int i = 0; i < puzzlePlan.Length; i++)
        {
            CreatPuzzle(i);
        }
    }

    private void CreatPuzzle(int NewPuzle)
    {
        switch (puzzlePlan[NewPuzle])
        {
           
            case 1: GameObject newGameObject = Instantiate(puzzlePiece[1], puzzlePosition[NewPuzle], Quaternion.identity);
                newGameObject.name = NewPuzle.ToString();
                newGameObject.transform.SetParent(parentObject.transform); break;
            case 2: newGameObject = Instantiate(puzzlePiece[2], puzzlePosition[NewPuzle], Quaternion.identity);
                newGameObject.name = NewPuzle.ToString();
                newGameObject.transform.SetParent(parentObject.transform); break;
            case 3: newGameObject = Instantiate(puzzlePiece[3], puzzlePosition[NewPuzle], Quaternion.identity);
                newGameObject.name = NewPuzle.ToString();
                newGameObject.transform.SetParent(parentObject.transform); break;
            case 4: newGameObject = Instantiate(puzzlePiece[4], puzzlePosition[NewPuzle], Quaternion.identity);
                newGameObject.name = NewPuzle.ToString();
                newGameObject.transform.SetParent(parentObject.transform); break;
            case 5: newGameObject = Instantiate(puzzlePiece[5], puzzlePosition[NewPuzle], Quaternion.identity);
                newGameObject.name = NewPuzle.ToString();
                newGameObject.transform.SetParent(parentObject.transform); break;
        }

    }
   
    /// <summary>
    /// ���������� ���� ��������������� �������
    /// </summary>
    /// <param name="NewKit"> ������ ��������������</param>
    public void AddBonus(int NewKit)
    {
       NewKit = CheckAreaPuzzle(NewKit);

        for (int i = 0; i < NewKit; i++)
        {
            int rndPlace = random.Next(puzzlePlan.Length);
            
            if (puzzlePlan[rndPlace] == 0)
            {
               puzzlePlan[rndPlace] = random.Next(1, puzzlePiece.Length);
               
                switch (puzzlePlan[rndPlace])
                {
                    case 1:
                        GameObject newGameObject = Instantiate(puzzlePiece[1], bornPlace[rndPlace].transform.position, Quaternion.identity);
                        newGameObject.name = rndPlace.ToString();
                        newGameObject.transform.SetParent(parentObject.transform); break;
                    case 2:
                        newGameObject = Instantiate(puzzlePiece[2], bornPlace[rndPlace].transform.position, Quaternion.identity);
                        newGameObject.name = rndPlace.ToString();
                        newGameObject.transform.SetParent(parentObject.transform); break;
                    case 3:
                        newGameObject = Instantiate(puzzlePiece[3], bornPlace[rndPlace].transform.position, Quaternion.identity);
                        newGameObject.name = rndPlace.ToString();
                        newGameObject.transform.SetParent(parentObject.transform); break;
                    case 4:
                        newGameObject = Instantiate(puzzlePiece[4], bornPlace[rndPlace].transform.position, Quaternion.identity);
                        newGameObject.name = rndPlace.ToString();
                        newGameObject.transform.SetParent(parentObject.transform); break;
                    case 5:
                        newGameObject = Instantiate(puzzlePiece[5], bornPlace[rndPlace].transform.position, Quaternion.identity);
                        newGameObject.name = rndPlace.ToString();
                        newGameObject.transform.SetParent(parentObject.transform); break;
                }
            }
            else i -= 1;
        }       
    }
    /// <summary>
    /// �������� ������� ��������� ���� ��� ������ ��������� ������
    /// </summary>
    /// <param name="Check"> �������������� ����������� ����� ������ � ���������� ����� </param>
    /// <returns></returns>
    private int CheckAreaPuzzle(int Check)
    {
        int temp = 0;
        for (int i = 0; i < puzzlePlan.Length; i++)
        {
            if (puzzlePlan[i] == 0)
            {
                temp += 1;
                if (temp == Check) break;
            }
        }
        if (temp < Check)
           Check = temp;        
        return Check;   
    }
    /// <summary>
    /// �������� ���������� ��� ������������ ������� � ����� ��������� �����.
    /// ��������� ������� �� ����������
    /// </summary>
    /// <param name="PuzzleType">����� �����, ������� �������������</param>
    /// <param name="Bonus">��� ������</param>
    public void Success(int PuzzleType, int Bonus)
    {               
        puzzlePlan[PuzzleType] = 0;        
        if (Bonus == 1)
        {            
            spellsController.SwordAttackCount += 0.5f;
        }
        if (Bonus == 2)
        {           
            spellsController.BowAttackCount += 0.5f;
        }
        if (Bonus == 3)
        {           
            spellsController.PotionUseCount += 0.5f;
        }
        if (Bonus == 4)
        {            
            MainMenuController.GoldCount += 2.5f;
        }
    }    
}
