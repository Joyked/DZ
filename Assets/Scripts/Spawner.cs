using System.Collections;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _prefabCube;
    [SerializeField] private int _poolCapacity;
    [SerializeField] private int _poolMaxSize;

    private ObjectPool<Cube> _pool;
    private Cube[] _cubes;

    private void Awake()
    {
        _pool = new ObjectPool<Cube>
        (
            CreateCube,
            ActionOnGet,
            ActionOnRelease,
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize
        );
        
        _cubes = new Cube[_poolCapacity];

        for (int i = 0; i < _poolCapacity; i++)
            _cubes[i] = _pool.Get();
    }
    
    private void OnEnable()
    {
        foreach (Cube cube in _cubes)
           cube.Fell += ReturnToPool;
    }
    
    private void OnDisable()
    {
        foreach (Cube cube in _cubes)
            cube.Fell -= ReturnToPool;
    }

    private Cube CreateCube()
    {
        return Instantiate(_prefabCube);
    }

    private void ActionOnGet(Cube cube)
    {
        float minXPosition = -7f;
        float maxXPosition = 8f;
        float minZPosition = -4f;
        float maxZPosition = 5f;
        float randomPositionX = Random.Range(minXPosition, maxXPosition);
        float randomPositionZ = Random.Range(minZPosition, maxZPosition);
        float positionY = 25;
        cube.transform.position = new Vector3(randomPositionX, positionY, randomPositionZ);
        
        cube.gameObject.SetActive(true);
    }

    private void ActionOnRelease(Cube cube)
    {
        cube.gameObject.SetActive(false);
    }
    
    private void ReturnToPool(Cube cube)
    {
            int minSecond = 2;
            int maxSecond = 6;
            int randomSecond = Random.Range(minSecond, maxSecond);
            StartCoroutine(CubeCycle(randomSecond, cube));
    }
    
    private IEnumerator CubeCycle(float second, Cube cube)
    {
        yield return new WaitForSeconds(second);
        _pool.Release(cube);
        _pool.Get();
    }
}