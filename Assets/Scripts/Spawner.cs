using System.Collections;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private AllPlatforms _allPlatforms;
    [SerializeField] private CubeColorizer _cubeColorizer;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _poolMaxSize = 5;

    private ObjectPool<GameObject> _pool;
    private Renderer _rendererCube;

    private void Awake()
    {
        _pool = new ObjectPool<GameObject>
        (
            CreateCube,
            ActionOnGet,
            ActionOnRelease,
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize
        );

        for (int i = 0; i < _poolCapacity; i++)
            _pool.Get();
    }
    
    private void OnEnable()
    {
        _allPlatforms.CubeHere += ReturnToPool;
    }

    private void OnDisable()
    {
        _allPlatforms.CubeHere -= ReturnToPool;
    }

    private GameObject CreateCube()
    {
        GameObject cube = Instantiate(_prefab);
        return cube;
    }

    private void ActionOnGet(GameObject obj)
    {
        obj.SetActive(true);
        Cube cube = obj.GetComponent<Cube>();
        cube.ReturnToSpawn();
        _cubeColorizer.ResetColor(cube);

        float minXPosition = -7f;
        float maxXPosition = 8f;
        float minZPosition = -4f;
        float maxZPosition = 5f;
        float randomPositionX = Random.Range(minXPosition, maxXPosition);
        float randomPositionZ = Random.Range(minZPosition, maxZPosition);
        float positionY = 25;
        obj.transform.position = new Vector3(randomPositionX, positionY, randomPositionZ);
    }

    private void ActionOnRelease(GameObject obj)
    {
        obj.SetActive(false);
    }
    
    private void ReturnToPool(Cube cube)
    {
        if (cube.HasCubeHasLanded)
        {
            int minSecond = 2;
            int maxSecond = 6;
            int randomSecond = Random.Range(minSecond, maxSecond);
            StartCoroutine(CubeCycle(randomSecond, cube));
        }
    }
    
    private IEnumerator CubeCycle(float second, Cube cube)
    {
        yield return new WaitForSeconds(second);
        _pool.Release(cube.gameObject);
        _pool.Get();
    }
}