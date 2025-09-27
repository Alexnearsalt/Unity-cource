using System;
using UnityEngine;

public class DiceSideCheck : MonoBehaviour
{
    [SerializeField] private GameRuntime gameRuntime;
    [SerializeField] private float movementThreshold = 0.01f;
    [SerializeField] private float stopDelay = 1f;
    private Rigidbody _rb;
    private int currentScore = 0;
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
        if (_isStatic) currentScore = score;
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
