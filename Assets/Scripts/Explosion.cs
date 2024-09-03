using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void ScatterTheCube(Vector3 positionExplosion)
    {
        _rigidbody.AddExplosionForce(_explosionForce, positionExplosion, _explosionRadius);
    }
}
