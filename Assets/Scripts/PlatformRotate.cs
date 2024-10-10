using UnityEngine;

public class PlatformRotate : MonoBehaviour
{
    [SerializeField] private float _speedRotation;
    [SerializeField] private SideOfRotation _sideOfRotation;
    
    enum SideOfRotation
    {
        Left = 1,
        Right = -1
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.back, _speedRotation * _sideOfRotation.GetHashCode());
    }

    private void OnCollisionEnter(Collision other)
    {
        ChangleDirection();
    }

    private void ChangleDirection()
    {
       _sideOfRotation = _sideOfRotation == SideOfRotation.Left ? SideOfRotation.Right : SideOfRotation.Left;
    }
}
