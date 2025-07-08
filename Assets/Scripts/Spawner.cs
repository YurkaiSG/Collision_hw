using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CubeDivider _divider;
    [SerializeField] private int _minSpawnAmount = 2;
    [SerializeField] private int _maxSpawnAmount = 6;
    [SerializeField] private float _spawnRadius = 2.0f;
    private int _dividerValue = 2;

    private void OnEnable()
    {
        _divider.OnSpawn.AddListener(SpawnNewObjects);
    }

    private void OnDisable()
    {
        _divider.OnSpawn.RemoveListener(SpawnNewObjects);
    }

    private void SpawnNewObjects(Cube cube)
    {
        Vector3 newScale = cube.transform.localScale / _dividerValue;
        Vector3 newPosition;
        GameObject spawnedObject;
        int objectsAmount = Random.Range(_minSpawnAmount, _maxSpawnAmount + 1);

        for (int i = 0; i < objectsAmount; i++)
        {
            newPosition = cube.transform.position + Random.insideUnitSphere * _spawnRadius;
            newPosition.y = cube.transform.position.y;
            spawnedObject = Instantiate(cube.gameObject, newPosition, new Quaternion());
            spawnedObject.transform.localScale = newScale;
            spawnedObject.GetComponent<Cube>().DecreaseSplitChance(cube.SplitChance);
        }
    }
}
