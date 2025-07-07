using Unity.VisualScripting;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _splitChance = 1.0f;
    [SerializeField] private float _explosionRadius = 20.0f;
    [SerializeField] private float _explosionForce = 500.0f;
    private int _minSpawnAmount = 2;
    private int _maxSpawnAmount = 6;
    private int _dividerValue = 2;
    private float _spawnRadius = 2.0f;
    private Renderer _renderer;
     
    public void OnMouseClick()
    {
        if (_splitChance >= Random.value)
            SpawnNewObjects();

        Destroy(this.gameObject);
    }

    public void DecreaseSplitChance(float chance)
    {
        _splitChance = chance / _dividerValue;
    }

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        SetRandomColor();
    }

    private void SpawnNewObjects()
    {
        Vector3 newScale = transform.localScale / _dividerValue;
        Vector3 newPosition;
        GameObject spawnedObject;
        int objectsAmount = Random.Range(_minSpawnAmount, _maxSpawnAmount + 1);

        for (int i = 0; i < objectsAmount; i++)
        {
            newPosition = transform.position + Random.insideUnitSphere * _spawnRadius;
            newPosition.y = transform.position.y;
            spawnedObject = Instantiate(this.gameObject, newPosition, new Quaternion());
            spawnedObject.transform.localScale = newScale;
            spawnedObject.GetComponent<Cube>().DecreaseSplitChance(_splitChance);
            spawnedObject.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, transform.position, _explosionRadius); ;
        }
    }

    private void SetRandomColor()
    {
        _renderer.material.color = Random.ColorHSV();
    }
}
