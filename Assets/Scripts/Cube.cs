using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawn
{
    public class Cube : MonoBehaviour
    {
        private float _spawnPercent = 10f;
        private void Awake()
        {
            Renderer renderer = GetComponent<Renderer>();
            float cannalR = Random.Range(0f, 1f); 
            float cannalG = Random.Range(0f, 1f);
            float cannalB = Random.Range(0f, 1f);
            renderer.material.color = new Color(cannalR, cannalG, cannalB);
        }

        public void SetSpawnPercent(float percent, float divider)
        {
            _spawnPercent = percent / divider;
        }
        
        public float GetSpawnPercent()
        {
            return _spawnPercent;
        }
    }
}

