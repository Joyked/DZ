using UnityEngine;

public class PlatformRotate : MonoBehaviour
{
    [SerializeField] private float _speedRotation;
    [SerializeField] private int _numberOfRotationChanges;
    [SerializeField] private SideOfRotation _sideOfRotation;

    private int _numberCollisionDetected = 0;
        
    private enum SideOfRotation
    {
        Left = 1,
        Right = -1
    }
    
    private void OnCollisionEnter(Collision other)
    {
        _numberCollisionDetected++;

        if (_numberCollisionDetected >= _numberOfRotationChanges)
        {
            ChangleDirection();
            _numberCollisionDetected = 0;
        }
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.back, _speedRotation * _sideOfRotation.GetHashCode());
    }

    private void ChangleDirection()
    {
       _sideOfRotation = _sideOfRotation == SideOfRotation.Left ? SideOfRotation.Right : SideOfRotation.Left;
    }
}
