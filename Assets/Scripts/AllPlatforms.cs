using System;
using UnityEngine;

public class AllPlatforms : MonoBehaviour
{
    [SerializeField] private Platform[] _platforms;

    public event Action<Cube> CubeHere;
    
    private void OnEnable()
    {
        foreach (var platform in _platforms)
            platform.CubeHasLanded += DetectedCube;
    }

    private void OnDisable()
    {
        foreach (var platform in _platforms)
            platform.CubeHasLanded -= DetectedCube;
    }
    
    private void DetectedCube(Cube cube)
    {
        cube.Fall();
        CubeHere?.Invoke(cube);
    }

}
