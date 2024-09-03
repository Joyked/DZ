using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawn
{
    [RequireComponent(typeof(Renderer))]
    
    public class Cube : MonoBehaviour
    {
        private float divider = 2f;
        private SpawnCube _spawnCube;
        
        private void Awake()
        {
            _spawnCube = GetComponent<SpawnCube>();
            Renderer renderer = GetComponent<Renderer>();
            float cannalR = Random.Range(0f, 1f); 
            float cannalG = Random.Range(0f, 1f);
            float cannalB = Random.Range(0f, 1f);
            renderer.material.color = new Color(cannalR, cannalG, cannalB);
        }

        public void InitScale(Vector3 scale)
        {
            transform.localScale = scale / divider;
        }
        
        private void OnMouseUpAsButton()
        {
            _spawnCube.SpawnNew();
        }
    }
}

