using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace InteractionWithCube
{
    [RequireComponent(typeof(Renderer))]
    [RequireComponent(typeof(Rigidbody))]
    
    public class Cube : MonoBehaviour
    {
        public static event Action<Transform, float> ClickedOnCube;   
        public Transform TransformCube { get; private set; }
        public float ProbabilityOfDisintegration { get; private set; } = 10f;
        
        public void ReduceChanceSpawn(float chance)
        {
            ProbabilityOfDisintegration = chance / 2f;
        }
        
        private void Awake()
        {
            Renderer renderer = GetComponent<Renderer>();
            float cannalR = Random.Range(0f, 1f); 
            float cannalG = Random.Range(0f, 1f);
            float cannalB = Random.Range(0f, 1f);
            renderer.material.color = new Color(cannalR, cannalG, cannalB);
        }

        private void OnMouseUpAsButton()
        {
            TransformCube = transform;
            ClickedOnCube?.Invoke(TransformCube, ProbabilityOfDisintegration);
            Destroy(gameObject);
        }
    }
}

