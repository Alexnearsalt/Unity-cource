using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CubeCreate : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private float rotationSpeed = 30;
    [SerializeField] private bool counterClockvise;
    [SerializeField] private int numberOfObjects = 8;
    [SerializeField] private float circleRadius = 5;
    
    
    private void Awake()
    {
        for(int i = 0; i < numberOfObjects; i++)
        {
            var angleInRadians = ((float)i / numberOfObjects) * 2 * Mathf.PI;
            
            var posX = transform.position.x + circleRadius * Mathf.Cos(angleInRadians);
            var posY = transform.position.y;
            var posZ = transform.position.z+ circleRadius * Mathf.Sin(angleInRadians);
            
            Instantiate(cubePrefab, new Vector3(posX, posY, posZ), Quaternion.identity, parent);
        }
    }
    
    private void Update()
    {
        if (counterClockvise == true) transform.Rotate(Vector3.up * Time.deltaTime * -rotationSpeed);
        else transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }
}
