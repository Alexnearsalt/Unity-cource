using System;
using UnityEngine;

public class GameRuntime : MonoBehaviour
{
    // Для дальнейшей работы с UI
    
    [SerializeField] private int totalScore = 0;
    [SerializeField] private GameObject dice;
    [SerializeField] private int diceAmount = 2;
    [SerializeField] private int winScore = 9;
    [SerializeField] private int drawScore = 5;
    [SerializeField] private TextControl textControl;
    private float circleRadius = 3;
    private GameObject[] dices;

    private void Awake()
    {
        CreateDice();
    }

    private void Update()
    {
        if (totalScore < drawScore) textControl.ChangeText(totalScore, "Проигрыш");
        else if (totalScore < winScore) textControl.ChangeText(totalScore, "Ничья");
        else textControl.ChangeText(totalScore, "Победа");
    }

    public void CreateDice()
    {
        for (int i = 0; i < diceAmount; i++)
        {
            Debug.Log("Для броска кубиков нажмите Space");
            Debug.Log("Для сброса результата нажмите R");
            var angleInRadians = ((float)i / diceAmount) * 2 * Mathf.PI;

            var posX = transform.position.x + circleRadius * Mathf.Cos(angleInRadians);
            var posY = transform.position.y;
            var posZ = transform.position.z + circleRadius * Mathf.Sin(angleInRadians);

            Instantiate(dice, new Vector3(posX, posY, posZ), Quaternion.identity);
        }
    }

    public void AddScore(int value)
    {
        totalScore += value;
    }

    public void ResetScore()
    {
        totalScore = 0;
    }

    public void ResetScene(int value)
    {
        GameObject[] allDice = GameObject.FindGameObjectsWithTag("d6");

        foreach (GameObject dice in allDice)
        {
            DestroyImmediate(dice,true);
        }
        
        diceAmount = value;
        CreateDice();
    }

    public void ChangeDrawCon(int value)
    {
        drawScore = value;
    }

    public void ChangeWinCon(int value)
    {
        winScore = value;
    }
}
