using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _minSpawnAmount = 2;
    [SerializeField] private int _maxSpawnAmount = 6;
    [SerializeField] private float _spawnRadius = 2.0f;
    private int _dividerValue = 2;

    public List<Cube> SpawnNewObjects(Cube cube)
    {
        Vector3 newScale = cube.transform.localScale / _dividerValue;
        Vector3 newPosition;
        GameObject spawnedObject;
        List<Cube> spawnedCubes = new List<Cube>();
        int objectsAmount = Random.Range(_minSpawnAmount, _maxSpawnAmount + 1);

        for (int i = 0; i < objectsAmount; i++)
        {
            newPosition = cube.transform.position + Random.insideUnitSphere * _spawnRadius;
            newPosition.y = cube.transform.position.y;
            spawnedObject = Instantiate(cube.gameObject, newPosition, new Quaternion());
            spawnedObject.transform.localScale = newScale;

            if (spawnedObject.TryGetComponent(out Cube spawnedCube))
                spawnedCube.DecreaseSplitChance(cube.SplitChance);

            spawnedCubes.Add(spawnedCube);
        }

        return spawnedCubes;
    }
}
