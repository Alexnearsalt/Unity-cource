using UnityEngine;

public class DiceSideTrigger : MonoBehaviour
{
    private DiceSideCheck _diceSideCheck;
    private int _side;

    private void Start()
    {
        _diceSideCheck = GetComponentInParent<DiceSideCheck>();
    }

    private void OnTriggerStay(Collider other)
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