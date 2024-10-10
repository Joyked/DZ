using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public static event Action<Cube> CubeHasLanded;
    public bool HasCubeHasLanded { get; private set; } = false;

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.TryGetComponent(out Platform platform) && !HasCubeHasLanded)
        {
            HasCubeHasLanded = true;
            CubeHasLanded?.Invoke(this);
        }
    }

    public void ReturnToSpawn()
    {
        HasCubeHasLanded = false;
    }
}
