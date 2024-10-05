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
            
            if (probabilityOfDisintegration >= randomPercent)
            {
                for (int i = 0; i < countCube; i++)
                {
                    float chanceSpawn = probabilityOfDisintegration;
                    Cube newCube = Instantiate(_newCube);
                    _explosion.ScatterTheNewCube(newCube);
                    newCube.transform.position = transformCube.position;
                    newCube.transform.localScale = transformCube.localScale / divider;
                    newCube.ReduceChanceSpawn(chanceSpawn);
                }
            }
            else
            {
                _explosion.ScatterNeighboringCubes(transformCube.gameObject.GetComponent<Cube>());
            }
            
            Destroy(transformCube.gameObject);
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
