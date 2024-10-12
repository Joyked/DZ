using UnityEngine;
using Random = UnityEngine.Random;

public class CubeColorizer : MonoBehaviour
{
    [SerializeField] private Cube _cubePrafab;
    [SerializeField] private AllPlatforms _allPlatforms;

    private Cube _cube;
    
    private void OnEnable()
    {
        _allPlatforms.CubeHere += RepaintCube;
    }

    private void OnDisable()
    {
        _allPlatforms.CubeHere -= RepaintCube;
    }
    
    public void ResetColor(Cube cube)
    {
        cube.GetMaterial().color = Color.white;
    }
    
    private void RepaintCube(Cube cube)
    {
        if (cube.HasCubeHasLanded)
        {
            float canalR = Random.Range(0f, 1f); 
            float canalG = Random.Range(0f, 1f);
            float canalB = Random.Range(0f, 1f);
            cube.GetMaterial().color = new Color(canalR, canalG, canalB);
        }
    }
}
