using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50;
    [SerializeField] private bool coordinateX;
    [SerializeField] private bool coordinateY = true;
    [SerializeField] private bool coordinateZ;

    
    // Update is called once per frame
    void Update()
    {
        if (coordinateX == true) transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed);
        if (coordinateY == true) transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
        if (coordinateZ == true) transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
        
    }
}
