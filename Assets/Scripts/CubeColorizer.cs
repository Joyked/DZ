using UnityEngine;
using Random = UnityEngine.Random;

public class CubeColorizer : MonoBehaviour
{
    private void RepaintCube(Cube cube)
    {
        Renderer renderer = cube.GetComponent<Renderer>();

        if (cube.HasCubeHasLanded)
        {
            float canalR = Random.Range(0f, 1f); 
            float canalG = Random.Range(0f, 1f);
            float canalB = Random.Range(0f, 1f);
            renderer.material.color = new Color(canalR, canalG, canalB);
        }
    }

    public void ResetColor(Cube cube)
    {
        Renderer renderer = cube.GetComponent<Renderer>();
        renderer.material.color = Color.white;
    }

    private void OnEnable()
    {
        Cube.CubeHasLanded += RepaintCube;
    }

    private void OnDisable()
    {
        Cube.CubeHasLanded -= RepaintCube;
    }
}
