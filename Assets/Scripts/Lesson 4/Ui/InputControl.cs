using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class InputControl : MonoBehaviour
{
    [SerializeField] private GameRuntime gameRuntime;
    [SerializeField] private DiceJump _diceJump;
    [SerializeField] private Button jumpButton;
    [SerializeField] private TMP_InputField diceAmount;
    [SerializeField] private TMP_InputField winCon;
    [SerializeField] private TMP_InputField drawCon;

    private int _diceAmount;

    private void Awake()
    {
        diceAmount.onValueChanged.AddListener(ChangeDiceAmount);
        winCon.onValueChanged.AddListener(ChangeWinCon);
        drawCon.onValueChanged.AddListener(ChangeDrawCon);
        jumpButton.onClick.AddListener(OnButtonClick);
    }

    private void ChangeDrawCon(string arg0)
    {
        gameRuntime.ChangeDrawCon(int.Parse(arg0));
    }

    private void ChangeWinCon(string arg0)
    {
        gameRuntime.ChangeWinCon(int.Parse(arg0));
    }

    private void ChangeDiceAmount(string arg0)
    {
        gameRuntime.ResetScene(int.Parse(arg0));
    }

    private void OnButtonClick()
    {
        DiceJump[] allDice = FindObjectsByType<DiceJump>(FindObjectsSortMode.InstanceID);

        foreach (DiceJump dice in allDice)
        {
            dice.Jump();
        }
        Debug.Log("Jump");
    }
}
