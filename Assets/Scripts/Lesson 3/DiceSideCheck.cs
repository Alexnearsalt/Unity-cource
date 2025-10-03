using System;
using System.Collections;
using UnityEngine;

public class DiceSideCheck : MonoBehaviour
{
    [SerializeField] private GameRuntime gameRuntime;
    [SerializeField] private float movementThreshold = 0.01f;
    [SerializeField] private float stopDelay = 1f;
    [SerializeField]private int currentScore = 0;
    private Rigidbody _rb;
    private bool _isStatic;
    
    private void Awake()
    {
        if (gameRuntime == null)
        {
            gameRuntime = FindObjectOfType<GameRuntime>();
        }
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _isStatic = IsDiceStopped();
    }

    public void WriteResult(int score)
    {
        gameRuntime.AddScore(-currentScore);
        currentScore = score;
        gameRuntime.AddScore(currentScore);
    }

    public void AddSideResult()
    {
        gameRuntime.AddScore(currentScore);
    }
    private bool IsDiceStopped()
    {
        return _rb.linearVelocity.magnitude <= movementThreshold && 
               _rb.angularVelocity.magnitude <= movementThreshold;
    }
}
