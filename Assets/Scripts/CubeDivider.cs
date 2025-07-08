using System;
using System.Collections.Generic;
using UnityEngine;

public class CubeDivider : MonoBehaviour
{
    [SerializeField] private Caster _caster;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Explosion _explosion;
    private List<Cube> _cubes;

    private void OnEnable()
    {
        _caster.OnClick += Divide;
    }

    private void OnDisable()
    {
        _caster.OnClick -= Divide;
    }

    private void Divide(Cube cube)
    {
        if (cube.SplitChance >= UnityEngine.Random.value)
        {
            _cubes = _spawner.SpawnNewObjects(cube);
            _explosion.Explode(_cubes, cube.transform.position);
        }
        else
        {
            _explosion.Explode(cube);
        }

        Destroy(cube.gameObject);
    }
}
