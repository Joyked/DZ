using UnityEngine;
using Random = UnityEngine.Random;

namespace InteractionWithCube
{
    public class SpawnCube : MonoBehaviour
    {
        [SerializeField] private Cube _newCube;
        [SerializeField] private Explosion _explosion;
        
        private void SpawnNew(Transform transformCube, float probabilityOfDisintegration)
        {
            int countCube = Random.Range(2, 7);
            float randomPercent = Random.Range(0, 11);
            float divider = 2f;
            Debug.Log(probabilityOfDisintegration);
            
            if (probabilityOfDisintegration >= randomPercent)
            {
                for (int i = 0; i < countCube; i++)
                {
                    float chanceSpawn = probabilityOfDisintegration;
                    _newCube = Instantiate(_newCube);
                    _explosion.ScatterTheCube(_newCube);
                    _newCube.transform.position = transformCube.position;
                    _newCube.transform.localScale = transformCube.localScale / divider;
                    _newCube.ReduceChanceSpawn(chanceSpawn);
                }
            }
        }
        
        private void OnEnable()
        {
            Cube.ClickedOnCube += SpawnNew;
        }

        private void OnDisable()
        {
            Cube.ClickedOnCube -= SpawnNew;
        }
    }
}
