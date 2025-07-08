using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 20.0f;
    [SerializeField] private float _explosionForce = 500.0f;

    public void Explode(List<Cube> cubes, Vector3 explosionPosition)
    {
        foreach (Cube cube in cubes)
            cube.RigidBody.AddExplosionForce(_explosionForce, explosionPosition, _explosionRadius);
    }
}
