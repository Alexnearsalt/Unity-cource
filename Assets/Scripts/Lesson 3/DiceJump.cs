using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiceJump : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [Header("Jump Settings")]
    [SerializeField] private float minForce = 5f;
    [SerializeField] private float maxForce = 10f;
    [SerializeField] private float minTorque = 5f;
    [SerializeField] private float maxTorque = 10f;

    private DiceSideCheck _diceSideCheck;
    private bool _isMoving = false;
    private Vector3 _lastVelocity;
    private Vector3 _lastAngularVelocity;

    private void Awake()
    {
        _diceSideCheck = gameObject.GetComponent<DiceSideCheck>();
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        ApplyRandomForce();
        ApplyRandomTorque();
    }

    private void ApplyRandomForce()
    {
        var randomDirection = new Vector3(
            Random.Range(-1f, 1f), 
            Random.Range(0.8f, 1.2f), 
            Random.Range(-1f, 1f)
        ).normalized;
        
        var randomForce = Random.Range(minForce, maxForce);
        var force = randomDirection * randomForce;
        
        _rigidbody.AddForce(force, ForceMode.Impulse);
    }

    private void ApplyRandomTorque()
    {
        var randomTorque = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        ).normalized * Random.Range(minTorque, maxTorque);
        
        _rigidbody.AddTorque(randomTorque, ForceMode.Impulse);
    }
}
