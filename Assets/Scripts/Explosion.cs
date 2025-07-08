using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 30.0f;
    [SerializeField] private float _explosionForce = 300.0f;

    public void Explode(List<Cube> cubes, Vector3 explosionPosition)
    {
        foreach (Cube cube in cubes)
            cube.RigidBody.AddExplosionForce(_explosionForce, explosionPosition, _explosionRadius);
    }

    public void Explode(Cube cube)
    {
        float newExplosionRadius = _explosionRadius * cube.CurrentGeneration;
        float newExplosionForce = _explosionForce * cube.CurrentGeneration;
        Collider[] colliders = Physics.OverlapSphere(cube.transform.position, newExplosionRadius);

        foreach (Collider collider in colliders)
            if (collider.TryGetComponent(out Cube collidedCube))
                collidedCube.RigidBody.AddExplosionForce(newExplosionForce, cube.transform.position, newExplosionRadius);
    }
}
