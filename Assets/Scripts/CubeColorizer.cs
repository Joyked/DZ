using UnityEngine;
using Random = UnityEngine.Random;

public class CubeColorizer : MonoBehaviour
{
    public void ResetColor(Cube cube)
    {
        cube.GetMaterial().color = Color.white;
    }
    
    public void Repaint(Cube cube)
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
