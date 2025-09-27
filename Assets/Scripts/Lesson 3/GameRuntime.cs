using System;
using UnityEngine;

public class GameRuntime : MonoBehaviour
{
    // Для дальнейшей работы с UI
    
    [SerializeField] private int totalScore = 0;
    [SerializeField] private GameObject dice;
    [SerializeField] private int diceAmount = 1;
    private float circleRadius = 3;

    private void Awake()
    {
        for(int i = 0; i < diceAmount; i++)
        {
            Debug.Log("Для броска кубиков нажмите Space");
            Debug.Log("Для сброса результата нажмите R");
            var angleInRadians = ((float)i / diceAmount) * 2 * Mathf.PI;
            
            var posX = transform.position.x + circleRadius * Mathf.Cos(angleInRadians);
            var posY = transform.position.y;
            var posZ = transform.position.z+ circleRadius * Mathf.Sin(angleInRadians);
            
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
}
