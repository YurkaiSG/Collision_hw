using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private CubeDivider _divider;
    [SerializeField] private float _explosionRadius = 20.0f;
    [SerializeField] private float _explosionForce = 500.0f;

    private void OnEnable()
    {
        _divider.OnExplode.AddListener(Explode);
    }

    private void OnDisable()
    {
        _divider.OnExplode.RemoveListener(Explode);
    }

    private void Explode(Cube cube)
    {
        Collider[] _colliders = Physics.OverlapSphere(cube.transform.position, _explosionRadius);

        foreach (Collider collider in _colliders)
            if (collider.TryGetComponent(out Rigidbody rb))
                rb.AddExplosionForce(_explosionForce, cube.transform.position, _explosionRadius);
    }
}
