using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Material _material;
    
    public event Action<Cube> IsGround;
    
    public bool HasCubeHasLanded { get; private set; } = false;

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (HasCubeHasLanded == false && other.transform.TryGetComponent<Platform>(out Platform platform))
        {
            Fall();
            IsGround?.Invoke(this);
        }
    }
    public void ReturnToSpawn()
    {
        HasCubeHasLanded = false;
    }

    public void Fall()
    {
        HasCubeHasLanded = true;
    }

    public Material GetMaterial()
    {
        return _material;
    }
}
