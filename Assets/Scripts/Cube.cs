using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    private Material _material;
    
    public event Action<Cube> Fell;
    
    public bool HasCubeHasLanded { get; private set; } = false;

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
    }

    private void OnEnable()
    {
        HasCubeHasLanded = false;
    }

    private void OnDisable()
    {
        _material.color = Color.white;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (HasCubeHasLanded == false && other.transform.TryGetComponent<Platform>(out Platform platform))
        {
            HasCubeHasLanded = true;
            Repaint();
            Fell?.Invoke(this);
        }
    }

    private void Repaint()
    {
        float canalR = Random.Range(0f, 1f); 
        float canalG = Random.Range(0f, 1f);
        float canalB = Random.Range(0f, 1f);
        _material.color = new Color(canalR, canalG, canalB);
    }
}
