using System;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public event Action<Cube> CubeHasLanded;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.TryGetComponent(out Cube cube) && cube.HasCubeHasLanded == false)
        {
            CubeHasLanded?.Invoke(cube);
            cube.Fall();
        }
    }
}