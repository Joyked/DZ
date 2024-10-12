using UnityEngine;

public class Cube : MonoBehaviour
{
    private Material _material;
    
    public bool HasCubeHasLanded { get; private set; } = false;

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
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
