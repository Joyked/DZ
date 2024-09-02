using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawn
{
    public class SpawnCube : MonoBehaviour
    {
        [SerializeField] private Cube _newCube;
        
        private void OnMouseUpAsButton()
        {
            Vector3 localScale = transform.localScale;
            int countCube = Random.Range(2, 7);
            float spawnPercent = _newCube.GetSpawnPercent();
            float randomPercent = Random.Range(0, 11);
            float divider = 2f;
            
            if (spawnPercent >= randomPercent)
            {
                for (int i = 0; i < countCube; i++)
                {
                    _newCube = Instantiate(_newCube);
                    _newCube.SetSpawnPercent(spawnPercent, divider);
                    Vector3 cubeScale = new Vector3(localScale.x, localScale.y, localScale.z);
                    _newCube.transform.localScale = cubeScale / divider;
                }
            }
        
            Destroy(gameObject);
        }
    }
}
