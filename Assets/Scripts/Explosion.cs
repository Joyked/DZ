using System.Collections.Generic;
using UnityEngine;

namespace InteractionWithCube
{
    public class Explosion : MonoBehaviour
    {
        [SerializeField] private float _explosionForce;
        private Rigidbody _rigidbody;

        public void ScatterTheNewCube(Cube cube)
        {
            _rigidbody = cube.GetComponent<Rigidbody>();
            float explosionRadius = 0;
            _rigidbody.AddExplosionForce(_explosionForce, cube.transform.position, explosionRadius);
        }

        public void ScatterNeighboringCubes(Cube cube)
        {
            float defaultExplosionSettings = 500;
            float explosionRadius = defaultExplosionSettings / cube.ProbabilityOfDisintegration;
            _explosionForce = defaultExplosionSettings / cube.ProbabilityOfDisintegration;
            
            foreach (Rigidbody explodableObject in GetExplodableObjects(cube, explosionRadius))
                explodableObject.AddExplosionForce(_explosionForce, cube.transform.position, explosionRadius);
        }
        
        private List<Rigidbody> GetExplodableObjects(Cube cube, float explosionRadius)
        {
            Collider[] hits = Physics.OverlapSphere(cube.transform.position, explosionRadius);

            List<Rigidbody> cubes = new();

            foreach (Collider hit in hits)
                if (hit.attachedRigidbody != null)
                    cubes.Add(hit.attachedRigidbody);
    
            return cubes;
        }
    }
}

