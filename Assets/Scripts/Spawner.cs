using System.Collections;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CubeColorizer _cubeColorizer;
    [SerializeField] private Cube _prefabCube;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _poolMaxSize = 5;

    private ObjectPool<GameObject> _pool;
    private Cube[] _cubes;
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
        
        _cubes = new Cube[_poolMaxSize];
        
        for (int i = 0; i < _poolCapacity; i++)
            _cubes[i] = _pool.Get().GetComponent<Cube>();
    }
    
    private void OnEnable()
    {
        foreach (Cube cube in _cubes)
           cube.IsGround += ReturnToPool;
    }
         

    private void OnDisable()
    {
        foreach (Cube cube in _cubes)
            cube.IsGround -= ReturnToPool;
    }

    private GameObject CreateCube()
    {
        GameObject cube = Instantiate(_prefabCube.gameObject);
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
            _cubeColorizer.Repaint(cube);
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