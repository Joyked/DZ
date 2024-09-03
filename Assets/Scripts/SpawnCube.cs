using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawn
{
    public class SpawnCube : MonoBehaviour
    {
        [SerializeField] private Cube _newCube;
        private float _spawnPercent = 10;
        
        public void SpawnNew()
        {
            int countCube = Random.Range(2, 7);
            float randomPercent = Random.Range(0, 11);
            float divider = 2f;
            
            if (_spawnPercent >= randomPercent)
            {
                for (int i = 0; i < countCube; i++)
                {
                    _newCube = Instantiate(_newCube);
                    _newCube.InitScale(transform.localScale);
                    _newCube.GetComponent<SpawnCube>().InitSpawnPercent(_spawnPercent);
                    _newCube.GetComponent<Explosion>().ScatterTheCube(transform.position);
                }
            }
        
            Destroy(gameObject);
        }

        public void InitSpawnPercent(float spawnPercent)
        {
            float divider = 2f;
            _spawnPercent = spawnPercent / divider;
        }
    }
}
