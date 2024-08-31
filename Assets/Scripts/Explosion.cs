using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Explosion : MonoBehaviour
{

    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    private void OnMouseUpAsButton()
    {
        Explode();
        Destroy(gameObject);
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects())
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }
    
    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> cube = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                cube.Add(hit.attachedRigidbody);
        
        return cube;
    }
}
