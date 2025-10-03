using System.Threading;
using UnityEngine;

public class DiceSideTrigger : MonoBehaviour
{
    [SerializeField]private int _side;
    private DiceSideCheck _diceSideCheck;

    private void Start()
    {
        _diceSideCheck = GetComponentInParent<DiceSideCheck>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            _side = 7 - int.Parse(gameObject.name);
        }
        _diceSideCheck.WriteResult(_side);
    }

    private void OnTriggerExit(Collider other)
    {

    }
}