using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnCube : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        int _countCube = Random.Range(2, 7);
        float randomPercent = Random.Range(0, 11);
        float spawnPercent = gameObject.transform.localScale.x * 10;
        
        if (spawnPercent >= randomPercent)
        {
            for (int i = 0; i < _countCube; i++)
            {
                float cannalR = Random.Range(0f, 1f); 
                float cannalG = Random.Range(0f, 1f);
                float cannalB = Random.Range(0f, 1f);
                GameObject newCube = Instantiate(gameObject);
                newCube.GetComponent<Renderer>().material.color = new Color(cannalR, cannalG, cannalB);
                Vector3 cubeScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                newCube.transform.localScale = cubeScale / 2;
            }
        }
        
        Destroy(gameObject);
    }
}
