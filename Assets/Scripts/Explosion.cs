using UnityEngine;

namespace InteractionWithCube
{
    public class Explosion : MonoBehaviour
    {
        [SerializeField] private float _explosionForce;
        private float _explosionRadius;
        private Rigidbody _rigidbody;

        public void ScatterTheCube(Cube cube)
        {
            _rigidbody = cube.GetComponent<Rigidbody>();
            _rigidbody.AddExplosionForce(_explosionForce, cube.transform.position, _explosionRadius);
        }
    }
}

